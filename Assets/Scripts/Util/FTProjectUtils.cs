using SimpleJSON;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace FTProject
{
    public static class FTProjectUtils
    {

        public static string StreamingAssetsPathPath
        {
            get
            {
#if UNITY_ANDROID && !UNITY_EDITOR
        return Application.streamingAssetsPath;
#elif UNITY_IPHONE && !UNITY_EDITOR
        return "file://" + Application.streamingAssetsPath;
#elif UNITY_STANDLONE_WIN || UNITY_EDITOR
              return  "file://" + Application.streamingAssetsPath;
#else
        string.Empty;
#endif
            }
        }

        public static string PersistentDataPathJsonPath
        {
            get
            {
              return Path.Combine(Application.persistentDataPath, "MyJson/");
            }
        }

        public static float GetPointDistance(GameObject goA, GameObject goB)
        {
            return Vector2.Distance(new Vector2(goA.transform.position.x, goA.transform.position.z), new Vector2(goB.transform.position.x, goB.transform.position.z));
        }    

        public static float GetPointDistance(Vector3 pos1, Vector3 pos2)
        {
            return Vector2.Distance(new Vector2(pos1.x, pos1.z), new Vector2(pos2.x, pos2.z));
        }
        public static Quaternion GetRotate(Transform transform, GameObject go)
        {
            return Quaternion.LookRotation(new Vector3(transform.position.x - go.transform.position.x, 0, transform.position.z - go.transform.position.z));
        }

        public static Quaternion GetRotate(Vector3 pos1, Vector3 pos2)
        {
            return Quaternion.LookRotation(new Vector3(pos1.x - pos2.x, 0, pos1.z - pos2.z));
        }
           

        public static void SetObjParent(this Transform transform, Transform parent, Vector3 position = default, Vector3 scale = default, Quaternion quaternion = default)
        {
            transform.transform.SetParent(parent);
            transform.transform.localPosition = position;
            transform.transform.localScale = scale;
            transform.transform.localRotation = quaternion;           
        }

        public static void HideObject(this GameObject gameObject)
        {
            gameObject.SetActive(false);
        }

        public static void ShowObject(this GameObject gameObject)
        {
            gameObject.SetActive(true);
        }

        public static void ReadData(string name, Action<JSONNode> action)
        {
            Launcher.Instance.StartCoroutine(ReadFile(name, action));
        }

        //public static JSONNode ReadData(string name, Func<string, JSONNode> func)
        //{

        //}

        private static IEnumerator  ReadFile(string name, Action<JSONNode> action)
        {
            WWW www = new WWW(StreamingAssetsPathPath + "/json/" + name +".json");
            yield return www;
            while (www.isDone == false)
            {
                yield return new WaitForEndOfFrame();
            }
            yield return new WaitForEndOfFrame();
            string data = www.text;
            JSONNode node = JSONNode.Parse(data);
            action(node);
        }

        //public static JSONNode Reader(string name)
        //{
        //    string = 
        //    return JSONNode.Parse()
        //}
    }
}