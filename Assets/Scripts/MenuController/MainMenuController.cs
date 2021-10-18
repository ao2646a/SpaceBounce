using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public void playLevelOne()
    {
        SceneManager.LoadScene("Grass1");
    }

    public void playLevelTwo()
    {
        SceneManager.LoadScene("Isa");
    }

    public void playLevelThree()
    {
        SceneManager.LoadScene("Ari");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
