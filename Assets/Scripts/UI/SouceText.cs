using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SouceText : MonoBehaviour
{
  public  TextMeshPro text1;

   public  GameObject DestoryWest;
   public  GameObject DestoryEast;
   public  GameObject DestoryNorth;
   public  GameObject DestorySouth;

    List<GameObject> objList;
    // Start is called before the first frame update
    void Start()
    {
        objList = new List<GameObject>();
        EventManager.Instance.AddEvent<CarType>(ClientEvent.SOUCETEXT, CreatText);
        text1.text = "12312";


        GameObject textObj = ResManager.LoadUIPrefab("TextMeshPro");
        GameObject text = Instantiate(textObj, DestoryWest.transform);
        text.transform.localPosition = new Vector3(8.99f, 7.52f, -1.5f);
        text.transform.localEulerAngles = new Vector3(0f, -90f, 0f); 
        text.transform.GetComponent<TextMeshPro>().text = "+1";
        
        objList.Add(text);
    }


    public void CreatText(CarType carType)
    {
        Debug.Log("1111");
        if ((int)carType / 3 == 0)//西方
        {
            GameObject textObj = ResManager.LoadUIPrefab("TextMeshPro");
            GameObject text = Instantiate(textObj, DestoryWest.transform);
            text.transform.localPosition = new Vector3(8.99f, 7.52f, -1.5f);
            text.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
            text.transform.GetComponent<TextMeshPro>().text = "+1";
            objList.Add(text);
        }
        else if((int)carType / 3 == 1)//北方
        {
            GameObject textObj = ResManager.LoadUIPrefab("TextMeshPro");
            GameObject text = Instantiate(textObj, DestoryNorth.transform);
            text.transform.localPosition = new Vector3(8.99f, 7.52f, -1.5f);
            text.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
            text.transform.GetComponent<TextMeshPro>().text = "+1";
            objList.Add(text);

        }
        else if((int)carType / 3 == 2)//东方
        {
            GameObject textObj = ResManager.LoadUIPrefab("TextMeshPro");
            GameObject text = Instantiate(textObj, DestoryEast.transform);
            text.transform.localPosition = new Vector3(8.99f, 7.52f, -1.5f);
            text.transform.localEulerAngles = new Vector3(0f, 90f, 0f);
            text.transform.GetComponent<TextMeshPro>().text = "+1";
            objList.Add(text);
        }
        else if((int)carType / 3 == 3)//南方
        {
            GameObject textObj = ResManager.LoadUIPrefab("TextMeshPro");
            GameObject text = Instantiate(textObj, DestorySouth.transform);
            text.transform.localPosition = new Vector3(8.99f, 7.52f, -1.5f);
            text.transform.localEulerAngles = new Vector3(0f, -90f, 0f);
            text.transform.GetComponent<TextMeshPro>().text = "+1";
            objList.Add(text);
        }
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
