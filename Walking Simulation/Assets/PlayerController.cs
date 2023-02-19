using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player controller moves the player. Inspired by Minecraft using wsad , computer mouse, and space bar.
public class PlayerController : MonoBehaviour
{
    public float walkspeed = 20f;
    public float gravity = -10f;
    public float jumpforce = 1000f;
    public float camerasensitivity = 1000f;
    public bool grounded = false;
    public Vector3 velocity = Vector3.zero;
    public Vector3 playerinput;
    public CharacterController controller;

    public Camera playercamera;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        grounded = controller.isGrounded;

        //Gathering player input
        playerinput = new Vector3(Input.GetAxis("Horizontal"),0f, Input.GetAxis("Vertical"));
        
        controller.Move(transform.TransformDirection(playerinput) * Time.deltaTime * walkspeed);

        // Set y velocity and jump.
        if(grounded && velocity.y < 0)
        {
            velocity.y = 0;
        }

        if(Input.GetButtonDown("Jump") && grounded)
        {
            //velocity.y += jumpforce;
        }
        // Finally move the character.
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    private void LateUpdate()
    {
        // Mouse Rotation (Up and/or Down) with camera
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * Time.deltaTime * camerasensitivity);
        float xroatation = Input.GetAxis("Mouse Y") * Time.deltaTime * camerasensitivity * -1f;
        playercamera.transform.Rotate(Vector3.right * xroatation);
    }

}
