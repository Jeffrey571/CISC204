using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMover : MonoBehaviour
{
    private CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        this.characterController = this.gameObject.GetComponent<CharacterController>();       
    }

    // Update is called once per frame
    void Update()
    {
        this.characterController.Move(new Vector3(-2 * Time.deltaTime, 0, 0));
    }
}
