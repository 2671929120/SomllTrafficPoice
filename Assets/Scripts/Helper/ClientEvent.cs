﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum ClientEvent
{

    TEXT,
    GAMEOVER,//游戏结束

    SOUCECHANGE,//分数改变
    CAMERACHANGE, // 视角改变
    CAMERAANGLE, // 视角改变
    TIPSSHOW, //提示信息更新 
    SOUCETEXT,//汽车销毁时显示
    TIMESHOW,//倒计时

    WESTMIDDENMOVEBEFOR,
    WESTLEFTMOVEBEFOR,
    WESTRIGHTMOVEBEFOR,

    EASTMIDDENMOVEBEFOR,
    EASTLEFTMOVEBEFOR,
    EASTRIGHTMOVEBEFOR,

    SOUTHMIDDENMOVEBEFOR,
    SOUTHLEFTMOVEBEFOR,
    SOUTHRIGHTMOVEBEFOR,

    NORTHMIDDENMOVEBEFOR,
    NORTHLEFTMOVEBEFOR,
    NORTHRIGHTMOVEBEFOR,

    WESTMIDDENMOVE,
    WESTLEFTMOVE,
    WESTRIGHTMOVE,

    EASTMIDDENMOVE,
    EASTLEFTMOVE,
    EASTRIGHTMOVE,

    SOUTHMIDDENMOVE,
    SOUTHLEFTMOVE,
    SOUTHRIGHTMOVE,

    NORTHMIDDENMOVE,
    NORTHLEFTMOVE,
    NORTHRIGHTMOVE,
}

