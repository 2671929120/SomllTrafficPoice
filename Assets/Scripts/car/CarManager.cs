using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MoveType
{
    Move,
    Stop
}
/// <summary>
/// 汽车模型类型
/// </summary>
public enum CarMode
{
    jipuche,
    qiche,
    qiaoche,
    //....
}
/// <summary>
/// 汽车在哪里 对应的类型
/// 12种类型
/// </summary>
public enum CarType
{
    //西方
    WestRight = 1,
    WestLeft = 2,
    WestMiddle = 3 ,
    //北方
    NorthRight = 4,
    NorthLeft = 5,
    NorthMiddle =6,
    //东方
    EastRight = 7,
    EastLeft = 8,
    EastMiddle = 9,
    //南方
    SouthRight = 10,
    SouthLeft = 11,
    SouthMiddle =12,

}
public class CarManager : Singleton<CarManager>
{
    //存错所有的汽车并且管理
    //总计有四条道路
    //记录汽车数据
    public List<CarBase> WestRightList = new List<CarBase>();
    public List<CarBase> WestLeftList = new List<CarBase>();
    public List<CarBase> WestMiddleList = new List<CarBase>();  
    public List<CarBase> NorthRightList = new List<CarBase>();
    public List<CarBase> NorthLeftList = new List<CarBase>();
    public List<CarBase> NorthMiddleList = new List<CarBase>();  
    public List<CarBase> EastRightList = new List<CarBase>();
    public List<CarBase> EastLeftList = new List<CarBase>();
    public List<CarBase> EastMiddleList = new List<CarBase>();   
    public List<CarBase> SouthRightList = new List<CarBase>();
    public List<CarBase> SouthLeftList = new List<CarBase>();
    public List<CarBase> SouthMiddleList = new List<CarBase>();

    public delegate void CarMove();
    public delegate void CarStop();
    public event CarMove WestRightMoveEvent;
    public event CarMove WestLeftMoveEvent;
    public event CarMove WestMiddleMoveEvent;



    public event CarMove NorthRightMoveEvent;
    public event CarMove NorthLeftMoveEvent;
    public event CarMove NorthMiddleMoveEvent;

    public event CarMove EastRightMoveEvent;
    public event CarMove EastLeftMoveEvent;
    public event CarMove EastMiddleMoveEvent;

    public event CarStop SouthRightMoveEvent;
    public event CarStop SouthLeftMoveEvent;
    public event CarStop SouthMiddleMoveEvent;

    public event CarStop WestRightStopEvent;
    public event CarStop WestLeftStopEvent;
    public event CarStop WestMiddleStopEvent;

    public event CarStop NorthRightStopEvent;
    public event CarStop NorthLeftStopEvent;
    public event CarStop NorthMiddleStopEvent;

    public event CarStop EastRightStopEvent;
    public event CarStop EastLeftStopEvent;
    public event CarStop EastMiddleStopEvent;

    public event CarStop SouthRightStopEvent;
    public event CarStop SouthLeftStopEvent;
    public event CarStop SouthMiddleStopEvent;

    #region 移动事件触发
    public void WestRightMoveEventStart()
    {
        if (WestRightList.Count > 0)
        {
            WestRightList[0].Move();
        }
    }
    public void WestLeftMoveEventStart()
    {
        if (WestLeftList.Count > 0)
        {
            WestLeftList[0].Move();
        }
    }
    public void WestMiddleMoveEventStart()
    {
        if (WestMiddleList.Count > 0)
        {
            WestMiddleList[0].Move();
        }      
    } public void EastRightMoveEventStart()
    {
        if (EastRightList.Count > 0)
        {
            EastRightList[0].Move();
        }
    }
    public void EastLeftMoveEventStart()
    {
        if (EastLeftList.Count > 0)
        {
            EastLeftList[0].Move();
        }
    }
    public void EastMiddleMoveEventStart()
    {
        if (EastMiddleList.Count > 0)
        {
            EastMiddleList[0].Move();
        }      
    } public void NorthRightMoveEventStart()
    {
        if (NorthRightList.Count > 0)
        {
            NorthRightList[0].Move();
        }
    }
    public void NorthLeftMoveEventStart()
    {
        if (NorthLeftList.Count > 0)
        {
            NorthLeftList[0].Move();
        }
    }
    public void NorthMiddleMoveEventStart()
    {
        if (NorthMiddleList.Count > 0)
        {
            NorthMiddleList[0].Move();
        }      
    } public void SouthRightMoveEventStart()
    {
        if (SouthRightList.Count > 0)
        {
            SouthRightList[0].Move();
        }
    }
    public void SouthLeftMoveEventStart()
    {
        if (SouthLeftList.Count > 0)
        {
            SouthLeftList[0].Move();
        }
    }
    public void SouthMiddleMoveEventStart()
    {
        if (SouthMiddleList.Count > 0)
        {
            SouthMiddleList[0].Move();
        }      
    }

   
    #endregion 

