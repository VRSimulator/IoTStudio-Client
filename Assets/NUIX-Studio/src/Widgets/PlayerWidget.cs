using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWidget : ItemWidget
{

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        InitWidget();
    }

    private void InitWidget()
    {
        itemController.updateItem?.Invoke();
    }

    public void OnSetItem(bool play)
    {
        itemController.SetItemStateAsPlayerPlayPause(play);
    }

    public override void OnUpdate()
    {
        //throw new System.NotImplementedException();
    }
}
