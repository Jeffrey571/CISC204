using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class face_mover : MonoBehaviour
{
    public float speed = 4.5f;

    private Rigidbody2D body;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        Vector2 movement = new Vector2(deltaX, body.velocity.y);
        body.velocity = movement;

        anim.SetFloat("speed", Mathf.Abs(deltaX));
        if(!Mathf.Approximately(deltaX, 0))
        {
            transform.localScale = new Vector3(-Mathf.Sign(deltaX), 1, 1);
        }
    }
}