    #region 停止事件触发
    public void WestRightStopEventStart()
    {
       // WestRightStopEvent?.Invoke();
    }
    public void WestLeftStopEventStart()
    {
       // WestLeftStopEvent?.Invoke();
    }
    public void WestMiddleStopEventStart()
    {
        //for (int i = ShouldWestMiddleList.Count - 1; i >= 0; i--)
        //{
        //    if (WestMiddleList.Contains(ShouldWestMiddleList[i]))
        //    {
        //        Debug.Log("有类似开始移除");
        //        WestMiddleList.Remove(ShouldWestMiddleList[i]);
        //        ShouldWestMiddleList.Remove(ShouldWestMiddleList[i]);
        //    }
        //}
       // TimeTool.Instance.StopCoroutine(StartWestMiddle());
       
       // WestMiddleStopEvent?.Invoke();
    }

    public void NorthRightStopEventStart()
    {
       // NorthRightStopEvent?.Invoke();
    }
    public void NorthLeftStopEventStart()
    {
       // NorthLeftStopEvent?.Invoke();
    }
    public void NorthMiddleStopEventStart()
    {

       // NorthMiddleStopEvent?.Invoke();
    }
    public void EastRightStopEventStart()
    {
       // EastRightStopEvent?.Invoke();
    }
    public void EastLeftStopEventStart()
    {
     //   EastLeftStopEvent?.Invoke();
    }
    public void EastMiddleStopEventStart()
    {
      //  EastMiddleStopEvent?.Invoke();
    }
    public void SouthRightStopEventStart()
    {
       // SouthRightStopEvent?.Invoke();
    }
    public void SouthLeftStopEventStart()
    {
      //  SouthLeftStopEvent?.Invoke();
    }    
    public void SouthMiddleStopEventStart()
    {
      //  SouthMiddleStopEvent?.Invoke();
    }
    #endregion

