
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


     public static class PanelManager
    {
        public enum Layer
        {
            Panel,
            Pop,
            Tip
        }

        //层级列表
        private static Dictionary<Layer, Transform> layers = new Dictionary<Layer, Transform>();
        //面板列表
        public static Dictionary<string, BasePanel> panels = new Dictionary<string, BasePanel>();
        //结构 
        public static Transform root;
        public static Transform canvas;
        //初始化
        public static void Init()
        {
            root = GameObject.Find("UIRoot").transform;
           
            canvas = root.Find("Canvas");
            Transform panel = canvas.Find("Panel");
          //  panel.SetAsFirstSibling();
            Transform pop = canvas.Find("Pop");
           // pop.SetAsLastSibling();
            Transform tip = canvas.Find("Tip");
     
            layers.Add(Layer.Panel, panel);
            layers.Add(Layer.Pop, pop);
            layers.Add(Layer.Tip, tip);
        }

        //打开面板
        public static void Open<T>(params object[] param) where T : BasePanel
        {
            //是否已经打开
            string name = typeof(T).ToString();
            string[] split = name.Split('.');
            name = split[split.Length - 1];
            if (panels.ContainsKey(name))
            {
                return;
            }
            //组件
            BasePanel panel = root.gameObject.AddComponent<T>();
            panel.OnConfig();
            panel.Init();
            panel.OnInit();
            
            //父容器
            Transform layer = layers[panel.panelConfig.layer];
            panel.skinRoot.transform.SetParent(layer, false);
            //列表
            panels.Add(name, panel);
            //OnShow
            panel.OnShow(param);



        }
       /// <summary>
       /// 关闭面板 
       /// </summary>
       /// <param name="name"></param>
        public static void Close(string name)
        {
            //面板没有打开

            if (!panels.ContainsKey(name))
            {
                return;
            }

            BasePanel panel = panels[name];
            panels.Remove(name);
            panel.OnClose();

            //销毁
            GameObject.Destroy(panel.skinRoot);
            Component.Destroy(panel);

        }

        public static void CloseAll(Layer layer)
        {
            Transform layerobj = layers[layer];
        int i = 0;
        while (i < layerobj.childCount)
        {
           // layerobj.gameObject.Destroy (layerobj.GetChild(i++).gameObject);
        }
       }
        /// <summary>
        /// 现实提示信息
        /// </summary>
        /// <param name="text"></param>
        public static void TipsShow(string text)
        {
            //Open<Tips>(text);
        } 
        public static void TipsPopShow(string text)
        {
          //  Open<TipsPop>(text);
        }



    }

