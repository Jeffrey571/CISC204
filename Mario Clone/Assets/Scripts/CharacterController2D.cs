using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float speed = 2000f;
    public float jumpforce = 10f;
    private Vector2 desiredVelocity = Vector2.zero;
    private Rigidbody2D Body;
    private BoxCollider2D boxcollider;
    
    void Start()
    {
        Body = GetComponent <Rigidbody2D>();
        boxcollider = GetComponent <BoxCollider2D>();
    }


    void Update()
    {
        //Gather player input.

        float HorizontalInput = Input.GetAxis("Horizontal");
        desiredVelocity = new Vector2(HorizontalInput * speed * Time.deltaTime,Body.velocity.y);
        Body.velocity = desiredVelocity;

        //Checking if player is grounded.

        Vector3 max = boxcollider.bounds.max;
        Vector3 min = boxcollider.bounds.min;
        Vector2 firstcorner = new Vector2(max.x, min.y - 0.1f);
        Vector2 secondcorner = new Vector2(min.x, min.y - 0.2f);
        Collider2D hit = Physics2D.OverlapArea(firstcorner, secondcorner);
        bool isgrounded = false;
        if (hit != null)
        {
            isgrounded = true;
        }
        //Handle slopes and one-way platforms.
        Body.gravityScale = (isgrounded && HorizontalInput == 0f) ? 0 : 1;
        //Handle jumps.

        if (isgrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Body.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        }
    }
}
