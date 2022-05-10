﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 该脚本进行摄像机视角的转化和移动 
/// 18.353 73.393 -13.23
/// 90 0 0
/// </summary>
public class CameraViewChange : MonoBehaviour
{
    enum camereStatus
    {
        up,
        down,
    }
    public Camera camera;
    private camereStatus status;
    public GameObject Palyer;

    //保存之前的位置和角度
    private Vector3 lastPos;
    private Vector3 lastRot;
    void Start()
    {
        lastPos = new Vector3(20.35f, 17.092f, -28.04f);//33.859f, 18.1f, -15.87f);
        transform.position = lastPos;
        lastRot = new Vector3(0, 0, 0);
        transform.localEulerAngles = lastRot;
        status = camereStatus.down;
        ChangeCameraView();
        camera = this.gameObject.GetComponent<Camera>();

        EventManager.Instance.AddEvent(ClientEvent.CAMERACHANGE, ChangeCameraView);
    }
    private void Update()
    {

        if (status == camereStatus.down)
        {
            if (Input.GetMouseButton(0))
            {
                float mouseX = Input.GetAxis("Mouse X") * 10;
                //Debug.Log("旋转视角" + mouseX);
                //Palyer.transform.Rotate(new Vector3(0,mouseX,0),Space.Self);
                this.transform.RotateAround(Palyer.transform.position, transform.up, mouseX);
            }
        }
        this.transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, 0);
    }

    public void ChangeCameraView()
    {
       if(status == camereStatus.up)
        {
 
            this.transform.position = lastPos;
            this.transform.localEulerAngles = lastRot;
            status = camereStatus.down;
        }
        else
        {
            status = camereStatus.up;
            lastPos = transform.position;
            lastRot = transform.localEulerAngles;
            this.transform.position = new Vector3(18.353f, 73.393f ,- 13.23f);
            this.transform.localEulerAngles = new Vector3(90,0,0);
           
        }
    }
}
