using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBase : MonoBehaviour 
{
    public CarMode carMode;
    public Vector3 carPos; 
    //汽车的位置类型
    public CarType carType;
    public GameObject Car;
    public MoveType moveType;

    private bool JustGo = false;

    public const float Speed = 5f;
    public const float LeftAngle = 11.1f;
    public const float RightAngle = 29f;

  
    private float T = 0;
    //private BoxCollider collider;

    //初始化位置
    public void _InitPos()
    {
       

    }
    private void Start()
    {
      
    }
    

    private void Update()
    {
        carPos = this.transform.position;

        //移动逻辑
        if (moveType == MoveType.Move)
        {
            if (!JustGo)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * Speed);
            }
            else
            {


                int type = (int)carType % 3;

                switch (type)
                {
                    case 0:
                        {
                            //直行
                           // Debug.Log("类型" + carType + "的汽车在直行");
                            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
                            break;
                        }
                    case 1:
                        {
                            //右转
                            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
                            if(T< 90)
                            {
                                T += Time.deltaTime * RightAngle;
                                transform.Rotate(Vector3.up * Time.deltaTime * RightAngle);
                            }
                         
                           // Debug.Log("类型" + carType + "的汽车在右转");
                            break;
                        }
                    case 2:
                        {
                            //左转
                           // Debug.Log("类型" + carType + "的汽车在左转");
                            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
                            if (T < 90)
                            {
                                T += Time.deltaTime * LeftAngle;
                                transform.Rotate(-Vector3.up * Time.deltaTime * LeftAngle);
                            }
                            break;
                        }
                }
            }
        }
    }
    public void Move()
    {
        if (moveType != MoveType.Move)
        {
            moveType = MoveType.Move;
            
        }
    }
    public void Stop()
    {
        gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        if (moveType != MoveType.Stop)
        {
            moveType = MoveType.Stop;
        }
    }
    public void CarDetory(int type)
    {
        //将管理器中的实例移除掉
        // CarManager.Instance.DestoryCar(carType, this);
        EventManager.Instance.TriggerEvent<int>(ClientEvent.SOUCETEXT, type);
        GameObject.Destroy(Car);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "wite"&& !JustGo)
        {
            Stop();
            //这里为了防止已过线的汽车被阻拦 加一层保护
            // this.GetComponent<BoxCollider>().enabled = false;
            return;
        }
        if (collision.collider.tag == "destory")
        {
            int type = int.Parse(collision.collider.name.Split('_')[1]);
            CarDetory(type);
            return;
        }
        //如果碰到的不是同种类型汽车 那么直接游戏结束
        if (collision.collider.tag == "car")
        {
            if (collision.collider.gameObject.GetComponent<CarBase>().carType != this.carType)
            {
                EventManager.Instance.TriggerEvent(ClientEvent.GAMEOVER);
                GameManager.Instance.GameOver = true;
                PanelManager.Open<FailPop>();
            }
            else
            {
                Stop();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.collider.tag == "car")
        {
            StartCoroutine(CanMove());
           
        }
    }
    IEnumerator CanMove()
    {
        yield return new WaitForSeconds(1f);
        Move();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "wite"&&!JustGo)
        {
            Stop();
        }
        if(other.tag == "already")
        {
            //Debug.Log("已经过了斑马线了可以继续走");
            JustGo = true;
            //移除事件
            CarManager.Instance.DestoryCar(carType, this);
            this.GetComponent<BoxCollider>().enabled = false;
            TimeTool.Instance.Delay(2f, () => { this.GetComponent<BoxCollider>().enabled = true; });
        }
    }

}
