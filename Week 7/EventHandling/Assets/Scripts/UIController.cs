using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] SceneController sceneController;
    [SerializeField] SettingsPopup settingsPopup;

    // Start is called before the first frame update
    void Start()
    {
        settingsPopup.Close();
    }    
    

    public void OnOpenSettings()
    {
        sceneController.PauseGame(true);
        settingsPopup.Open();
    }

    public void OnSettingsClosed()
    {
        sceneController.PauseGame(false);
    }
}
