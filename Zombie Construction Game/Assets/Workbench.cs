using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Workbench : Station
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void EnterInteraction()
    {
        //TODO Open GUI menu for interacting with workbench (eg select recipe and then put materials into bench)
        Debug.Log("Opened workbench GUI");
    }
}
