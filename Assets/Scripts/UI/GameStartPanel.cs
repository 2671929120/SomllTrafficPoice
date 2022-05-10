using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

   class GameStartPanel : BasePanel
    {

        private Text souceTest;
        private Button StartBtn;
        private Button IntroduceBtn;
        private Button SettingBtn;
        public override void OnConfig()
        {
            base.OnConfig();
            panelConfig = new PanelConfig
            {
                resName = "GameStartPanel",
                layer = PanelManager.Layer.Panel,
                panel = "GameStartPanel",
            };
        }

        public override void OnInit()
        {
            base.OnInit();

            souceTest = skinRoot.gameObject.transform.Find("Text").GetComponent<Text>();
            StartBtn = skinRoot.gameObject.transform.Find("btnStart").GetComponent<Button>();
            IntroduceBtn = skinRoot.gameObject.transform.Find("btnStart").GetComponent<Button>();
            SettingBtn = skinRoot.gameObject.transform.Find("btnStart").GetComponent<Button>();
            StartBtn.onClick.AddListener(StartGame);
            IntroduceBtn.onClick.AddListener(IntroduceBtnClick);
            SettingBtn.onClick.AddListener(SettingBtnClick);
        }

        public override void OnShow(params object[] para)
        {
            base.OnShow(para);

        }

        /// <summary>
        /// 游戏开始
        /// </summary>
        private void StartGame()
        {
        //跳转到选择界面 
        //  PanelManager.Open("ChoosePanel");

        }
        /// <summary>
        /// 介绍游戏
        /// </summary>
        private void IntroduceBtnClick()
        {

        }

        /// <summary>
        /// 游戏设置
        /// </summary>
        private void SettingBtnClick()
        {

        }

        public override void OnClose()
        {
            base.OnClose();

        }



    }
