using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuilding : MonoBehaviour
{
    public GameObject objectToPlace;
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(objectToPlace, gameObject.transform.position, Quaternion.identity);
        }
        if (Input.GetKey(KeyCode.F))
        {
            animator.SetBool("IsPunching", true);
        }
        else
        {
            animator.SetBool("IsPunching", false);
        }
    }
}
