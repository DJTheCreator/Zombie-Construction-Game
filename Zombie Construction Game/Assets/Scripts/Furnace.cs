using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : MonoBehaviour
{
    private Vector2 furnacePos;
    private GameObject result;

    void Start()
    {
        furnacePos = gameObject.transform.position;
    }
    
    //Takes a GameObject.name and returns a path for Resources.load<GameObject>(path)
    private Dictionary<String, String> smeltingRecipes = new Dictionary<String, String>()
    {
        {"Raw Iron", "Iron Bar"}
    };

    public void Smelt(GameObject inputMaterial)
    {
        result = Resources.Load<GameObject>(smeltingRecipes[inputMaterial.GetComponent<ObjectProperties>().getName()]);
        StartCoroutine(smeltDelay(result, 2f));
    }
    
    IEnumerator smeltDelay(GameObject outputMaterial, float smeltingTime)
    {
        yield return new WaitForSeconds(smeltingTime);
        Instantiate(outputMaterial, furnacePos, Quaternion.identity);
    }
}
