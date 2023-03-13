using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F) && !GetComponentInParent<PlayerInteraction>().GetIsGrabbing())
        {
            animator.SetBool("IsPunching", true);
        }
        else
        {
            animator.SetBool("IsPunching", false);
        }
    }

    public Animator getAnimator()
    {
        return animator;
    }
}
