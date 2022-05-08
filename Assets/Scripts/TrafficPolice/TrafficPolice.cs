using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficPolice : MonoBehaviour
{
    public GameObject WiteEastLeft;
    public GameObject WiteEastRight;
    public GameObject WiteEastMiddle;
    public GameObject WiteWestLeft;
    public GameObject WiteWestRight;
    public GameObject WiteWestMiddle;    
    public GameObject WiteNorthLeft;
    public GameObject WiteNorthRight;
    public GameObject WiteNorthMiddle;    
    public GameObject WiteSouthLeft;
    public GameObject WiteSouthRight;
    public GameObject WiteSouthMiddle;

    public Animator animatorPlayer;

    
     void Start()
    {
        EventManager.Instance.AddEvent(ClientEvent.WESTMIDDENMOVE, WestMiddenMove);
        EventManager.Instance.AddEvent(ClientEvent.WESTLEFTMOVE, WestLeftMove);
        EventManager.Instance.AddEvent(ClientEvent.WESTRIGHTMOVE, WestRightMove);
        EventManager.Instance.AddEvent(ClientEvent.EASTMIDDENMOVE, EastMiddenMove);
        EventManager.Instance.AddEvent(ClientEvent.EASTLEFTMOVE, EastLeftMove);
        EventManager.Instance.AddEvent(ClientEvent.EASTRIGHTMOVE, EastRightMove); 
        EventManager.Instance.AddEvent(ClientEvent.SOUTHMIDDENMOVE, SouthMiddenMove);
        EventManager.Instance.AddEvent(ClientEvent.SOUTHLEFTMOVE, SouthLeftMove);
        EventManager.Instance.AddEvent(ClientEvent.SOUTHRIGHTMOVE, SouthRightMove);
        EventManager.Instance.AddEvent(ClientEvent.NORTHMIDDENMOVE, NorthMiddenMove);
        EventManager.Instance.AddEvent(ClientEvent.NORTHLEFTMOVE, NorthLeftMove);
        EventManager.Instance.AddEvent(ClientEvent.NORTHRIGHTMOVE, NorthRightMove);
    }
    public void EastMiddenMove()
    {
        WiteEastMiddle.SetActive(!WiteEastMiddle.activeSelf);
        if (!WiteEastMiddle.activeSelf)
        {
            CarManager.Instance.EastMiddleMoveEventStart();
        }
        else
        {
            CarManager.Instance.EastMiddleStopEventStart();
        }
        
    } 
    public void EastLeftMove()
    {
        WiteEastLeft.SetActive(!WiteEastLeft.activeSelf);
        if (!WiteEastLeft.activeSelf)
        {
            CarManager.Instance.EastLeftMoveEventStart();
        }
        else
        {
            CarManager.Instance.EastLeftStopEventStart();
        }
    } 
    public void EastRightMove()
    {
        WiteEastRight.SetActive(!WiteEastRight.activeSelf);
        if (!WiteEastRight.activeSelf)
        {
            CarManager.Instance.EastRightMoveEventStart();
        }
        else
        {
            CarManager.Instance.EastRightStopEventStart();
        }
    }  
    
    
    public void WestMiddenMove()
    {
        WiteWestMiddle.SetActive(!WiteWestMiddle.activeSelf);
        if (!WiteWestMiddle.activeSelf)
        {
            CarManager.Instance.WestMiddleMoveEventStart();
        }
        else
        {
            CarManager.Instance.WestMiddleStopEventStart();
        }
    } 
    public void WestLeftMove()
    {
        WiteWestLeft.SetActive(!WiteWestLeft.activeSelf);
        if (!WiteWestLeft.activeSelf)
        {
            CarManager.Instance.WestLeftMoveEventStart();
        }
        else
        {
            CarManager.Instance.WestLeftStopEventStart();
        }
    } 
    public void WestRightMove()
    {
        WiteWestRight.SetActive(!WiteWestRight.activeSelf);
        if (!WiteWestRight.activeSelf)
        {
            CarManager.Instance.WestRightMoveEventStart();
        }
        else
        {
            CarManager.Instance.EastRightStopEventStart();
        }
    }  
    
    public void SouthMiddenMove()
    {
        WiteSouthMiddle.SetActive(!WiteSouthMiddle.activeSelf);
        if (!WiteSouthMiddle.activeSelf)
        {
            CarManager.Instance.SouthMiddleMoveEventStart();
        }
        else
        {
            CarManager.Instance.SouthMiddleStopEventStart();
        }
    } 
    public void SouthLeftMove()
    {
        WiteSouthLeft.SetActive(!WiteSouthLeft.activeSelf);
        if (!WiteSouthLeft.activeSelf)
        {
            CarManager.Instance.SouthLeftMoveEventStart();
        }
        else
        {
            CarManager.Instance.SouthLeftStopEventStart();
        }
    } 
    public void SouthRightMove()
    {
        WiteSouthRight.SetActive(!WiteSouthRight.activeSelf);
        if (!WiteSouthRight.activeSelf)
        {
            CarManager.Instance.SouthRightMoveEventStart();
        }
        else
        {
            CarManager.Instance.SouthRightStopEventStart();
        }
    }  
    
    
    public void NorthMiddenMove()
    {
        WiteNorthMiddle.SetActive(!WiteNorthMiddle.activeSelf);
        if (!WiteNorthMiddle.activeSelf)
        {
            CarManager.Instance.NorthMiddleMoveEventStart();
        }
        else
        {
            CarManager.Instance.NorthMiddleStopEventStart();
        }
    } 
    public void NorthLeftMove()
    {
        WiteNorthLeft.SetActive(!WiteNorthLeft.activeSelf);
        if (!WiteNorthLeft.activeSelf)
        {
            CarManager.Instance.NorthLeftMoveEventStart();
        }
        else
        {
            CarManager.Instance.NorthLeftStopEventStart();
        }
    } 
    public void NorthRightMove()
    {
        WiteNorthRight.SetActive(!WiteNorthRight.activeSelf);
        if (!WiteNorthRight.activeSelf)
        {
            CarManager.Instance.NorthRightMoveEventStart();
        }
        else
        {
            CarManager.Instance.NorthRightStopEventStart();
        }
    }


}
