using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
  public void ReloadGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1; // as we made it 0 when our player died so makinfit 1 agian on reloading
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
