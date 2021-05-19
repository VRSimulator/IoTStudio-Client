using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine;

#if OCULUSINTEGRATION_PRESENT
#endif
/// <summary>
/// One hand gesture basic class
/// </summary>
public abstract class GestureWidget : ItemWidget
{
    public Handedness _handedness;

    [SerializeField] [Tooltip("Whether it should be connected to a virtual Sensor")] public bool isTrigger;
    [SerializeField] [Tooltip("The Sensor Widget to be triggered when the gesture is performed")] public SensorWidget _trigger;

    public GestureWidget(Handedness handedness = Handedness.Right)
    {
        _handedness = handedness;
    }


    /// <summary>
    /// Check the requirements, ex. which fingers should be grabbing
    /// </summary>
    /// <returns></returns>
    public abstract bool GestureCondition();
    
    /// <summary>
    /// The value to assign for gesture
    /// Override in your gesture class
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public virtual bool TryGetGestureValue(out float value)
    {
        value = 0f;
        return false;
    }


    /// <summary>
    /// Trigger virtual sensors based on the Gesture condition
    /// </summary>
    public void GestureEventTrigger()
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

    public override void Start()
    {
        base.Start();
    }

    /// <summary>
    /// Update is called every frame
    /// Check the gesture 
    /// </summary>
    public override void Update()
    {
        base.Update();
        if (isTrigger) GestureEventTrigger();
    }


    /// <summary>
    /// OnUpdate is called once the item state is updated on the server
    /// For Gestures this method should return no value
    /// </summary>
    public override void OnUpdate()
    {
        //throw new System.NotImplementedException();
    }

    /// <summary>
    /// Is called to set the item value on the server
    /// Override it with your method for the specific item
    /// </summary>
    public virtual void OnSetItem()
    {

    }
}
