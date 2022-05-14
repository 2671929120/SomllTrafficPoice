using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroducePop : BasePanel
{
    public Button closeBtn;
    public override void OnConfig()
    {
        base.OnConfig();
        panelConfig = new PanelConfig
        {
            resName = "IntroducePop",
            layer = PanelManager.Layer.Pop,
            panel = "IntroducePop",
        };
    }

    public override void OnInit()
    {
        base.OnInit();
      
        closeBtn = skinRoot.gameObject.transform.Find("CloseBtn").GetComponent<Button>();
        closeBtn.onClick.AddListener(() =>
        {
            PanelManager.Close("IntroducePop");
        });

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
