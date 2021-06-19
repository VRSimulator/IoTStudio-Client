using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestureFistPlayPause : GestureWidget
{
    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
        OnSetItem();
    }

    public override bool GestureCondition()
    {
        return HandPoseUtils.IsThumbGrabbing(_handedness) && HandPoseUtils.IsMiddleGrabbing(_handedness) && HandPoseUtils.IsIndexGrabbing(_handedness);
    }

    public override void OnUpdate()
    {
        //throw new System.NotImplementedException();
    }

    public override void OnSetItem()
    {
        if (GestureCondition())
        {
            itemController.SetItemStateAsPlayerPlayPause(true);
        }
    }
}
