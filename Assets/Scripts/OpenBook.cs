using UnityEngine;
using UnityEngine.SceneManagement;

public class ToggleBookScene : MonoBehaviour
{
    private string Book = "Book";  
    private string Game = "Game";   

    void Start()
    {
        Game = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
         if (Input.GetKeyDown(KeyCode.O))
        {
            string currentScene = SceneManager.GetActiveScene().name;

            if (currentScene == Book)
            {
                // If currently in Book → go back
                SceneManager.LoadScene(Game);
            }
            else
            {
                // If in Main → open Book
                SceneManager.LoadScene(Book);
            }
        }
    }
}
