using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapINs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 200; i++)
        {
            for (int j = 0; j < 200; j++)
            {
                GameObject obj = Instantiate(Resources.Load<GameObject>("Grass"));
                obj.transform.parent = GameObject.Find("/Grass").transform;
                obj.transform.localPosition = new Vector3(i*2f,11.9f,j*2);
              
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
