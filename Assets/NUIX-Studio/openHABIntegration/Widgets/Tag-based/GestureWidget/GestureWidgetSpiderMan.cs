using Microsoft.MixedReality.Toolkit.Utilities;


/// <summary>
/// Index and pinky finger Not grabbing, Middle and ring finger grabbing
/// </summary>
public class GestureWidgetSpiderMan : GestureWidget
{
    public override bool GestureCondition()
    {
        float value = 0.7f;
        return HandPoseUtils.IsMiddleGrabbing(_handedness) & !HandPoseUtils.IsIndexGrabbing(_handedness) & (HandPoseUtils.RingFingerCurl(_handedness) > value) & (HandPoseUtils.PinkyFingerCurl(_handedness) < value);
    }
}