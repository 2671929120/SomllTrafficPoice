using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;


class LevelPanel : BasePanel
{

    private List<Button> buttons;
    private GameObject Content;
    public override void OnConfig()
    {
        base.OnConfig();
        panelConfig = new PanelConfig
        {
            resName = "LevelPanel",
            layer = PanelManager.Layer.Panel,
            panel = "LevelPanel",
        };
    }

    public override void OnInit()
    {
        base.OnInit();

        buttons = new List<Button>();
        Content = GameObject.Find("ScrollView/Viewport/Content");

        int temp = 0;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (temp >= Config.AllLevelConfig.Count) break;
                GameObject textObj = ResManager.LoadUIPrefab("LevelItem");
                GameObject text = Instantiate(textObj, Content.transform);
                text.transform.localPosition = new Vector3(-500+j *500f, -150+i*-350f, 0);
                Button item = text.transform.GetComponent<Button>();
                item.transform.Find("Text").GetComponent<Text>().text = "关卡" + (temp + 1);
                item.onClick.AddListener(() => {
                    PanelManager.Open<JionGamePanel>(1 + 1);
                    PanelManager.Close("LevelPanel");

                });
                buttons.Add(item);

                temp++;

            }
        }

    }
    public void ItemClick(int num)
    {
        PanelManager.Open<JionGamePanel>(num + 1);
        PanelManager.Close("LevelPanel");
    }

    public override void OnShow(params object[] para)
    {
        base.OnShow(para);
        //读取所有关卡的配置信息，想配置信息对应出来


    }



    public override void OnClose()
    {
        base.OnClose();

    }
}
