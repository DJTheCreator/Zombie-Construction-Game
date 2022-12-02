using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int speed;
    private Rigidbody2D rb, heldObjectRB;
    private float xInput, yInput;
    public Sprite[] directionalSprites;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal") * Time.fixedDeltaTime * speed;
        yInput = Input.GetAxisRaw("Vertical") * Time.fixedDeltaTime * speed;
        
        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector2.right * xInput + Vector2.up * yInput);
    }

    
}
