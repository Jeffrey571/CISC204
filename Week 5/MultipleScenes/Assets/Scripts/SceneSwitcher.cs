using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void LoadSampleScene()
    {

    }

    public void LoadSceneOne()
    {
        SceneManager.LoadScene("SceneOne");
    }

    public void LoadSceneTwo()
    {
        SceneManager.LoadScene("SceneTwo");
    }
}
