using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TsetMono : MonoBehaviour
{
    public int a;
    public   TsetMono(int num)
    {
        this.a = num;
    }
    void Start()
    {
        Debug.Log("调用测试的start");
    }

   
    void Update()
    {
        Debug.Log(a);
    }
}
