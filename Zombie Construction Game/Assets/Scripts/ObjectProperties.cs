using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectProperties : MonoBehaviour
{
    public bool isMaterial, isFurnace;
    enum OreType { None, Iron, Gold, Silver }
    [SerializeField] OreType oreType;
    [SerializeField] private String baseName;

    public String GetOreType()
    {
        return oreType.ToString();
    }

    public String getName()
    {
        return baseName;
    }
    
    //TODO create properties file for furnace: isSmelting, finishedSmelting trigger, etc
}
