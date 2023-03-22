using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class face_mover : MonoBehaviour
{
    public float speed = 4.5f;
    public TMP_Text messageText;

    private HungerState howHungryAmI;
    private Rigidbody2D body;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        howHungryAmI = HungerState.Starving;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Pizza"))
        {
            Destroy(collision.gameObject);

            switch(howHungryAmI)
            {
                case HungerState.Starving:
                    howHungryAmI = HungerState.HalfFull;
                    messageText.text = "That was tasty.  Feed me more!";
                    break;
                case HungerState.HalfFull:
                    howHungryAmI = HungerState.NotHungry;
                    messageText.text = "I am so full!  Happy PI Day!";
                    break;
                case HungerState.NotHungry:
                    // Where did you find another thing to collide with?!
                    // Did you think I would eat more than one whole pizza today and add more pizza to the scene?!
                    // I like where your head is!  Happy PI Day!
                    break;
            }
        }
    }
}
