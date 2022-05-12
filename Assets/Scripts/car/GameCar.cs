using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCar : MonoBehaviour
{
   
    private void Start()
    {
        //初始化所有汽车信息
        //StartCoroutine(WestMiddleInit(10));
        //StartCoroutine(WestRightInit(10));
        //StartCoroutine(WestLeftInit(10));

        // StartCoroutine(NorthMiddleInit(10));
        //StartCoroutine(NorthRightInit(10));
        //StartCoroutine(NorthLeftInit(10));

        //StartCoroutine(SouthMiddleInit(10));
        //StartCoroutine(SouthRightInit(10));
        //StartCoroutine(SouthLeftInit(10));

        //StartCoroutine(EastMiddleInit(10));
        //StartCoroutine(EastRightInit(10));
        //StartCoroutine(EastLeftInit(10));
        StartCoroutine(GameStart());


    }


    IEnumerator GameStart()
    {
        while(GameManager.Instance.CameTime < 120)
        {
            yield return new WaitForSeconds(1);
            GameManager.Instance.CameTime += 1;
            EventManager.Instance.TriggerEvent(ClientEvent.TIMESHOW);
            if (Config.ConfigFirstLevel.ContainsKey(GameManager.Instance.CameTime))
            {
                foreach (string str in Config.ConfigFirstLevel[GameManager.Instance.CameTime])
                {
                    string[] strs = str.Split('_');
                    if(strs[0]!= "Tips")
                    {
                        object[] obj = { int.Parse(strs[1].ToString()) };
                        Debug.Log(strs[0]+int.Parse(strs[1].ToString()));
                        
                           StartCoroutine(strs[0], strs[1]);
                       
                       
                       
                       
                    }
                    else
                    {
                        EventManager.Instance.TriggerEvent<string>(ClientEvent.TIPSSHOW, strs[1]);
                    }
                }
            }
        }
        
    }

    public void CarInit(string name,Object[] obj)
    {
        
        StartCoroutine(name,obj);
    }
     IEnumerator WestRightInit(object objs)
    {
        int nums = 0;
        if (objs != null)
        {
            nums = int.Parse(objs.ToString());
        } 
        yield return new WaitForSeconds(Random.Range(0f, 3f));
        for (int i = 0; i < nums; i++)
        {
            yield return new WaitUntil(() => { return CarManager.Instance.WestRightList.Count < 7; });
            int carid = Random.Range(1, 7);
            GameObject obj = Resources.Load<GameObject>("car/Car_" + carid);
            GameObject car = Instantiate(obj);
            car.gameObject.AddComponent<CarBase>();
            CarBase carBase = car.transform.GetComponent<CarBase>();
            //carBase = new CarBase();
            carBase.carType = CarType.WestRight;
            carBase.carMode = CarMode.jipuche;
            carBase.moveType = MoveType.Move;
            carBase.Car = car;
            //设置对应的方位与信息
            car.transform.position = Config.WestRightPos;
            car.transform.localEulerAngles = Config.WestRightRot;
            CarManager.Instance.WestRightMoveEvent += carBase.Move;
            CarManager.Instance.WestRightStopEvent += carBase.Stop;
            CarManager.Instance.WestRightList.Add(carBase);
            float time = Random.Range(2f, 4f);
            yield return new WaitForSeconds(time);
        }
    }
    IEnumerator WestLeftInit(object objs)
    {
        int nums = 0;
        if (objs != null)
        {
            nums = int.Parse(objs.ToString());
        }
        yield return new WaitForSeconds(Random.Range(0f, 3f));
        for (int i = 0; i < nums; i++)
        {
            yield return new WaitUntil(() => { return CarManager.Instance.WestLeftList.Count < 7; });
            int carid = Random.Range(1, 7);
            GameObject obj = Resources.Load<GameObject>("car/Car_"+carid);
            GameObject car = Instantiate(obj);
            car.gameObject.AddComponent<CarBase>();
            CarBase carBase = car.transform.GetComponent<CarBase>();
            //carBase = new CarBase();
            carBase.carType = CarType.WestLeft;
            carBase.carMode = CarMode.jipuche;
            carBase.moveType = MoveType.Move;
            carBase.Car = car;
            //设置对应的方位与信息
            car.transform.position = Config.WestLeftPos;
            car.transform.localEulerAngles = Config.WestLeftRot;
            CarManager.Instance.WestLeftMoveEvent += carBase.Move;
            CarManager.Instance.WestLeftStopEvent += carBase.Stop;
            CarManager.Instance.WestLeftList.Add(carBase);
            float time = Random.Range(2f, 4f);
            yield return new WaitForSeconds(time);
        }
    }
    IEnumerator WestMiddleInit(object objs)
    {
        int nums = 0;
        if (objs != null)
        {
            nums = int.Parse(objs.ToString());
        }
        yield return new WaitForSeconds(Random.Range(0f, 3f));
        for (int i = 0; i < nums; i++)
        {
            yield return new WaitUntil(() => { return CarManager.Instance.WestMiddleList.Count < 7; });
            int carid = Random.Range(1, 7);
            GameObject obj = Resources.Load<GameObject>("car/Car_" + carid);
            GameObject car = Instantiate(obj);
            car.gameObject.AddComponent<CarBase>();
            CarBase carBase = car.transform.GetComponent<CarBase>();
            //carBase = new CarBase();
            carBase.carType = CarType.WestMiddle;
            carBase.carMode = CarMode.jipuche;
            carBase.moveType = MoveType.Move;
            carBase.Car = car;
            //设置对应的方位与信息
            car.transform.position = Config.WestMiddlePos;
            car.transform.localEulerAngles = Config.WestMiddleRot;
            CarManager.Instance.WestMiddleMoveEvent += carBase.Move;
            CarManager.Instance.WestMiddleStopEvent += carBase.Stop;
            CarManager.Instance.WestMiddleList.Add(carBase);
            float time = Random.Range(2f, 4f);
            yield return new WaitForSeconds(time);
        }
    }
    IEnumerator EastRightInit(object objs)
    {
        int nums = 0;
        if (objs != null)
        {
            nums = int.Parse(objs.ToString());
        }
        yield return new WaitForSeconds(Random.Range(0f, 3f));
        for (int i = 0; i < nums; i++)
        {
            yield return new WaitUntil(() => { return CarManager.Instance.EastRightList.Count < 7; });
            int carid = Random.Range(1, 7);
            GameObject obj = Resources.Load<GameObject>("car/Car_" + carid);
            GameObject car = Instantiate(obj);
            car.gameObject.AddComponent<CarBase>();
            CarBase carBase = car.transform.GetComponent<CarBase>();
            //carBase = new CarBase();
            carBase.carType = CarType.EastRight;
            carBase.carMode = CarMode.jipuche;
            carBase.moveType = MoveType.Move;
            carBase.Car = car;
            //设置对应的方位与信息
            car.transform.position = Config.EastRightPos;
            car.transform.localEulerAngles = Config.EastRightRot;
            CarManager.Instance.EastRightMoveEvent += carBase.Move;
            CarManager.Instance.EastRightStopEvent += carBase.Stop;
            CarManager.Instance.EastRightList.Add(carBase);
            float time = Random.Range(2f, 4f);
            yield return new WaitForSeconds(time);
        }
    }
    IEnumerator EastLeftInit(object objs)
    {
        int nums = 0;
        if (objs != null)
        {
            nums = int.Parse(objs.ToString());
        }
        yield return new WaitForSeconds(Random.Range(0f, 3f));
        for (int i = 0; i < nums; i++)
        {
            yield return new WaitUntil(() => { return CarManager.Instance.EastLeftList.Count < 7; });
            int carid = Random.Range(1, 7);
            GameObject obj = Resources.Load<GameObject>("car/Car_" + carid);
            GameObject car = Instantiate(obj);
            car.gameObject.AddComponent<CarBase>();
            CarBase carBase = car.transform.GetComponent<CarBase>();
            //carBase = new CarBase();
            carBase.carType = CarType.EastLeft;
            carBase.carMode = CarMode.jipuche;
            carBase.moveType = MoveType.Move;
            carBase.Car = car;
            //设置对应的方位与信息
            car.transform.position = Config.EastLeftPos;
            car.transform.localEulerAngles = Config.EastLeftRot;
            CarManager.Instance.EastLeftMoveEvent += carBase.Move;
            CarManager.Instance.EastLeftStopEvent += carBase.Stop;
            CarManager.Instance.EastLeftList.Add(carBase);
            float time = Random.Range(2f, 4f);
            yield return new WaitForSeconds(time);
        }
    }
    IEnumerator EastMiddleInit(object objs)
    {
        int nums = 0;
        if (objs != null)
        {
            nums = int.Parse(objs.ToString());
        }
        yield return new WaitForSeconds(Random.Range(0f, 3f));
        for (int i = 0; i < nums; i++)
        {
            yield return new WaitUntil(() => { return CarManager.Instance.EastMiddleList.Count < 7; });
            int carid = Random.Range(1, 7);
            GameObject obj = Resources.Load<GameObject>("car/Car_" + carid);
            GameObject car = Instantiate(obj);
            car.gameObject.AddComponent<CarBase>();
            CarBase carBase = car.transform.GetComponent<CarBase>();
            //carBase = new CarBase();
            carBase.carType = CarType.EastMiddle;
            carBase.carMode = CarMode.jipuche;
            carBase.moveType = MoveType.Move;
            carBase.Car = car;
            //设置对应的方位与信息
            car.transform.position = Config.EastMiddlePos;
            car.transform.localEulerAngles = Config.EastMiddleRot;
            CarManager.Instance.EastMiddleMoveEvent += carBase.Move;
            CarManager.Instance.EastMiddleStopEvent += carBase.Stop;
            CarManager.Instance.EastMiddleList.Add(carBase);
            float time = Random.Range(2f, 4f);
            yield return new WaitForSeconds(time);
        }
    }  
    IEnumerator SouthRightInit(object objs)
    {
        int nums = 0;
        if (objs != null)
        {
            nums = int.Parse(objs.ToString());
        }
        yield return new WaitForSeconds(Random.Range(0f, 3f));
        for (int i = 0; i < nums; i++)
        {
            yield return new WaitUntil(() => { return CarManager.Instance.SouthRightList.Count < 7; });
            int carid = Random.Range(1, 7);
            GameObject obj = Resources.Load<GameObject>("car/Car_" + carid);
            GameObject car = Instantiate(obj);
            car.gameObject.AddComponent<CarBase>();
            CarBase carBase = car.transform.GetComponent<CarBase>();
            //carBase = new CarBase();
            carBase.carType = CarType.SouthRight;
            carBase.carMode = CarMode.jipuche;
            carBase.moveType = MoveType.Move;
            carBase.Car = car;
            //设置对应的方位与信息
            car.transform.position = Config.SouthRightPos;
            car.transform.localEulerAngles = Config.SouthRightRot;
            CarManager.Instance.SouthRightMoveEvent += carBase.Move;
            CarManager.Instance.SouthRightStopEvent += carBase.Stop;
            CarManager.Instance.SouthRightList.Add(carBase);
            float time = Random.Range(2f, 4f);
            yield return new WaitForSeconds(time);
        }
    }
    IEnumerator SouthLeftInit(object objs)
    {
        int nums = 0;
        if (objs != null)
        {
            nums = int.Parse(objs.ToString());
        }
        yield return new WaitForSeconds(Random.Range(0f, 3f));
        for (int i = 0; i < nums; i++)
        {
            yield return new WaitUntil(() => { return CarManager.Instance.SouthLeftList.Count < 7; });
            int carid = Random.Range(1, 7);
            GameObject obj = Resources.Load<GameObject>("car/Car_" + carid);
            GameObject car = Instantiate(obj);
            car.gameObject.AddComponent<CarBase>();
            CarBase carBase = car.transform.GetComponent<CarBase>();
            //carBase = new CarBase();
            carBase.carType = CarType.SouthLeft;
            carBase.carMode = CarMode.jipuche;
            carBase.moveType = MoveType.Move;
            carBase.Car = car;
            //设置对应的方位与信息
            car.transform.position = Config.SouthLeftPos;
            car.transform.localEulerAngles = Config.SouthLeftRot;
            CarManager.Instance.SouthLeftMoveEvent += carBase.Move;
            CarManager.Instance.SouthLeftStopEvent += carBase.Stop;
            CarManager.Instance.SouthLeftList.Add(carBase);
            float time = Random.Range(2f, 4f);
            yield return new WaitForSeconds(time);
        }
    }
    IEnumerator SouthMiddleInit(object objs)
    {
        int nums = 0;
        if (objs != null)
        {
            nums = int.Parse(objs.ToString());
        }
        yield return new WaitForSeconds(Random.Range(0f, 3f));
        for (int i = 0; i < nums; i++)
        {
            yield return new WaitUntil(() => { return CarManager.Instance.SouthMiddleList.Count < 7; });
            int carid = Random.Range(1, 7);
            GameObject obj = Resources.Load<GameObject>("car/Car_" + carid);
            GameObject car = Instantiate(obj);
            car.gameObject.AddComponent<CarBase>();
            CarBase carBase = car.transform.GetComponent<CarBase>();
            //carBase = new CarBase();
            carBase.carType = CarType.SouthMiddle;
            carBase.carMode = CarMode.jipuche;
            carBase.moveType = MoveType.Move;
            carBase.Car = car;
            //设置对应的方位与信息
            car.transform.position = Config.SouthMiddlePos;
            car.transform.localEulerAngles = Config.SouthMiddleRot;
            CarManager.Instance.SouthMiddleMoveEvent += carBase.Move;
            CarManager.Instance.SouthMiddleStopEvent += carBase.Stop;
            CarManager.Instance.SouthMiddleList.Add(carBase);
            float time = Random.Range(2f, 4f);
            yield return new WaitForSeconds(time);
        }
    }   
    IEnumerator NorthRightInit(object objs)
    {
        int nums = 0;
        if (objs != null)
        {
            nums = int.Parse(objs.ToString());
        }
        yield return new WaitForSeconds(Random.Range(0f, 3f));
        for (int i = 0; i < nums; i++)
        {
            yield return new WaitUntil(() => { return CarManager.Instance.NorthRightList.Count < 7; });
            int carid = Random.Range(1, 7);
            GameObject obj = Resources.Load<GameObject>("car/Car_" + carid);
            GameObject car = Instantiate(obj);
            car.gameObject.AddComponent<CarBase>();
            CarBase carBase = car.transform.GetComponent<CarBase>();
            //carBase = new CarBase();
            carBase.carType = CarType.NorthRight;
            carBase.carMode = CarMode.jipuche;
            carBase.moveType = MoveType.Move;
            carBase.Car = car;
            //设置对应的方位与信息
            car.transform.position = Config.NorthRightPos;
            car.transform.localEulerAngles = Config.NorthRightRot;
            CarManager.Instance.NorthRightMoveEvent += carBase.Move;
            CarManager.Instance.NorthRightStopEvent += carBase.Stop;
            CarManager.Instance.NorthRightList.Add(carBase);
            float time = Random.Range(2f, 4f);
            yield return new WaitForSeconds(time);
        }
    }
    IEnumerator NorthLeftInit(object objs)
    {
        int nums = 0;
        if (objs != null)
        {
            nums = int.Parse(objs.ToString());
        }
        yield return new WaitForSeconds(Random.Range(0f, 3f));
        for (int i = 0; i < nums; i++)
        {
            yield return new WaitUntil(() => { return CarManager.Instance.NorthLeftList.Count < 7; });
            int carid = Random.Range(1, 7);
            GameObject obj = Resources.Load<GameObject>("car/Car_" + carid);
            GameObject car = Instantiate(obj);
            car.gameObject.AddComponent<CarBase>();
            CarBase carBase = car.transform.GetComponent<CarBase>();
            //carBase = new CarBase();
            carBase.carType = CarType.NorthLeft;
            carBase.carMode = CarMode.jipuche;
            carBase.moveType = MoveType.Move;
            carBase.Car = car;
            //设置对应的方位与信息
            car.transform.position = Config.NorthLeftPos;
            car.transform.localEulerAngles = Config.NorthLeftRot;
            CarManager.Instance.NorthLeftMoveEvent += carBase.Move;
            CarManager.Instance.NorthLeftStopEvent += carBase.Stop;
            CarManager.Instance.NorthLeftList.Add(carBase);
            float time = Random.Range(2f, 4f);
            yield return new WaitForSeconds(time);
        }
    }
    IEnumerator NorthMiddleInit(object objs)
    {
        int nums = 0;
        if (objs != null)
        {
            nums = int.Parse(objs.ToString());
        }
        yield return new WaitForSeconds(Random.Range(0f, 3f));
        for (int i = 0; i < nums; i++)
        {
            yield return new WaitUntil(() => { return CarManager.Instance.NorthMiddleList.Count < 7; });
            int carid = Random.Range(1, 7);
            GameObject obj = Resources.Load<GameObject>("car/Car_" + carid);
            GameObject car = Instantiate(obj);
            car.gameObject.AddComponent<CarBase>();
            CarBase carBase = car.transform.GetComponent<CarBase>();
            //carBase = new CarBase();
            carBase.carType = CarType.NorthMiddle;
            carBase.carMode = CarMode.jipuche;
            carBase.moveType = MoveType.Move;
            carBase.Car = car;
            //设置对应的方位与信息
            car.transform.position = Config.NorthMiddlePos;
            car.transform.localEulerAngles = Config.NorthMiddleRot;
            CarManager.Instance.NorthMiddleMoveEvent += carBase.Move;
            CarManager.Instance.NorthMiddleStopEvent += carBase.Stop;
            CarManager.Instance.NorthMiddleList.Add(carBase);
            float time = Random.Range(2f, 4f);
            yield return new WaitForSeconds(time);
        }
    }
}
