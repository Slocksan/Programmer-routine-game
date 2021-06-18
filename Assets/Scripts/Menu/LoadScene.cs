using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void SceneToLoad(int numberOfScene)
    {
        SceneManager.LoadScene(numberOfScene);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
