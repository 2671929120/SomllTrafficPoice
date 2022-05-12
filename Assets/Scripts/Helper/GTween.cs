using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GTween : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        List<GameObject> objList = GameManager.Instance.TipsList;
        if (objList.Count > 0)
        {
            foreach (var obj in objList)
            {  
                obj.transform.localPosition += Vector3.up * Time.deltaTime * 80f;
                //obj.GetComponent<TextMeshPro>().color = new Color(obj1.color.r, obj1.color.g, obj1.color.b, obj1.color.a - Time.deltaTime * 1);
            }
        }
    }
    public void LateUpdate()
    {
        List<GameObject> objList = GameManager.Instance.TipsList;
        for (int i = objList.Count - 1; i >= 0; i--)
        {
            if (objList[i].transform.localPosition.y > 200)
            {
                Debug.Log("-----"+objList[i].transform.localPosition.y);
                Destroy(objList[i]);
                objList.RemoveAt(i);
            }

            
        }


    }



}
