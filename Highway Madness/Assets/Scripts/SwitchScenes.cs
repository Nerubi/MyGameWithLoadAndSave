using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class SwitchScenes : MonoBehaviour
{


    public void startGame()
    {
        SceneManager.LoadScene(1);
    }

    public void highScore()
    {
        SceneManager.LoadScene(2);
    }

    public void EndGame()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
