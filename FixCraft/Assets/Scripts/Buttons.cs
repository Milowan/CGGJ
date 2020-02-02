using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void LoadCutScene()
    {
        SceneManager.LoadScene(2);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
