using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using UnityEditor;
using System;

namespace FTProject
{
    public class JsonDataManager : BaseManager<JsonDataManager>
    {
        public class test
        {
           public string name;
            public string level;
        }


        public override void OnInit()
        {
            base.OnInit();
        }

        public string Write(string name, object data)
        {
            string path = FTProjectUtils.PersistentDataPathJsonPath;

            Debug.Log(path);
            bool isExit = !Directory.Exists(path);
            if (isExit)
            {
                Directory.CreateDirectory(path);
            }
            string array = JsonMapper.ToJson(data);
            string file = path + name + ".json";
            if (!File.Exists(file))
            {
                File.Create(file).Dispose();
            }
            File.WriteAllText(file, array);
            Debug.Log(file);
#if UNITY_EDITOR
            AssetDatabase.Refresh();
#endif
            return file;
        }

        public IEnumerator Read(string name, Action<JsonData> action)
        {
            string path = FTProjectUtils.PersistentDataPathJsonPath + name + ".json";
            WWW www = new WWW(path);
            yield return www;
            while (www.isDone == false)
            {
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForEndOfFrame();
            string data = www.text;
            if (!string.IsNullOrEmpty(data))
            {
                JsonData temp = JsonMapper.ToObject(data);
                action(temp);
            }
        }
        //foreach (JsonData data in jsondata)
        //{
        //    datetest per = new datetest();
        //per.id = data["id"].ToString();
        //per.Chinese = data["Chinese"].ToString();
        //per.English = data["English"].ToString();
        //jsons.Add(per);
        //}

        //private static IEnumerator ReadFile(string name, Action<JSONNode> action)
        //{
        //    WWW www = new WWW(StreamingAssetsPathPath + "/json/" + name + ".json");
        //    yield return www;
        //    while (www.isDone == false)
        //    {
        //        yield return new WaitForEndOfFrame();
        //    }
        //    yield return new WaitForEndOfFrame();
        //    string data = www.text;
        //    JSONNode node = JSONNode.Parse(data);
        //    action(node);
        //}
        public override void OnDestroy()
        {
            base.OnDestroy();
        }


    }
}
