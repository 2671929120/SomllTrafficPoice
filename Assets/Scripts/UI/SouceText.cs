using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SouceText : MonoBehaviour
{

   public  GameObject DestoryWest;
   public  GameObject DestoryEast;
   public  GameObject DestoryNorth;
   public  GameObject DestorySouth;

    List<GameObject> objList;
    // Start is called before the first frame update
    void Start()
    {
        objList = new List<GameObject>();
        EventManager.Instance.AddEvent<int>(ClientEvent.SOUCETEXT, CreatText);
      


      
        
     
    }


    public void CreatText(int  type)
    {
        Debug.Log("-----触发提示"+ type);
        if (type  == 1)//西方
        {
            GameObject textObj = ResManager.LoadUIPrefab("TextMeshPro");
            GameObject text = Instantiate(textObj, DestoryWest.transform);
            text.transform.localPosition = new Vector3(22.76f, 9.06f, -6.68f);
            text.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
            text.transform.GetComponent<TextMeshPro>().text = "+1";
            objList.Add(text);
        }
         if(type == 2)//北方
        {
            GameObject textObj = ResManager.LoadUIPrefab("TextMeshPro");
            GameObject text = Instantiate(textObj, DestoryNorth.transform);
            text.transform.localPosition = new Vector3(20.6f, 8.6f,-9.6f);
            text.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
            text.transform.GetComponent<TextMeshPro>().text = "+1";
            objList.Add(text);

        }
         if(type == 3)//东方
        {
            GameObject textObj = ResManager.LoadUIPrefab("TextMeshPro");
            GameObject text = Instantiate(textObj, DestoryEast.transform);
            text.transform.localPosition = new Vector3(-23.6f, 9.6f,-3.61f);
            text.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
            text.transform.GetComponent<TextMeshPro>().text = "+1";
            objList.Add(text);
        }
         if(type == 4)//南方
        {
            GameObject textObj = ResManager.LoadUIPrefab("TextMeshPro");
            GameObject text = Instantiate(textObj, DestorySouth.transform);
            text.transform.localPosition = new Vector3(-28.4f,10.62f, -2.8f);
            text.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
            text.transform.GetComponent<TextMeshPro>().text = "+1";
            objList.Add(text);
        }
    }

    private void CreatTips(float angle,Vector3 pos,string str =null)
    {
        GameObject textObj = ResManager.LoadUIPrefab("TextMeshPro");
        GameObject text = Instantiate(textObj, DestoryWest.transform);
        text.transform.localPosition = pos;
        text.transform.localEulerAngles = new Vector3(0f, angle, 0f);
        text.transform.GetComponent<TextMeshPro>().text = str;
        objList.Add(text);
    }

    private void Update()
    {
        if(objList.Count > 0)
        {
            foreach (var obj in objList)
            {
                obj.transform.Translate(Vector3.up * Time.deltaTime, Space.Self);
                TextMeshPro obj1 = obj.GetComponent<TextMeshPro>();
                obj.GetComponent<TextMeshPro>().color=new Color(obj1.color.r,obj1.color.g,obj1.color.b,obj1.color.a-Time.deltaTime * 1);
            }
        }
    }
    public void LateUpdate()
    {
        for (int i = objList.Count - 1; i >= 0; i--)
        {
            if (objList[i].GetComponent<TextMeshPro>().color.a <= 0)
            {
                Destroy(objList[i]);
                objList.RemoveAt(i);
            }
        }
            
        
    }

    public void Animation(GameObject obj)
    {
        float objz = obj.transform.localPosition.z;

    }
}
