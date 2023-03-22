using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinonPlayerTouch : MonoBehaviour
{
    public CanvasGroup VictoryPanelGroup;

    private void Start()
    {
        VictoryPanelGroup.alpha = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            VictoryPanelGroup.alpha = 1;
        }
    }


}
