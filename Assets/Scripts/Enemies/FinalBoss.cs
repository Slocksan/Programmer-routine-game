using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalBoss : MonoBehaviour
{
    private void OnDestroy()
    {
        SceneManager.LoadScene(0);
    }
}
