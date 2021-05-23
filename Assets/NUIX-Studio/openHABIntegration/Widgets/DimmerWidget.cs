﻿using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;
using UnityEngine.UI;




/// <summary>
/// Connect this class to a GameObject
/// Keeps the pinchslider value same to a dimmer item
/// </summary>
public class DimmerWidget : ItemWidget
{
    
    [Header("Widget Setup")]
    public PinchSlider _PinchSlider;


    public override void Start()
    {
        base.Start();
        InitWidget();
    }

    private void InitWidget()
    {
        if (_PinchSlider == null) _PinchSlider = GetComponent<PinchSlider>();
        itemController.updateItem?.Invoke();
    }

    /// <summary>
    /// When an item updates from server. This function is
    /// called from ItemController when Item is Updated on server.
    /// Begin with a check if Item and UI state is equal. Otherwise we
    /// might get flickering as the state event is sent after update from
    /// UI. This will Sync as long as Event Stream is online.
    /// </summary>
    public override void OnUpdate()
    {
        float value = itemController.GetItemStateAsDimmer();
        // Failed to parse the dimmer
        if (value == -1 || value > 100)
        {
            _PinchSlider.SliderValue = 0f;
        }
        else
        {
            _PinchSlider.SliderValue = value / 100f;
        }
    }

    /// <summary>
    /// Update item from UI. Call itemcontroller and update Item on server.
    /// If update is true, an event will be recieved. If state is equal no
    /// new UI update is necesarry. If not equal the PUT has failed and we need
    /// to revert UI state to server state.
    /// </summary>
    public void OnSetItem()
    {
        itemController.SetItemStateAsDimmer((int)(_PinchSlider.SliderValue * 100f));
    }

    /// <summary>
    /// Stop event listening from controller
    /// </summary>
    void OnDisable()
    {
        itemController.updateItem -= OnUpdate;
    }
}
