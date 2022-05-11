
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

    class GameMain:MonoBehaviour
    {
        public static string id = "";
        private List<Action> _updateList;

        private static GameMain _instance;

 
        public static GameMain Instance => _instance;
        public ArrayList List = new ArrayList();
        private void Start()
        {   
            _instance = GetComponent<GameMain>();           
            Debug.Log("开始加载");
            PanelManager.Init();
            DontDestroyOnLoad(PanelManager.root);

            PanelManager.Open<GameMainPanel>();
            //PanelManager.Open<GameStartPanel>();

         }

   

        private void Update()
        {
         
          
        }
        public void AddUpdate(Action call)
        {
            if (null == call)
            {
                return;
            }

            if (_updateList.IndexOf(call) >= 0)
            {
                return;
            }

            _updateList.Add(call);
        }

        public void RemoveUpdate(Action call)
        {
            if (_updateList.IndexOf(call) < 0)
            {
                return;
            }

            _updateList.Remove(call);
        }

     
    }

