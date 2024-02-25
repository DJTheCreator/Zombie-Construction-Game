using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furnace : MonoBehaviour
{
    private Vector2 furnacePos;
    private Tuple<String, float> result;
    private bool isSmelting; //Defaults to false
    private float startTime;
    [SerializeField] private GameObject progressBarFill;

    void Start()
    {
        furnacePos = gameObject.transform.position;
        progressBarFill.GetComponentInParent<SpriteRenderer>().enabled = false;
    }

    void Update()
    {
        ProgressBarAnimation();
    }

    //Takes a GameObject.name and returns a path for Resources.load<GameObject>(path) and a smelting time as a float
    private Dictionary<String, Tuple<String, float>> smeltingRecipes = new Dictionary<String, Tuple<String, float>>()
    {
        {"Raw Iron", Tuple.Create("Iron Bar", 2f)}
    };

    public void Smelt(GameObject inputMaterial)
    {
        result = smeltingRecipes[inputMaterial.GetComponent<ObjectProperties>().getName()];
        //Item1 = output prefab path --- Item2 = smelting time (float)
        StartCoroutine(SmeltDelay(Resources.Load<GameObject>(result.Item1), result.Item2));
        
    }

    private void ProgressBarAnimation()
    {
        Vector3 localScale = progressBarFill.transform.localScale;
        if (isSmelting)
        {
            float elapsedTime = Time.time - startTime;
            float newTime = Mathf.Round(elapsedTime * 1000);
            if (newTime % 10 == 0)
            {
                localScale = new Vector2(newTime/(1000*result.Item2), localScale.y);
                progressBarFill.transform.localScale = localScale;
            }
        }
        else
        {
            progressBarFill.transform.localScale = new Vector2(0, progressBarFill.transform.localScale.y);
        }
    }
    
    IEnumerator SmeltDelay(GameObject outputMaterial, float smeltingTime)
    {
        progressBarFill.GetComponentInParent<SpriteRenderer>().enabled = true;
        startTime = Time.time;
        isSmelting = true;
        yield return new WaitForSeconds(smeltingTime);
        isSmelting = false;
        progressBarFill.GetComponentInParent<SpriteRenderer>().enabled = false;
        Instantiate(outputMaterial, furnacePos, Quaternion.identity);
    }
}
