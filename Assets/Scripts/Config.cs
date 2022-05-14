using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Config
{
   

    //第一关
    public static Dictionary<int, List<string>> ConfigFirstLevel = new Dictionary<int, List<string>>
    {
        { 1,new List<string> {
            "Stap_2",
            "WestRightInit_2", "WestMiddleInit_2", "WestLeftInit_2" ,
            "EastRightInit_2", "EastMiddleInit_2", "EastLeftInit_2" ,
            "NorthRightInit_0", "NorthMiddleInit_2", "NorthLeftInit_2" ,
            "SouthRightInit_0", "SouthMiddleInit_2", "SouthLeftInit_2" } },
        
        { 18,new List<string> {"Tips_西方车道迎来高峰期", "WestLeftInit_10" , "WestRightInit_10" } },
        { 4,new List<string> { "Tips_各方车道开始通行" } },

        { 30,new List<string> {"WestMiddleInit_10", "WestLeftInit_10" , "WestRightInit_10" } }

    };
    public int WestLeftCarCount = 10;


    //第二关

    public static Dictionary<int, Dictionary<int, List<string>>> AllLevelConfig = new Dictionary<int, Dictionary<int, List<string>>>{
        {1,ConfigFirstLevel},
        {2,ConfigFirstLevel},
        {3,ConfigFirstLevel},
        {4,ConfigFirstLevel}



     };

    //汽车初始位置配置
    public static Vector3 WestLeftPos = new Vector3(-51.5f, 12.15f, -17.3f);
    public static Vector3 WestLeftRot = new Vector3(0, 90, 0); 

    public static Vector3 WestMiddlePos = new Vector3(-51.5f, 12.15f, -21.3f);
    public static Vector3 WestMiddleRot= new Vector3(0, 90, 0);

    public static Vector3 WestRightPos = new Vector3(-51.5f, 12.15f, -25.24f);
    public static Vector3 WestRightRot = new Vector3(0, 90, 0);    


    public static Vector3 EastRightPos = new Vector3(97.69f, 12.15f, -5.4f);
    public static Vector3 EastRightRot= new Vector3(0, -90, 0); 

    public static Vector3 EastMiddlePos = new Vector3(97.69f, 12.15f, -9.13f);
    public static Vector3 EastMiddleRot= new Vector3(0, -90, 0);

    public static Vector3 EastLeftPos = new Vector3(97.69f, 12.15f, -13.38f);
    public static Vector3 EastLeftRot = new Vector3(0, -90, 0);
    
    
    public static Vector3 SouthLeftPos = new Vector3(22.42f, 12.15f, -85.3f);
    public static Vector3 SouthLeftRot = new Vector3(0, 0, 0);

    public static Vector3 SouthMiddlePos = new Vector3(26.2f, 12.15f, -85.3f);
    public static Vector3 SouthMiddleRot = new Vector3(0, 0, 0);

    public static Vector3 SouthRightPos = new Vector3(30.13f, 12.15f, -85.3f);
    public static Vector3 SouthRightRot = new Vector3(0, 0, 0);
    
    
    public static Vector3 NorthLeftPos = new Vector3(18.25f, 12.15f, 80f);
    public static Vector3 NorthLeftRot = new Vector3(0, 180, 0);

    public static Vector3 NorthMiddlePos = new Vector3(14.42f, 12.15f, 80f);
    public static Vector3 NorthMiddleRot = new Vector3(0, 180, 0);

    public static Vector3 NorthRightPos = new Vector3(10.49f, 12.15f, 80f);
    public static Vector3 NorthRightRot = new Vector3(0, 180, 0);

}
