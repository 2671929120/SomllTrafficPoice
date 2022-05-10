using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoosePanel : BasePanel
{
    private Button ChooseBtn1;
    private Button ChooseBtn2;
    
    public override void OnConfig()
    {
        base.OnConfig();
        panelConfig = new PanelConfig
        {
            resName = "ChoosePanel",
            layer = PanelManager.Layer.Panel,
            panel = "ChoosePanel",
        };
    }

    public override void OnInit()
    {
        base.OnInit();

        ChooseBtn1= skinRoot.gameObject.transform.Find("btn2D").GetComponent<Button>();
        ChooseBtn2= skinRoot.gameObject.transform.Find("btn3D").GetComponent<Button>();

        ChooseBtn1.onClick.AddListener(ChooseBtn1Click);
        ChooseBtn2.onClick.AddListener(ChooseBtn2Click);
    }

    public override void OnShow(params object[] para)
    {
        base.OnShow(para);

    }

    private void ChooseBtn1Click()
    {

    }
      
    private void ChooseBtn2Click()
    {
        PanelManager.Open<JionGamePanel>();
        PanelManager.Close("ChoosePanel");
        PanelManager.Close("GameStartPanel");
    }


    public override void OnClose()
    {
        base.OnClose();

    }
}
