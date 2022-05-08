using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    class SouceTips: BasePanel
    {
        private Text souceText;
        public override void OnConfig()
        {
            base.OnConfig();
            panelConfig = new PanelConfig
            {
                resName = "SouceTips",
                layer = PanelManager.Layer.Tip,
                panel = "SouceTips",
            };
        }

        public override void OnInit()
        {
            base.OnInit();
            souceText = skinRoot.transform.Find("souceText").GetComponent<Text>();
        }
        public override void OnShow(params object[] para)
        {
            base.OnShow(para);
            //通过传来的位置来决定text的位置
            Vector3 pos = (Vector3)para[0];
            

            souceText.transform.position = pos;
        }

        public override void OnClose()
        {
            base.OnClose();
        }


    }
}
