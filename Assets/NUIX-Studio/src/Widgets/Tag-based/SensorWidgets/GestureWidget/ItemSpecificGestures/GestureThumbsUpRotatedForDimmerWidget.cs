using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;
/// <summary>
/// Unique Gesture item of Thumbs up. Its value - the angle between the thumb and Y-axis.
/// </summary>
public class GestureThumbsUpRotatedForDimmerWidget : GestureWidget
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
        return !HandPoseUtils.IsThumbGrabbing(_handedness) && HandPoseUtils.IsMiddleGrabbing(_handedness) && HandPoseUtils.IsIndexGrabbing(_handedness);
    }


    public bool TryGetNormalizedValue(out uint normalizedValue)
    {
        if (TryGetGestureValue(out float value))
        {
            normalizedValue = (uint)value * 10 / 9;
            return ((value > 2f) && (value < 100f)) ? true : false;
        }
        normalizedValue = 0;
        return false;
    }

    public override bool TryGetGestureValue(out float value)
    {
        value = 0f;
        if (!GestureCondition()) return false;

        MixedRealityPose palmPose = MixedRealityPose.ZeroIdentity;
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Palm, _handedness, out MixedRealityPose palmpose))
        {
            palmPose = palmpose;
        }
        else
        {
            return false;
        }
        value = Vector3.Angle(palmPose.Up, this.transform.up);
        if (_handedness == Handedness.Left) value = value * -1f;
        return true;
    }


    public override void OnSetItem()
    {
        if (TryGetNormalizedValue(out uint value))
        {
            itemController.SetItemStateAsDimmer((int)value);
        }
    }
}
