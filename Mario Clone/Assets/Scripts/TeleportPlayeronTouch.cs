using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayeronTouch : MonoBehaviour
{
    public Transform tptarget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D Body = collision.gameObject.GetComponent<Rigidbody2D>();
            //Body.MovePosition(tptarget.position);
            Body.position = tptarget.position;
        }
    }
}
