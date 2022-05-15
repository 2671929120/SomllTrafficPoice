using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FailPop : BasePanel
{
    private Button backBtn;
    private Button againBtn;
    private Text txtDes;
    private Image imgIcon;
    public override void OnConfig()
    {
        base.OnConfig();
        panelConfig = new PanelConfig
        {
            resName = "GameFailPop",
            layer = PanelManager.Layer.Pop,
            panel = "GameFailPop",
        };
    }

    public override void OnInit()
    {
        base.OnInit();
        //结束界面暂停游戏
        Time.timeScale = 0;
        backBtn = skinRoot.gameObject.transform.Find("backBtn").GetComponent<Button>();
        againBtn = skinRoot.gameObject.transform.Find("againBtn").GetComponent<Button>();
        txtDes = skinRoot.gameObject.transform.Find("txtDse").GetComponent<Text>();
        imgIcon = skinRoot.gameObject.transform.Find("Image/imgIcon").GetComponent<Image>();

        backBtn.onClick.AddListener(BackBtnClick);
        againBtn.onClick.AddListener(AgainBtnClick);
    }

    public override void OnShow(params object[] para)
    {
        base.OnShow(para);
        if (para == null) return;
        string textDes = para[0].ToString();
        txtDes.text = textDes;
        if (para.Length == 2)
        {
            imgIcon.gameObject.SetActive(false);
        }
        

    }

    private void AgainBtnClick()
    {
        PanelManager.Close("FailPop");
       
        //SceneManager.LoadScene("GameMain");
        //SceneManager.LoadScene("GameMain"); SceneManager.GetSceneByName("GameMain"); 
        GameManager.Instance.GameAgain();
        SceneManager.LoadScene("GameMain");
        Time.timeScale = 1;
        TimeTool.Instance.Delay(0.5f, () =>
        {
            EventManager.Instance.TriggerEvent(ClientEvent.GAMESTART);
        });
    }

    private void BackBtnClick()
    {
        SceneManager.LoadScene("GameStart");
        PanelManager.Close("GameMainPanel");
        PanelManager.Close("FailPop");
        PanelManager.Open<GameStartPanel>();
        Time.timeScale = 1;
    }


    public override void OnClose()
    {
        base.OnClose();

    }
}
