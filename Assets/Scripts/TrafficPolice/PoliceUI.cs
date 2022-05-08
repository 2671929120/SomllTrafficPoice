using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PoliceUI : MonoBehaviour 
{
    public Button EastMidden;
    public Button EastLeft;
    public Button EastRight; 
    
    public Button WestMidden;
    public Button WestLeft;
    public Button WestRight;
    
    public Button NorthMidden;
    public Button NorthLeft;
    public Button NorthRight; 
    
    public Button SouthMidden;
    public Button SouthLeft;
    public Button SouthRight;

    private void Start()
    {
        EastMidden.onClick.AddListener(EastMiddenDown);
        EastLeft.onClick.AddListener(EastLeftDown);
        EastRight.onClick.AddListener(EastRightDown);  
        
        NorthMidden.onClick.AddListener(NorthMiddenDown);
        NorthLeft.onClick.AddListener(NorthLeftDown);
        NorthRight.onClick.AddListener(NorthRightDown);     
        
        WestMidden.onClick.AddListener(WestMiddenDown);
        WestLeft.onClick.AddListener(WestLeftDown);
        WestRight.onClick.AddListener(WestRightDown);

        SouthMidden.onClick.AddListener(SouthMiddenDown);
        SouthLeft.onClick.AddListener(SouthLeftDown);
        SouthRight.onClick.AddListener(SouthRightDown);
    }

    public void EastMiddenDown()
    {
        EventManager.Instance.TriggerEvent(ClientEvent.EASTMIDDENMOVE);

    } 
    public void EastLeftDown()
    {
        EventManager.Instance.TriggerEvent(ClientEvent.EASTLEFTMOVE);

    }
    public void EastRightDown()
    {
        EventManager.Instance.TriggerEvent(ClientEvent.EASTRIGHTMOVE);

    } 


    public void WestMiddenDown()
    {
        EventManager.Instance.TriggerEvent(ClientEvent.WESTMIDDENMOVE);

    } 
    public void WestLeftDown()
    {
        EventManager.Instance.TriggerEvent(ClientEvent.WESTLEFTMOVE);

    }
    public void WestRightDown()
    {
        EventManager.Instance.TriggerEvent(ClientEvent.WESTRIGHTMOVE);

    } 
    
    
    public void SouthMiddenDown()
    {
        EventManager.Instance.TriggerEvent(ClientEvent.SOUTHMIDDENMOVE);

    } 
    public void SouthLeftDown()
    {
        EventManager.Instance.TriggerEvent(ClientEvent.SOUTHLEFTMOVE);

    }
    public void SouthRightDown()
    {
        EventManager.Instance.TriggerEvent(ClientEvent.SOUTHRIGHTMOVE);

    }
    
    
    public void NorthMiddenDown()
    {
        EventManager.Instance.TriggerEvent(ClientEvent.NORTHMIDDENMOVE);

    } 
    public void NorthLeftDown()
    {
        EventManager.Instance.TriggerEvent(ClientEvent.NORTHLEFTMOVE);

    }
    public void NorthRightDown()
    {
        EventManager.Instance.TriggerEvent(ClientEvent.NORTHRIGHTMOVE);
    }
}
