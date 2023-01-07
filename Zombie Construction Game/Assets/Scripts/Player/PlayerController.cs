using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;
    private Rigidbody2D rb, heldObjectRB;
    private float xInput, yInput;
    [SerializeField] private float rotationSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Have the player start the scene facing down
        rb.MoveRotation(180);
    }

    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime * speed;
        yInput = Input.GetAxisRaw("Vertical") * Time.fixedDeltaTime * speed;
        
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.right * xInput + Vector2.up * yInput);
        RotateInDirectionOfMovement();
    }

    void RotateInDirectionOfMovement()
    {   //If moving
        if (xInput + yInput != 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(transform.forward, new Vector2(xInput, yInput));
            Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
            
            rb.MoveRotation(rotation);
        }
    }
    
}
