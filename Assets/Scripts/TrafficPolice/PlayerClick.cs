using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClick : MonoBehaviour
{
    // Start is called before the first frame update
    public Shader shaderRed;
    public Shader shaderGreen;
    public bool canTouch;//判断是否可以触摸
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&& GameManager.Instance.CanTouch)
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
            GameManager.Instance.CanTouch = false;

        }
        if(goname == "eastMidden")
        {
            EventManager.Instance.TriggerEvent(ClientEvent.EASTMIDDENMOVE);
            GameManager.Instance.CanTouch = false;

        }
        if (goname == "eastRight")
        {
            EventManager.Instance.TriggerEvent(ClientEvent.EASTRIGHTMOVE);
            GameManager.Instance.CanTouch = false;

        }


        if (goname == "westLeft")
        {
            EventManager.Instance.TriggerEvent(ClientEvent.WESTLEFTMOVE);
            GameManager.Instance.CanTouch = false;

        }
        if (goname == "westMidden")
        {
            EventManager.Instance.TriggerEvent(ClientEvent.WESTMIDDENMOVE);
            GameManager.Instance.CanTouch = false;

        }
        if (goname == "westRight")
        {
            EventManager.Instance.TriggerEvent(ClientEvent.WESTRIGHTMOVE);
            GameManager.Instance.CanTouch = false;

        }

        if (goname == "northLeft")
        {
            EventManager.Instance.TriggerEvent(ClientEvent.NORTHLEFTMOVE);
            GameManager.Instance.CanTouch = false;

        }
        if (goname == "northMidden")
        {
            EventManager.Instance.TriggerEvent(ClientEvent.NORTHMIDDENMOVE);
            GameManager.Instance.CanTouch = false;

        }
        if (goname == "northRight")
        {
            EventManager.Instance.TriggerEvent(ClientEvent.NORTHRIGHTMOVE);
            GameManager.Instance.CanTouch = false;

        }

        if (goname == "southLeft")
        {
            EventManager.Instance.TriggerEvent(ClientEvent.SOUTHLEFTMOVE);
            GameManager.Instance.CanTouch = false;

        }
        if (goname == "southMidden")
        {
            EventManager.Instance.TriggerEvent(ClientEvent.SOUTHMIDDENMOVE);
            GameManager.Instance.CanTouch = false;

        }
        if (goname == "southRight")
        {
            EventManager.Instance.TriggerEvent(ClientEvent.SOUTHRIGHTMOVE);
            GameManager.Instance.CanTouch = false;

        }
    }
}
