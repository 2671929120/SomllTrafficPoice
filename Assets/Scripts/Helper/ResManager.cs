using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


    public class ResManager
    {
        /// <summary>
        ///加载UI预制体
        /// </summary>
        /// <param path"path">路径名称</param>
        /// <returns></returns>
        public static  GameObject LoadUIPrefab(string path)
        {
            GameObject gameObject = Resources.Load<GameObject>("UI/" + path);
            if(gameObject == null)
            {
                Debug.Log("加载路径或文件名有误请检查"+path);
            }

            return gameObject;
        }
        
        public static  GameObject LoadPrefab(string path)
        {
            GameObject gameObject = Resources.Load<GameObject>(path);
            if (gameObject == null)
            {
                Debug.Log("加载路径或文件名有误请检查");
            }

            return gameObject;
        }
        public static  GameObject[] LoadAllPrefab(string path)
        {
            GameObject[] gameObjects = Resources.LoadAll<GameObject>(path);
            if (gameObjects == null)
            {
                Debug.Log("加载路径或文件名有误请检查");
            }

            return gameObjects;
        }

    }

