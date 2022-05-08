﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum ClientEvent
{

    TEXT,
    GAMEOVER,

    SOUCECHANGE,//分数改变
    CAMERACHANGE, // 视角改变

    SOUCETEXT,//汽车销毁时显示

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
