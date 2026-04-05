using UnityEngine;
using UnityEngine.SceneManagement;

public class CloseBookScene : MonoBehaviour
{
    private string Book = "Book";  
    private string Game = "Game";   

    void Start()
    {
        Book = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
         if (Input.GetKeyDown(KeyCode.O))
        {
            string currentScene = SceneManager.GetActiveScene().name;

            if (currentScene == Book)
            {
                SceneManager.LoadScene(Game);
            }
        
        }
    }
}
