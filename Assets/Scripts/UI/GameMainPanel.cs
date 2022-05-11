using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMainPanel : BasePanel
{
    private Text souceTest;
    private Button changeViewButton;
    private Button TestBtn;

    public Image imgJianTou;
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
        TestBtn = skinRoot.gameObject.transform.Find("TestBtn").GetComponent<Button>();
        imgJianTou = skinRoot.gameObject.transform.Find("Image/imgJiantou").GetComponent<Image>();
        changeViewButton.onClick.AddListener(ViewChange);
        TestBtn.onClick.AddListener(TestBtnClick);

        EventManager.Instance.AddEvent(ClientEvent.SOUCECHANGE, SouceChange);
        EventManager.Instance.AddEvent<float>(ClientEvent.CAMERAANGLE, ImgChange);

        EventManager.Instance.AddEvent<string>(ClientEvent.TIPSSHOW, TipsShow);

        
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
    public void ImgChange(float z)
    {
        imgJianTou.transform.localEulerAngles = new Vector3(0, 0, z);
    }

    public void TipsShow(string text)
    {
        GameObject textObj = ResManager.LoadUIPrefab("TipsItem");
        GameObject textmian = Instantiate(textObj, skinRoot.transform.Find("TipsList"));
        Text tipsTxt = textmian.transform.Find("txtTips").GetComponent<Text>();
        tipsTxt.text = text;
        GameManager.Instance.TipsList.Add(textmian);
    }

    public void TestBtnClick()
    {
        TipsShow("注意：北方道路迎来高峰期");
    }
}
