using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPopup : MonoBehaviour
{
    [SerializeField] Slider speedSlider;
    [SerializeField] UIController uiController;

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
        uiController.OnSettingsClosed();
    }

    public void OnSubmitText(string text)
    {
        Debug.Log("OnSubmitText: " + text);
    }

    public void OnSpeedChanged(float speed)
    {
        float newSpeed = speedSlider.value;
        Debug.Log("Speed Changed: " + newSpeed);
        Messenger<float>.Broadcast(GameEvent.SPEED_CHANGED, newSpeed);
    }
}