   /// <summary>
   /// 汽车的销毁
   /// </summary>
   /// <param name="carType"></param>
   /// <param name="carBase"></param>
    public void DestoryCar(CarType carType, CarBase carBase)
    {
        bool lastone = false;
        switch (carType)
        {
            case CarType.WestLeft:
                {
                    WestLeftList.Remove(carBase);
                    GameManager.Instance.WestLeftListCount -= 1;
                    lastone = GameManager.Instance.WestLeftListCount == 0;
                    break;
                }
            case CarType.WestRight:
                {
                    WestRightList.Remove(carBase);
                    GameManager.Instance.WestRightListCount -= 1;
                    lastone = GameManager.Instance.WestRightListCount == 0;
                    break;
                } 
            case CarType.WestMiddle:
                {
                    WestMiddleList.Remove(carBase);
                    GameManager.Instance.WestMiddleListCount -= 1;
                    lastone = GameManager.Instance.WestMiddleListCount == 0;
                    break;
                } 
            case CarType.SouthLeft:
                {
                    SouthLeftList.Remove(carBase);
                    GameManager.Instance.SouthLeftListCount -= 1;
                    lastone = GameManager.Instance.SouthLeftListCount == 0;
                    break;
                }
            case CarType.SouthRight:
                {
                    SouthRightList.Remove(carBase);
                    GameManager.Instance.SouthRightListCount -= 1;
                    lastone = GameManager.Instance.SouthRightListCount == 0;
                    break;
                } 
            case CarType.SouthMiddle:
                {
                    SouthMiddleList.Remove(carBase);
                    GameManager.Instance.SouthMiddleListCount -= 1;
                    lastone = GameManager.Instance.SouthMiddleListCount == 0;
                    break;
                }
            case CarType.EastLeft:
                {
                    EastLeftList.Remove(carBase);
                    GameManager.Instance.EastLeftListCount -= 1;
                    lastone = GameManager.Instance.EastLeftListCount == 0;
                    break;
                }
            case CarType.EastRight:
                {
                    EastRightList.Remove(carBase);
                    GameManager.Instance.EastRightListCount -= 1;
                    lastone = GameManager.Instance.EastRightListCount == 0;
                    break;
                } 
            case CarType.EastMiddle:
                {
                    EastMiddleList.Remove(carBase);
                    GameManager.Instance.EastMiddleListCount -= 1;
                    lastone = GameManager.Instance.EastMiddleListCount == 0;
                    break;
                }
            case CarType.NorthLeft:
                {
                    NorthLeftList.Remove(carBase);
                    GameManager.Instance.NorthLeftListCount -= 1;
                    lastone = GameManager.Instance.NorthLeftListCount == 0;
                    break;
                }
            case CarType.NorthRight:
                {
                    NorthRightList.Remove(carBase);
                    GameManager.Instance.NorthRightListCount -= 1;
                    lastone = GameManager.Instance.NorthRightListCount == 0;
                    break;
                } 
            case CarType.NorthMiddle:
                {
                    NorthMiddleList.Remove(carBase);
                    GameManager.Instance.NorthMiddleListCount -= 1;
                    lastone = GameManager.Instance.NorthMiddleListCount == 0;
                    break;
                }
        }
        if (lastone)
        {
            GameManager.Instance.AddGameSouce(100);
        }
        else
        {
            GameManager.Instance.AddGameSouce(5);
        }
    }
    public List<CarBase> ShouldWestRightList = new List<CarBase>();
    public List<CarBase> ShouldWestLeftList = new List<CarBase>();
    public List<CarBase> ShouldWestMiddleList = new List<CarBase>();
    public List<CarBase> ShouldNorthRightList = new List<CarBase>();
    public List<CarBase> ShouldNorthLeftList = new List<CarBase>();
    public List<CarBase> ShouldNorthMiddleList = new List<CarBase>();
    public List<CarBase> ShouldEastRightList = new List<CarBase>();
    public List<CarBase> ShouldEastLeftList = new List<CarBase>();
    public List<CarBase> ShouldEastMiddleList = new List<CarBase>();
    public List<CarBase> ShouldSouthRightList = new List<CarBase>();
    public List<CarBase> ShouldSouthLeftList = new List<CarBase>();
    public List<CarBase> ShouldSouthMiddleList = new List<CarBase>();
    /// <summary>
    /// 汽车的销毁
    /// </summary>
    /// <param name="carType"></param>
    /// <param name="carBase"></param>
    public void ShouldDestoryCar(CarType carType, CarBase carBase)
    {
        switch (carType)
        {
            case CarType.WestLeft:
                {
                    ShouldWestLeftList.Add(carBase);
                    break;
                }
            case CarType.WestRight:
                {
                    ShouldWestRightList.Add(carBase);
                    break;
                } 
            case CarType.WestMiddle:
                {
                    ShouldWestMiddleList.Add(carBase);
                    break;
                } 
            case CarType.SouthLeft:
                {
                    ShouldSouthLeftList.Add(carBase);
                    break;
                }
            case CarType.SouthRight:
                {
                    ShouldSouthRightList.Add(carBase);
                    break;
                } 
            case CarType.SouthMiddle:
                {
                    ShouldSouthMiddleList.Add(carBase);
                    break;
                }
            case CarType.EastLeft:
                {
                    ShouldEastLeftList.Add(carBase);
                    break;
                }
            case CarType.EastRight:
                {
                    ShouldEastRightList.Add(carBase);
                    break;
                } 
            case CarType.EastMiddle:
                {
                    ShouldEastMiddleList.Add(carBase);
                    break;
                }
            case CarType.NorthLeft:
                {
                    ShouldNorthLeftList.Add(carBase);
                    break;
                }
            case CarType.NorthRight:
                {
                    ShouldNorthRightList.Add(carBase);
                    break;
                } 
            case CarType.NorthMiddle:
                {
                    ShouldNorthMiddleList.Add(carBase);
                    break;
                }
        }
    }

}
