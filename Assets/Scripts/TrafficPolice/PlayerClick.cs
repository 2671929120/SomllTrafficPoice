using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClick : MonoBehaviour
{
    // Start is called before the first frame update
    public Shader shaderRed;
    public Shader shaderGreen;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //射线检测
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "letgo")
                {

                     TriggerCar(hit.collider.name);
                    if (hit.collider.gameObject.transform.GetComponent<MeshRenderer>().material.shader == shaderRed)
                    {
                        hit.collider.gameObject.transform.GetComponent<MeshRenderer>().material.shader = shaderGreen;
                    }
                    else
                    {
                        hit.collider.gameObject.transform.GetComponent<MeshRenderer>().material.shader = shaderRed;
                    } 
                }
            }
        } 
    }

    public void TriggerCar(string goname)
    {
        if(goname == "eastLeft")
        {
            EventManager.Instance.TriggerEvent(ClientEvent.EASTLEFTMOVE);
        }if(goname == "eastMidden")
        {
            EventManager.Instance.TriggerEvent(ClientEvent.EASTMIDDENMOVE);
        }if(goname == "eastRight")
        {
            EventManager.Instance.TriggerEvent(ClientEvent.EASTRIGHTMOVE);
        } 
        
        
        if(goname == "westLeft")
        {
            EventManager.Instance.TriggerEvent(ClientEvent.WESTLEFTMOVE);
        }if(goname == "westMidden")
        {
            EventManager.Instance.TriggerEvent(ClientEvent.WESTMIDDENMOVE);
        }if(goname == "westRight")
        {
            EventManager.Instance.TriggerEvent(ClientEvent.WESTRIGHTMOVE);
        }
        
        if(goname == "northLeft")
        {
            EventManager.Instance.TriggerEvent(ClientEvent.NORTHLEFTMOVE);
        }if(goname == "northMidden")
        {
            EventManager.Instance.TriggerEvent(ClientEvent.NORTHMIDDENMOVE);
        }if(goname == "northRight")
        {
            EventManager.Instance.TriggerEvent(ClientEvent.NORTHRIGHTMOVE);
        } 
        
        if(goname == "southLeft")
        {
            EventManager.Instance.TriggerEvent(ClientEvent.SOUTHLEFTMOVE);
        }if(goname == "southMidden")
        {
            EventManager.Instance.TriggerEvent(ClientEvent.SOUTHMIDDENMOVE);
        }if(goname == "southRight")
        {
            EventManager.Instance.TriggerEvent(ClientEvent.SOUTHRIGHTMOVE);
        }
    }
}
