using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Function to start the game
    public void StartGame()
    {
        SceneManager.LoadScene("World");
    }

    // Function to quit the game
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit(); 
    }
}
