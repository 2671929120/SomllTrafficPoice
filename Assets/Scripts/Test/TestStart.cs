using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestStart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = Resources.Load<GameObject>("Cube");
        GameObject cube = Instantiate(obj);
        TsetMono tsetMono = new TsetMono(12);
        Debug.Log("开始加入");
        cube.AddComponent(typeof(TsetMono));
        Debug.Log("开始完毕");
        TsetMono tsetMono1 = cube.GetComponent<TsetMono>();
        tsetMono1 = new TsetMono(12);
        Debug.Log("开始赋值"+tsetMono1.a);
        //tsetMono1.a=13;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
