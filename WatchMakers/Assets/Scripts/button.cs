using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class button : MonoBehaviour
{
    public void LoadSceneMode()
    {
        SceneManager.LoadScene("Puzzle1");
    }

    public void LoadSceneMode1()
    {
        SceneManager.LoadScene("Puzzle2");
    }

    public void LoadSceneMode2()
    {
        SceneManager.LoadScene("Interfaz");
    }
}
