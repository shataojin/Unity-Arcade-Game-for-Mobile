using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndMenuController : MonoBehaviour
{
    public void BackToMainMenu()
    {

        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Debug.Log("quit working");
        Application.Quit();
    }

}
