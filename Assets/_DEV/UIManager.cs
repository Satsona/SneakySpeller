using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
  public void StartButton()
    {
        Debug.Log("Starting Level 1");
        SceneManager.LoadScene("Level 1");
    }

    public void QuitButton()
    {
        Debug.Log("Closing the game");
        Application.Quit();
    }
}
