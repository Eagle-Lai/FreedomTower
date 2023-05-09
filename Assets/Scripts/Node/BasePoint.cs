using AStar;
using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FTProject
{
    public class BasePoint : MonoBehaviour
    {
        [SerializeField]
        public Point Point;
        public PointType _PointType;
        public bool IsHaveBuild = false;

        protected MeshRenderer meshRenderer;

        public BaseTower BaseTower;

        public JsonData _jsonData;

        public int column, row;

        public GameObject Cube;

        /// <summary>
        /// ��ײ����
        /// </summary>
        public GameObject currentTriggerObj;

        protected virtual void Awake()
        {

        }
        protected virtual void Start()
        {
            EventDispatcher.AddEventListener(EventName.UpdateEvent, MyUpdate);
            EventDispatcher.AddEventListener<List<BasePoint>>(EventName.BuildNormalTower, BuildFail);
            Cube = transform.Find("Cube").gameObject;
            meshRenderer = Cube.GetComponent<MeshRenderer>();
            EventDispatcher.AddEventListener<BaseTower>(EventName.DestroyTower, DestroyTower);
            EventDispatcher.AddEventListener<bool>(EventName.SetMapActiveState, SetPointActive);
        }

        public virtual void OnDestroy()
        {
            EventDispatcher.RemoveEventListener(EventName.UpdateEvent, MyUpdate);
            EventDispatcher.RemoveEventListener<List<BasePoint>>(EventName.BuildNormalTower, BuildFail);
            EventDispatcher.RemoveEventListener<BaseTower>(EventName.DestroyTower, DestroyTower);
        }

        public void SetPointActive(bool isActive) 
        {
            Cube.gameObject.SetActive(isActive);
        }

        public void DestroyTower(BaseTower baseTower)
        {
            if(BaseTower == baseTower)
            {
                ResetPoint();
                
            }
        }

        protected virtual void MyUpdate()
        {
            if (currentTriggerObj != null && meshRenderer.material.color != Color.green && _PointType == PointType.Normal)
            {
                float distance = FTProjectUtils.GetPointDistance(this.gameObject, currentTriggerObj);

                Point.IsWall = true;
                bool isFind = AStarManager.Instance.IsFindPath();
                if (!isFind)
                {
                    Point.IsWall = false;
                    ChangeColor(Color.red);
                    return;
                }
                if (distance >= GlobalConst.BuildDistance)
                {
                    ChangeColor(Color.red);
                }
                if (Mathf.Max(0.1f, distance) < GlobalConst.BuildDistance)
                {
                    ChangeColor(Color.green);
                }
            }
        }

        private void BuildFail(List<BasePoint> points)
        {
            for (int i = 0; i < points.Count; i++)
            {
                if (points[i] == this)
                {
                    ChangeColor(Color.black);
                }
            }
        }
        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name.Contains("Tower"))
            {
                currentTriggerObj = other.gameObject;
            }
        }

        protected virtual void OnTriggerExit(Collider other)
        {
            currentTriggerObj = null;
            if (_PointType == PointType.Normal && other.gameObject.name.Contains("Tower"))
            {
                ChangeColor(Color.black);
                Point.IsWall = false;
            }
        }

        protected virtual void OnTriggerStay(Collider other)
        {
            if (other.gameObject.name.Contains("Tower"))
            {
                currentTriggerObj = other.gameObject;
            }
        }
        public virtual void ChangeColor(Color color)
        {
            if (meshRenderer != null)
            {
                meshRenderer.material.color = color;
            }
        }

        public Color GetNodeColor()
        {
            return meshRenderer.material.color;
        }

        public void BuildSuccess(BaseTower baseTower)
        {
            Point.IsWall = true;
            IsHaveBuild = true;
            ChangeColor(Color.black);
            _PointType = PointType.Obstacle;
            BaseTower = baseTower;
        }

        public void ResetPoint()
        {
            Point.IsWall = false;
            IsHaveBuild = false;
            ChangeColor(Color.black);
            _PointType = PointType.Normal;
            BaseTower = null;
        }

        public void SetColumnAndRow(int col, int r)
        {
            column = col;
            row = r;
        }

        public void InitPoint()
        {
            int mapIndex = GameSceneManager.Instance.GetCurrentSceneInfo()._SceneInfo.Id;
            StartCoroutine(JsonDataManager.Instance.Read(column + row.ToString() + gameObject.name + mapIndex, (data) =>
             {
                 if (data != null)
                 {
                     _jsonData = data;
                     InitTowerInfo(data);
                 }
             }));
        }

        public void InitTowerInfo(JsonData data)
        {
            if (data != null && data.Keys.Count > 0)
            {
                //foreach (JsonData item in data)
                {
                    if (BaseTower == null)
                    {
                        bool temp = int.TryParse(data["Type"].ToString(), out int value);
                        if (temp)
                        {
                            TowerType towerType = (TowerType)value;
                            TowerJsonData towerJsonData = new TowerJsonData();
                            switch (towerType)
                            {
                                case TowerType.Normal:
                                    BaseTower = TowerManager.Instance.GetTower<NormalTower>(TowerType.Normal);
                                    BaseTower.transform.SetObjParent(transform, GlobalConst.BuildYVector3, GlobalConst.BuildScale, Quaternion.identity);
                                    break;
                                default:
                                    break;
                            }
                            BaseTower.SetBuildSuccessWithJson();
                            BaseTower.TowerType = towerType;
                            string TowerName = "";
                            if (data["TowerName"]!= null)
                            {
                                TowerName = data["TowerName"].ToString();
                                BaseTower.TowerName = TowerName;
                                BaseTower.TowerPosition._savePath = data["SavePath"].ToString();
                            }
                            temp = int.TryParse(data["Level"].ToString(), out int result);
                            if (temp)
                            {
                                towerJsonData.TowerName = TowerName;
                                towerJsonData.Level = result;
                                towerJsonData.Type = (int)towerType;
                                ChangeColor(Color.black);

                                 BuildSuccess(BaseTower);
                                BaseTower.ResetTowerScale(transform);
                                 currentTriggerObj = null;
                            }
                            EventDispatcher.TriggerEvent(EventName.RefreshPathEvent);
                        }
                        else
                        {
                            Debug.LogError("something errors +  " + gameObject.name);
                        }
                    }
                }
                
            }
        }

        /// <summary>
        /// 设置点的缩放
        /// </summary>
        /// <param name="scale"></param>
        public void SetPointScale(int scale)
        {
            transform.localScale = Vector3.one;
            transform.localScale = new Vector3(scale, 0.3f, scale);
            
        }
    }
}