using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMainPanel : BasePanel
{
    private Text souceTest;
    private Button changeViewButton;
    public override void OnConfig()
    {
        base.OnConfig();
        panelConfig = new PanelConfig
        {
            resName = "GameMainPanel",
            layer = PanelManager.Layer.Panel,
            panel = "GameMainPanel",
        };
    }

    public override void OnInit()
    {
        base.OnInit();

        souceTest = skinRoot.gameObject.transform.Find("Text").GetComponent<Text>();
        changeViewButton = skinRoot.gameObject.transform.Find("ChangeView").GetComponent<Button>();
        changeViewButton.onClick.AddListener(ViewChange);

        EventManager.Instance.AddEvent(ClientEvent.SOUCECHANGE, SouceChange);
    }

    public override void OnShow(params object[] para)
    {
        base.OnShow(para);
       
    }

    public override void OnClose()
    {
        base.OnClose();
        EventManager.Instance.RemoveEvent(ClientEvent.SOUCECHANGE, SouceChange);
    }

    public void SouceChange()
    {
        Debug.Log("现在的分数是" + GameManager.Instance.GameSouce);
        souceTest.text = "分数：" + GameManager.Instance.GameSouce;
    }

    public void ViewChange()
    {
        EventManager.Instance.TriggerEvent(ClientEvent.CAMERACHANGE);
    }
}
