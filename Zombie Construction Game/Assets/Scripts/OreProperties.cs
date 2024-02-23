using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreProperties : MonoBehaviour
{
    [SerializeField] private int oreHealth;
    public GameObject OreToDrop;

    public void GetHit()
    {
        oreHealth--;
        Debug.Log(oreHealth);

        if (oreHealth <= 0)
        {
            DropOre();
            Destroy(GetComponentInParent<Rigidbody2D>().gameObject);
        }
    }

    void DropOre()
    {
        Instantiate(OreToDrop, GetComponentInParent<Rigidbody2D>().position, Quaternion.identity);
    }
}
