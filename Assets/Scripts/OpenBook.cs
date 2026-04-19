using UnityEngine;
using UnityEngine.SceneManagement;

public class ToggleBookScene : MonoBehaviour
{
    private string Book = "Book";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Scene bookScene = SceneManager.GetSceneByName(Book);

            if (bookScene.isLoaded)
            {
                // Close overlay
                SceneManager.UnloadSceneAsync(Book);
            }
            else
            {
                // Open overlay
                SceneManager.LoadScene(Book, LoadSceneMode.Additive);
            }
        }
    }
}