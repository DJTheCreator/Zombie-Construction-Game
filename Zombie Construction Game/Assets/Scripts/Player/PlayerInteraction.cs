using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Rigidbody2D heldObjectRB;
    private bool isGrabbing;
    [Header("Interaction")]
    public float interactionPointRadius;
    public LayerMask interactable;
    public Transform interactionPoint;
    public RaycastHit2D grabbingArea;
    public Collider2D interactionArea;
    
    // Start is called before the first frame update
    void Start()
    {
        isGrabbing = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Try using CircleCastAll and grabbing the first object. This way you can tell if there is more than one object and you can create more complex interactions
        //Ex: putting materials into a furnace or placing them onto a counter.
        grabbingArea = Physics2D.CircleCast(interactionPoint.position, interactionPointRadius, Vector2.zero, Mathf.Infinity, interactable);
        interactionArea = Physics2D.OverlapCircle(interactionPoint.position, interactionPointRadius, interactable);

        Debug.Log(grabbingArea.rigidbody);
        if(!isGrabbing && Input.GetKeyDown(KeyCode.Space) && grabbingArea.rigidbody != null)
        {
            isGrabbing = !isGrabbing;
            heldObjectRB = grabbingArea.rigidbody;
        } else if(isGrabbing && Input.GetKeyDown(KeyCode.Space) && grabbingArea.rigidbody != null)
        {
            isGrabbing = !isGrabbing;
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
}
