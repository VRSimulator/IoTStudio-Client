using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

/// <summary>
/// Connect this class to a GameObject
/// Keeps the image placed on a plane same to a image item
/// Received the image byte data in openHAB format 
/// and parses it for using in Unity
/// </summary>
public class ImageWidget : ItemWidget
{

    [Header("Widget Setup")]
    public GameObject imagePlane;

    private string imageState;
    public override void Start()
    {
        base.Start();
        InitWidget();


        
    }

    private void InitWidget()
    {
        itemController.updateItem?.Invoke();
    }

    public override void OnUpdate()
    {
        imageState = itemController.GetItemStateAsString();
        byte[] bytes = Convert.FromBase64String(imageState.Split(',')[1]);

        var tex = new Texture2D(1, 1);
        tex.LoadImage(bytes);
        imagePlane.GetComponent<MeshRenderer>().material.mainTexture = tex;

    }
}

