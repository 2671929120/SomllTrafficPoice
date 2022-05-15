using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMainPanel : BasePanel
{
    private Text souceTest;
    private Button changeViewButton;
    private Button TestBtn;
    private Text txtTime;
    private Text txtStap;
    private Text txtLevel;

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
        txtLevel = skinRoot.gameObject.transform.Find("txtLevel").GetComponent<Text>();
        txtStap = skinRoot.gameObject.transform.Find("txtStap").GetComponent<Text>();
        txtTime = skinRoot.gameObject.transform.Find("txtTime").GetComponent<Text>();
        changeViewButton = skinRoot.gameObject.transform.Find("ChangeView").GetComponent<Button>();
        TestBtn = skinRoot.gameObject.transform.Find("TestBtn").GetComponent<Button>();
        imgJianTou = skinRoot.gameObject.transform.Find("Image/imgJiantou").GetComponent<Image>();
        changeViewButton.onClick.AddListener(ViewChange);
        TestBtn.onClick.AddListener(TestBtnClick);

        EventManager.Instance.AddEvent(ClientEvent.SOUCECHANGE, SouceChange);
        EventManager.Instance.AddEvent<float>(ClientEvent.CAMERAANGLE, ImgChange);

        EventManager.Instance.AddEvent<string>(ClientEvent.TIPSSHOW, TipsShow);
        EventManager.Instance.AddEvent(ClientEvent.TIMESHOW,TimeShow); 
        EventManager.Instance.AddEvent(ClientEvent.GAMEOVER,GameOver);
        EventManager.Instance.AddEvent(ClientEvent.STAPCHANGE,StapChange);
        EventManager.Instance.AddEvent(ClientEvent.CHACKVICTORY,CheckVictory);

    }
    /// <summary>
    /// paras 
    /// 关卡第几关
    /// </summary>
    /// <param name="para"></param>
    public override void OnShow(params object[] para)
    {
        base.OnShow(para);
        if (para == null) return;
        int LevelNum = int.Parse(para[0].ToString());
        GameManager.Instance.GameLevel = LevelNum;
        txtLevel.text = "关卡" + LevelNum;
        souceTest.text = "分数:" + GameManager.Instance.GameSouce;
       // EventManager.Instance.TriggerEvent(ClientEvent.GAMESTART);
        TimeTool.Instance.Delay(0.5f, () =>
        {
           EventManager.Instance.TriggerEvent(ClientEvent.GAMESTART);
        } );

       
    }

    public override void OnClose()
    {
        base.OnClose();
        EventManager.Instance.RemoveEvent(ClientEvent.SOUCECHANGE, SouceChange);
        EventManager.Instance.RemoveEvent<float>(ClientEvent.CAMERAANGLE, ImgChange);

        EventManager.Instance.RemoveEvent<string>(ClientEvent.TIPSSHOW, TipsShow);
        EventManager.Instance.RemoveEvent(ClientEvent.TIMESHOW, TimeShow);
        EventManager.Instance.RemoveEvent(ClientEvent.GAMEOVER, GameOver);
        EventManager.Instance.RemoveEvent(ClientEvent.STAPCHANGE, StapChange);
    }


    private void CheckVictory()
    {
        GameManager.Instance.AllCarCount -= 1;
        if (GameManager.Instance.AllCarCount == 0)
        {
            PanelManager.Open<GameVictorylPop>();
        }
    }
    private void GameOver()
    {
       
    }

    private void StapChange()
    {
        txtStap.text ="剩余步数:"+ GameManager.Instance.GameStap.ToString();
    }

    private void TimeShow()
    {
        txtTime.text = GameManager.Instance.CameTime.ToString();
    }
    public void SouceChange()
    {
        Debug.Log("现在的分数是" + GameManager.Instance.GameSouce);
        souceTest.text = "分数:" + GameManager.Instance.GameSouce;
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
