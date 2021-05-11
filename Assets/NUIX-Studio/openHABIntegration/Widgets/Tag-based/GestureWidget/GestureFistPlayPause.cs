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

    void Update()
    {
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

    public void OnSetItem()
    {
        if (GestureCondition())
        {
            itemController.SetItemStateAsPlayerPlayPause(true);
        }
    }

    public override bool TryGetGestureValue(out float value)
    {
        value = 0;
        return true;
    }

    public override void GestureEventTrigger()
    {
       
    }
}
