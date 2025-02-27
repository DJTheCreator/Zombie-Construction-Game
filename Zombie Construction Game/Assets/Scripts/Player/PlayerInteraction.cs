using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private Rigidbody2D heldObjectRB, selectedObjectRB;
    private bool isGrabbing, furnacePresent, stationPresent, orePresent;
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
        
        //The interaction area only sees objects that are in the Usable layer
        for (int i = 0; i < interactionArea.Length; i++)
        {
            if (interactionArea.Length > 0)
            {
                if (interactionArea[i].GetComponent<ObjectProperties>().isFurnace)
                {
                    furnacePresent = true;
                    selectedObjectRB = interactionArea[i].GetComponent<Rigidbody2D>();
                } else if (interactionArea[i].GetComponent<ObjectProperties>().isStation) //Not furnace but still station
                {
                    stationPresent = true;
                    selectedObjectRB = interactionArea[i].GetComponent<Rigidbody2D>();
                }
                else
                {
                    stationPresent = false;
                    furnacePresent = false;
                }
                if (interactionArea[i].GetComponent<ObjectProperties>().GetOreType() != "None")
                {
                    orePresent = true;
                    selectedObjectRB = interactionArea[i].GetComponent<Rigidbody2D>();
                }
                else
                {
                    orePresent = false;
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
            FurnaceCheck();
        } else if (Input.GetKeyDown(KeyCode.E))
        {
            StationCheck();
        }

        if (isGrabbing) {Grab();}

        if (!isGrabbing && Input.GetKeyDown(KeyCode.F) && orePresent)
        {
            StartCoroutine(HitOre(0.48f));
        }

    }
    
    void Grab()
    {
        heldObjectRB.position = interactionPoint.position;
    }

    void FurnaceCheck()
    {
        if(furnacePresent)
        {
            //This is the code for when you place something into the furnace
            if (heldObjectRB.GetComponent<ObjectProperties>().isMaterial)
            {
                Debug.Log("You placed " + heldObjectRB.name + " into the furnace");
                //Selected Object -> Furnace
                selectedObjectRB.GetComponentInParent<Furnace>().Smelt(heldObjectRB.gameObject);
                Destroy(heldObjectRB.gameObject);
            }
        }
    }

    void StationCheck()
    {
        if (stationPresent)
        {
            //All stations inherit from the abstract class Station.cs
            //This contains the abstract EnterInteraction method which will call the specific station code
            selectedObjectRB.gameObject.GetComponent<ObjectProperties>().getStationScript().EnterInteraction();
        }
    }

    public Rigidbody2D GetCurrentObject()
    {
        return selectedObjectRB;
    }

    public bool GetIsGrabbing()
    {
        return isGrabbing;
    }

    IEnumerator HitOre(float time)
    {
        yield return new WaitForSeconds(time);
        selectedObjectRB.GetComponentInParent<OreProperties>().GetHit();
    }
}
