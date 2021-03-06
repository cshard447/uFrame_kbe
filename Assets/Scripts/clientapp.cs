using UnityEngine;
using System;
using System.Collections;
using System.Reflection;
using KBEngine;
using uFrame.MVVM;

public class clientapp : KBEMain 
{
    public override void initKBEngine()
    {
        base.initKBEngine();
        uFrame.Kernel.uFrameKernel.KbeClientapp = this;
        gameapp.getInitArgs().EventAggregator = uFrame.Kernel.uFrameKernel.EventAggregator;
    }
}
