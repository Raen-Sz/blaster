﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public int sceneToLoad;

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
