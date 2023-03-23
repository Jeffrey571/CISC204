using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    private bool GamePaused;

    // Start is called before the first frame update
    void Start()
    {
        this.GamePaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!this.GamePaused)
        {
            Messenger.Broadcast(GameEvent.MOVE_ENEMIES);
        }
    }

    public void PauseGame(bool isPaused)
    {
        this.GamePaused = isPaused;
    }
}
