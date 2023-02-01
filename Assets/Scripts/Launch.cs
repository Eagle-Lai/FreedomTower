/**
Create By LaiZhangYin, Eagle
if you have any question, please call wechat:782966734
**/
using cfg;
using cfg.item;
using SimpleJSON;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace FTProject
{
    public class Launch : MonoBehaviour
    {

        private List<BaseManager> managerList = new List<BaseManager>()
        {
          new EnemyManager(),
          new BulletManager(),
        };

        public static Launch Instance;
        public BaseEnemy baseEnemy;
        private void Awake()
        {
            for (int i = 0; i < managerList.Count; i++)
            {
                managerList[i].OnInit();
            }

            DontDestroyOnLoad(gameObject);
            Instance = this;
            TimerManager.Instance.Update(Time.fixedDeltaTime);
            //AStarPath.Instance.Start();
            //Tables t = new Tables(Reader);
            //Item item = t.TbItem.Get(100010);
            //Debug.Log(item.Desc);
            //Tables table = new Tables(Reader);
            //Equip equip = table.TbEquip.Get(1);
            //Debug.Log(equip.Color);
            UIManager.Instance.OpenView<MainView>("MainView");
        }

        private JSONNode Reader(string fileName)
        {
            return JSON.Parse(File.ReadAllText(Application.dataPath + "/../GenerateDatas/json/" + fileName + ".json"));
        }

        private void Start()
        {

        }

        

        private void OnDrawGizmos()
        {
           
        }
        private void Update()
        {
            TimerManager.Instance.Update(Time.fixedDeltaTime);
        }

    }
}