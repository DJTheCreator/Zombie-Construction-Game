using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectProperties : MonoBehaviour
{
    public bool isMaterial, isFurnace, isStation, takesInput;
    enum OreType { None, Iron, Gold, Silver }
    [SerializeField] OreType oreType;
    [SerializeField] private String baseName;
    [SerializeField] Station stationScript;

    public String GetOreType()
    {
        return oreType.ToString();
    }

    public String getName()
    {
        return baseName;
    }

    public Station getStationScript()
    {
        return stationScript;
    }

    //TODO create properties file for furnace: isSmelting, finishedSmelting trigger, etc
}
