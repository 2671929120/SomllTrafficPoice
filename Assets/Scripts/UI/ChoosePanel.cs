using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoosePanel : BasePanel
{
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

        //souceTest = skinRoot.gameObject.transform.Find("Text").GetComponent<Text>();

        //SettingBtn.onClick.AddListener(SettingBtnClick);
    }

    public override void OnShow(params object[] para)
    {
        base.OnShow(para);

    }


    public override void OnClose()
    {
        base.OnClose();

    }
}
