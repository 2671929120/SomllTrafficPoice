using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficPolice : MonoBehaviour
{
    private GameObject WiteEastLeft;
    private GameObject WiteEastRight;
    private GameObject WiteEastMiddle;
    private GameObject WiteWestLeft;
    private GameObject WiteWestRight;
    private GameObject WiteWestMiddle;
    private GameObject WiteNorthLeft;
    private GameObject WiteNorthRight;
    private GameObject WiteNorthMiddle;
    private GameObject WiteSouthLeft;
    private GameObject WiteSouthRight;
    private GameObject WiteSouthMiddle;

    public Animator animatorPlayer;
    public GameObject TafficPoliceMan;

    private bool isNeed;
    private Vector3 changeAngle;
    private string animName;


    public delegate void MoveDele();
    public event MoveDele MoveEvent;
    public bool zuijin;
    void Start()
    {
        Debug.Log("开始加载TrafficPolice");
        WiteEastLeft = GameObject.Find("Colliders/witeEastLeft");
        WiteEastRight = GameObject.Find("Colliders/witeEastRight");
        WiteEastMiddle = GameObject.Find("Colliders/witeEastMiddle");

        WiteWestLeft = GameObject.Find("Colliders/witeWestLeft");
        WiteWestRight = GameObject.Find("Colliders/witeWestRight");
        WiteWestMiddle = GameObject.Find("Colliders/witeWestMiddle");

        WiteSouthLeft = GameObject.Find("Colliders/witeSouthLeft");
        WiteSouthRight = GameObject.Find("Colliders/witeSouthRight");
        WiteSouthMiddle = GameObject.Find("Colliders/witeSouthMiddle");

        WiteNorthLeft = GameObject.Find("Colliders/witenorthLeft");
        WiteNorthRight = GameObject.Find("Colliders/witenorthRight");
        WiteNorthMiddle = GameObject.Find("Colliders/witenorthMiddle");

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

        changeAngle = Vector3.zero;
        isNeed = false;
    }
    private void OnDestroy()
    {
        EventManager.Instance.RemoveEvent(ClientEvent.WESTMIDDENMOVE, WestMiddenMove);
        EventManager.Instance.RemoveEvent(ClientEvent.WESTLEFTMOVE, WestLeftMove);
        EventManager.Instance.RemoveEvent(ClientEvent.WESTRIGHTMOVE, WestRightMove);
        EventManager.Instance.RemoveEvent(ClientEvent.EASTMIDDENMOVE, EastMiddenMove);
        EventManager.Instance.RemoveEvent(ClientEvent.EASTLEFTMOVE, EastLeftMove);
        EventManager.Instance.RemoveEvent(ClientEvent.EASTRIGHTMOVE, EastRightMove);
        EventManager.Instance.RemoveEvent(ClientEvent.SOUTHMIDDENMOVE, SouthMiddenMove);
        EventManager.Instance.RemoveEvent(ClientEvent.SOUTHLEFTMOVE, SouthLeftMove);
        EventManager.Instance.RemoveEvent(ClientEvent.SOUTHRIGHTMOVE, SouthRightMove);
        EventManager.Instance.RemoveEvent(ClientEvent.NORTHMIDDENMOVE, NorthMiddenMove);
        EventManager.Instance.RemoveEvent(ClientEvent.NORTHLEFTMOVE, NorthLeftMove);
        EventManager.Instance.RemoveEvent(ClientEvent.NORTHRIGHTMOVE, NorthRightMove);
    }


    private void Update()
    {
        if (isNeed)
        {
            if (Mathf.Abs(TafficPoliceMan.transform.localEulerAngles.y%360 - changeAngle.y )> 10f)
            {
               // Debug.Log("旋转中"+ TafficPoliceMan.transform.localEulerAngles.y % 360);
                if(changeAngle.y - TafficPoliceMan.transform.localEulerAngles.y % 360 > 0)
                {
                    TafficPoliceMan.transform.Rotate(0, 200f * Time.deltaTime, 0,Space.Self);
                    //TafficPoliceMan.transform.localEulerAngles = TafficPoliceMan.transform.localEulerAngles + Vector3.up * Time.deltaTime * 200;
                }
                else 
                {
                   TafficPoliceMan.transform.Rotate(0, -200f * Time.deltaTime, 0,Space.Self);
                   // TafficPoliceMan.transform.localEulerAngles = TafficPoliceMan.transform.localEulerAngles - Vector3.up * Time.deltaTime * 200;
                }
            }
            else
            {
                isNeed = false;
                TriggerAnim();
            }
        }
    }
   
    public void TriggerAnim()
    {
        if(animName!= null)
        {
            animatorPlayer.SetTrigger(animName);
            //执行回调
            //MoveEvent?.Invoke();
            Debug.Log("结束动作可以继续点击");
             GameManager.Instance.CanTouch = true;
           
           
            //MoveEvent = null;
        }
    }
    public void MiddonAnim(float angle)
    {
        changeAngle.y = angle;
        isNeed = true;
        animName = "go";
    }
    public void LeftAnim(float angle)
    {
        changeAngle.y = angle;
        isNeed = true;
        animName = "left";
    }
    public void RightAnim(float angle)
    {
        changeAngle.y = angle;
        isNeed = true;
        animName = "right";
    }
    public void StopAnim(float angle)
    {
        changeAngle.y = angle;
        isNeed = true;
        animName = "stop";
    }
    public void EastMiddenMove()
    {
        WiteEastMiddle.SetActive(!WiteEastMiddle.activeSelf);
        if (!WiteEastMiddle.activeSelf)
        {
            CarManager.Instance.EastMiddleMoveEventStart();
            //这里面还需要添加对应的动画信息
            //只需要知道一个偏移位置就行别的无所谓
            changeAngle = new Vector3(0, 0, 0);
            isNeed = true;
            animName = "go";
        }
        else
        {
            CarManager.Instance.EastMiddleStopEventStart();
            StopAnim(90);
        }
      
    } 
    public void EastLeftMove()
    {
        WiteEastLeft.SetActive(!WiteEastLeft.activeSelf);
        if (!WiteEastLeft.activeSelf)
        {
            Debug.Log("点击了east的左");
            CarManager.Instance.EastLeftMoveEventStart();
            changeAngle = new Vector3(0, 180, 0);
            isNeed = true;
            animName = "left";
        }
        else
        {
            CarManager.Instance.EastLeftStopEventStart();
                StopAnim(90);
        }
    } 
    public void EastRightMove()
    {
        WiteEastRight.SetActive(!WiteEastRight.activeSelf);
        if (!WiteEastRight.activeSelf)
        {
            CarManager.Instance.EastRightMoveEventStart();
            changeAngle = new Vector3(0, 0, 0);
            isNeed = true;
            animName = "right";
           
        }
        else
        {
            CarManager.Instance.EastRightStopEventStart();
            StopAnim(180);
        }
    }  
    
    
    public void WestMiddenMove()
    {
        WiteWestMiddle.SetActive(!WiteWestMiddle.activeSelf);
        if (!WiteWestMiddle.activeSelf)
        {
            CarManager.Instance.WestMiddleMoveEventStart();
            MiddonAnim(180);
        }
        else
        {
            CarManager.Instance.WestMiddleStopEventStart();
            StopAnim(270);
        }
    } 
    public void WestLeftMove()
    {
        WiteWestLeft.SetActive(!WiteWestLeft.activeSelf);
        if (!WiteWestLeft.activeSelf)
        {
            CarManager.Instance.WestLeftMoveEventStart();
            LeftAnim(0);
        }
        else
        {
            CarManager.Instance.WestLeftStopEventStart();
            StopAnim(270);
        }
    } 
    public void WestRightMove()
    {
        WiteWestRight.SetActive(!WiteWestRight.activeSelf);
        if (!WiteWestRight.activeSelf)
        {
            CarManager.Instance.WestRightMoveEventStart();
            RightAnim(180);
        }
        else
        {
            CarManager.Instance.EastRightStopEventStart();
            StopAnim(270);
        }
    }  
    
    public void SouthMiddenMove()
    {
        WiteSouthMiddle.SetActive(!WiteSouthMiddle.activeSelf);
        if (!WiteSouthMiddle.activeSelf)
        {
            CarManager.Instance.SouthMiddleMoveEventStart();
            MiddonAnim(90);
        }
        else
        {
            CarManager.Instance.SouthMiddleStopEventStart();
            StopAnim(180);
        }
    } 
    public void SouthLeftMove()
    {
        WiteSouthLeft.SetActive(!WiteSouthLeft.activeSelf);
        if (!WiteSouthLeft.activeSelf)
        {
            CarManager.Instance.SouthLeftMoveEventStart();
            LeftAnim(270);
        }
        else
        {
            CarManager.Instance.SouthLeftStopEventStart();
            StopAnim(180);
        }
    } 
    public void SouthRightMove()
    {
        WiteSouthRight.SetActive(!WiteSouthRight.activeSelf);
        if (!WiteSouthRight.activeSelf)
        {
            CarManager.Instance.SouthRightMoveEventStart();
            RightAnim(90);
        }
        else
        {
            CarManager.Instance.SouthRightStopEventStart();
            StopAnim(180);
        }
    }  
    
    
    public void NorthMiddenMove()
    {
        WiteNorthMiddle.SetActive(!WiteNorthMiddle.activeSelf);
        if (!WiteNorthMiddle.activeSelf)
        {
            CarManager.Instance.NorthMiddleMoveEventStart();
            MiddonAnim(270);
        }
        else
        {
            CarManager.Instance.NorthMiddleStopEventStart();
            StopAnim(0);
        }
    } 
    public void NorthLeftMove()
    {
        WiteNorthLeft.SetActive(!WiteNorthLeft.activeSelf);
        if (!WiteNorthLeft.activeSelf)
        {
            CarManager.Instance.NorthLeftMoveEventStart();
            LeftAnim(90);
        }
        else
        {
            CarManager.Instance.NorthLeftStopEventStart();
            StopAnim(0);
        }
    } 
    public void NorthRightMove()
    {
        WiteNorthRight.SetActive(!WiteNorthRight.activeSelf);
        if (!WiteNorthRight.activeSelf)
        {
            CarManager.Instance.NorthRightMoveEventStart();
            RightAnim(270);
        }
        else
        {
            CarManager.Instance.NorthRightStopEventStart();
            StopAnim(0);
        }
    }


}
