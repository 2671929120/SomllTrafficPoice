using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

class GameVictorylPop:BasePanel
{
    private Button backBtn;
    private Button nextBtn;
    private Text txtDes;
    private Image imgIcon;
    public override void OnConfig()
    {
        base.OnConfig();
        panelConfig = new PanelConfig
        {
            resName = "GameVictorylPop",
            layer = PanelManager.Layer.Pop,
            panel = "GameVictorylPop",
        };
    }

    public override void OnInit()
    {
        base.OnInit();
        //结束界面暂停游戏
        Time.timeScale = 0;
        backBtn = skinRoot.gameObject.transform.Find("backBtn").GetComponent<Button>();
        nextBtn = skinRoot.gameObject.transform.Find("nextBtn").GetComponent<Button>();
        txtDes = skinRoot.gameObject.transform.Find("txtDse").GetComponent<Text>();
        imgIcon = skinRoot.gameObject.transform.Find("Image/imgIcon").GetComponent<Image>();

        backBtn.onClick.AddListener(BackBtnClick);
        nextBtn.onClick.AddListener(NextBtnClick);
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

    private void NextBtnClick()
    {
        PanelManager.Close("GameVictorylPop");

        //SceneManager.LoadScene("GameMain");
        //SceneManager.LoadScene("GameMain"); SceneManager.GetSceneByName("GameMain"); 
        GameManager.Instance.GameAgain();
        SceneManager.LoadScene("GameMain");
        if (GameManager.Instance.GameLevel < Config.AllLevelConfig.Count)
        {
            GameManager.Instance.GameLevel += 1;
        }

        Time.timeScale = 1;
    }

    private void BackBtnClick()
    {
        SceneManager.LoadScene("GameStart");
        PanelManager.Close("GameMainPanel");
        PanelManager.Close("GameVictorylPop");
        PanelManager.Open<GameStartPanel>();
        Time.timeScale = 1;
    }


    public override void OnClose()
    {
        base.OnClose();

    }

}
