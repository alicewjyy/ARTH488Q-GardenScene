using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnEvent : MonoBehaviour
{
    public string scene;

    public void LoadScene()
    {
        SceneManager.LoadScene(scene);
    }
}