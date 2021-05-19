using Microsoft.MixedReality.Toolkit.Utilities;

public class GestureWidgetSpiderMan : GestureWidget
{
    public override bool GestureCondition()
    {
        float value = 0.7f;
        return HandPoseUtils.IsMiddleGrabbing(_handedness) & !HandPoseUtils.IsIndexGrabbing(_handedness) & (HandPoseUtils.RingFingerCurl(_handedness) > value) & (HandPoseUtils.PinkyFingerCurl(_handedness) > value);
    }

    public override void GestureEventTrigger()
    {
        if (GestureCondition())
        {
            _trigger.SensorTrigger();
        }
        else
        {
            _trigger.SensorUntrigger();
       }
    }


    private void Update()
    {
        GestureEventTrigger();
    }

    public override void OnUpdate()
    {
        //throw new System.NotImplementedException();
    }

    public override bool TryGetGestureValue(out float value)
    {
        value = 0f;
        return false;
        //throw new System.NotImplementedException();
    }
}