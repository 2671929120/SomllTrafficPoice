using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    //这里去管理游戏的整个数据类
    public int WestRightListCount = 10;
    public int WestLeftListCount = 10;
    public int WestMiddleListCount = 10;
    public int NorthRightListCount = 10;
    public int NorthLeftListCount = 10;
    public int NorthMiddleListCount = 10;
    public int EastRightListCount = 10;
    public int EastLeftListCount = 10;
    public int EastMiddleListCount = 10;
    public int SouthRightListCount = 10;
    public int SouthLeftListCount = 10;
    public int SouthMiddleListCount = 10;

    public int GameSouce =0;
    public bool CanTouch = true;
    public float CameraAnlgle;
    public bool GameOver;
    internal List<GameObject> TipsList =new List<GameObject>();
    internal int CameTime=0;
    public int GameStap = 0;
    internal int GameLevel;

    public void AddGameSouce(int num)
    {
        GameSouce += num;
        EventManager.Instance.TriggerEvent(ClientEvent.SOUCECHANGE);
    }

    public void  GameDataInit(int num)
    {
        GameStap = num;
    }


    public void GameAgain()
    {
        GameSouce = 0;
        CanTouch = true;
        GameOver = false;
        TipsList = new List<GameObject>();
        CameTime = 0;
        TimeTool.Instance.StopAllCoroutines();
        EventManager.Instance.TriggerEvent(ClientEvent.SOUCECHANGE);
        if (TipsList.Count > 0)
        {
            for (int i = TipsList.Count - 1; i >= 0; i--)
            {
                TipsList[i].transform.gameObject.SetActive(false);
                TipsList.RemoveAt(i);

            }

        }
    }

}
