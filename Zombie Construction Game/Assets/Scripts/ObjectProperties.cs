using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectProperties : MonoBehaviour
{
    public bool isMaterial, isFurnace;
    enum OreType { None, Iron, Gold, Silver }
    [SerializeField] OreType oreType;
    
}
