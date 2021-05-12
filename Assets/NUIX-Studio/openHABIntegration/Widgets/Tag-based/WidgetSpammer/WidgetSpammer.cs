using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WidgetSpammer : ItemWidget
{
    public override void OnUpdate()
    {
        //throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            GameObject WidgetGo = Instantiate(go, SemanticModel.getInstance().SpawnPosition, Quaternion.identity) as GameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
