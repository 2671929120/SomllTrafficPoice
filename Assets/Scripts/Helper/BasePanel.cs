using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

    public class BasePanel : MonoBehaviour
    {
        //皮肤路径
        // public string skinPath;

        public  PanelConfig panelConfig ;
        //皮肤
        public GameObject skinRoot;
        //层级
      //  public PanelManager.Layer layer = PanelManager.Layer.Panel;

        //初始化配置
        
        //初始化
        public void Init()
        {
            //皮肤
            GameObject skinPrefab = ResManager.LoadUIPrefab(panelConfig.resName);
            skinRoot = (GameObject)Instantiate(skinPrefab);
        }
        //关闭
         public void Close()
        {
            string name = this.GetType().ToString();
            string[] split = name.Split('.');
            name = split[split.Length - 1];
            PanelManager.Close(name);
        }

        public virtual void OnConfig()
        {

        }
        //初始化时
        public virtual void OnInit()
        {

        }
        //显示时
        public virtual void OnShow(params object[] para)
        {
            
        }
        //关闭时
        public virtual void OnClose()
        {

        }

  }
