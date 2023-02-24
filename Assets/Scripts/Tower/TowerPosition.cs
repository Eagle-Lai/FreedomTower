using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FTProject
{
    public class TowerPosition : MonoBehaviour
    {

        Vector3 cubeScreenPos;


        private float yPos = 1.6f;

        Transform parent;

        public List<BasePoint> enterNodeList = new List<BasePoint>();
        public bool isBuild = false;
        public TowerBuildState TowerBuildState;
        private void Awake()
        {
            TowerBuildState = TowerBuildState.None;
            parent = transform.parent.GetComponent<Transform>();
            EventDispatcher.AddEventListener(EventName.UpdateEvent, MyUpdate);
        }

        private void Start()
        {
            EventDispatcher.TriggerEvent(EventName.BuildingTower);
        }

        public void OnDestroy()
        {
            EventDispatcher.RemoveEventListener(EventName.UpdateEvent, MyUpdate);
        }

        private void MyUpdate()
        {
            if (isBuild == false)
            {
                cubeScreenPos = Camera.main.WorldToScreenPoint(parent.position);

                //2. ����ƫ����
                //������ά����
                Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cubeScreenPos.z);
                //�����ά����תΪ��������
                mousePos = Camera.main.ScreenToWorldPoint(mousePos);
                //Ŀǰ������ά����תΪ��ά����
                Vector3 curMousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, cubeScreenPos.z);
                //Ŀǰ�������ά����תΪ��������
                curMousePos = Camera.main.ScreenToWorldPoint(curMousePos);
                //��������λ��
                parent.position = new Vector3(curMousePos.x, GlobalConst.UnbuildYPosition, curMousePos.z);
            }
            if ((Input.GetMouseButtonUp(0)) && isBuild == false && BuildTower())
            {
                this.transform.localPosition = new Vector3(0, -1.5f, 0);
                TowerBuildState = TowerBuildState.Build;
                isBuild = true;
                EventDispatcher.TriggerEvent(EventName.UpdateAStarPath);
            }
        }

        public bool BuildTower()
        {
            if (enterNodeList != null)
            {
                for (int i = 0; i < enterNodeList.Count; i++)
                {
                    Color color = enterNodeList[i].GetNodeColor();
                    if (color == Color.green && !enterNodeList[i].IsHaveBuild)
                    {
                        BasePoint point = enterNodeList[i];
                        //node.node.MarkAsObstacle(false);
                        //List<Node> nodes = GridManager.Instance.GetPath();
                        //if (nodes == null)
                        //{
                        //    node.node.MarkAsObstacle();
                        //    return false;
                        //}
                        point.Point.IsWall = true;
                        bool isFind = AStarManager.Instance.IsFindPath();
                        if (!isFind)
                        {
                            point.Point.IsWall = false;
                            BuildFail();
                            return false;
                        }
                        parent.transform.position = enterNodeList[i].transform.position + new Vector3(0, GlobalConst.BuildYPosition, 0);
                        enterNodeList.Clear();
                        BasePoint node = point.transform.GetComponent<BasePoint>();
                        node.BuildSuccess();
                        BuildSuccess();
                        return true;
                    }
                }
            }
            BuildFail();
            return false;
        }

        private void BuildFail()
        {
            EventDispatcher.TriggerEvent(EventName.BuildNormalTower, enterNodeList);
            Destroy(parent.gameObject);
        }

        private void BuildSuccess()
        {
            EventDispatcher.TriggerEvent(EventName.BuildTowerSuccess);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name.Contains("NormalPoint") && isBuild == false)
            {
                BasePoint node = other.transform.GetComponent<BasePoint>();
                if (node != null && enterNodeList != null)
                {
                    enterNodeList.Add(node);
                }
            }
        }

        private void OnTriggerExit(Collider other)
        {
            BasePoint node = other.transform.GetComponent<BasePoint>();
            if (node != null)
            {
                enterNodeList.Remove(node);
            }
        }

    }
}