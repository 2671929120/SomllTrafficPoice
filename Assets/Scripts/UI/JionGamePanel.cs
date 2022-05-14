using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JionGamePanel : BasePanel
{
    private AsyncOperation async = null;
    private Text textTips;
    private float progerssValue;
    private Slider slider;
    private int LevelNum;
    public override void OnConfig()
    {
        base.OnConfig();
        panelConfig = new PanelConfig
        {
            resName = "JionGamePanel",
            layer = PanelManager.Layer.Panel,
            panel = "JionGamePanel",
        };
    }

    public override void OnInit()
    {
        base.OnInit();

        textTips = skinRoot.gameObject.transform.Find("txtTips").GetComponent<Text>();
        slider = skinRoot.gameObject.transform.Find("ProcessSlider").GetComponent<Slider>();

        //SettingBtn.onClick.AddListener(SettingBtnClick);
    }

    public override void OnShow(params object[] para)
    {
        base.OnShow(para);
        textTips.text = "";
        if (para == null) return;
        LevelNum = int.Parse(para[0].ToString());

        StartCoroutine("LoadScene");
   


    }

    IEnumerator LoadScene()
    {
        async = SceneManager.LoadSceneAsync("GameMain");
        async.allowSceneActivation = false;
        while (!async.isDone)
        {
            if (async.progress < 0.9f)
            {
                progerssValue = async.progress;
            }
            else
            {
                progerssValue = 1f;
            }

            slider.value = progerssValue;
            textTips.text = (int)(slider.value * 100) + "%";
            if (progerssValue >= 0.9f)
            {
                textTips.text = "点击屏幕进入游戏";
                if (Input.anyKey)
                {
                    async.allowSceneActivation = true;
                    PanelManager.Open<GameMainPanel>(LevelNum);
                    PanelManager.Close("JionGamePanel");
                }
                  

            }
            yield return null;
        }
    }
    



    public override void OnClose()
    {
        base.OnClose();

    }
}
