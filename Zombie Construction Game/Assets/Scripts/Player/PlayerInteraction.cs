using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Rigidbody2D heldObjectRB;
    private bool isGrabbing, furnacePresent = false;
    [Header("Interaction")] 
    public KeyCode interactKey;
    public float interactionPointRadius;
    public LayerMask interactable;
    public Transform interactionPoint;
    private RaycastHit2D grabbingArea;
    private Collider2D[] interactionArea;
    
    // Start is called before the first frame update
    void Start()
    {
        isGrabbing = false;
    }

    // Update is called once per frame
    void Update()
    {
        grabbingArea = Physics2D.CircleCast(interactionPoint.position, interactionPointRadius, Vector2.zero, Mathf.Infinity, interactable);
        interactionArea = Physics2D.OverlapCircleAll(interactionPoint.position, interactionPointRadius, interactable);

        for (int i = 0; i < interactionArea.Length; i++)
        {
            if (interactionArea.Length > 0)
            {
                if (interactionArea[i].GetComponent<ObjectProperties>().isFurnace)
                {
                    furnacePresent = true;
                }
                else
                {
                    furnacePresent = false;
                }
            }
        }
        
        //Debug.Log(grabbingArea.rigidbody.GetComponent<ObjectProperties>().isMaterial);
        if(!isGrabbing && Input.GetKeyDown(KeyCode.Space) && grabbingArea.rigidbody != null && grabbingArea.rigidbody.GetComponent<ObjectProperties>().isMaterial)
        {
            isGrabbing = !isGrabbing;
            heldObjectRB = grabbingArea.rigidbody;
        } else if(isGrabbing && Input.GetKeyDown(KeyCode.Space) && grabbingArea.rigidbody != null)
        {
            isGrabbing = !isGrabbing;
            furnaceCheck();
        }

        if (isGrabbing)
        {
            Grab();
        }
    }
    
    void Grab()
    {
        heldObjectRB.position = interactionPoint.position;
    }

    void furnaceCheck()
    {
        if(furnacePresent)
        {
            //This is the code for when you place something into the furnace
            if (heldObjectRB.GetComponent<ObjectProperties>().isMaterial)
            {
                Debug.Log("You placed " + heldObjectRB.name + " into the furnace");
            }
        }
    }
}
