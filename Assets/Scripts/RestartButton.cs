using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void Load()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }
}
