using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public void PlayGame() {
        SceneManager.LoadScene("SampleScene");
    }


    public void quit() {
        Application.Quit();
    }

    public void Restart() {
        SceneManager.LoadScene("SampleScene");
    }

    public void NextLevel() {
        SceneManager.LoadScene("Level2");
    }
}
