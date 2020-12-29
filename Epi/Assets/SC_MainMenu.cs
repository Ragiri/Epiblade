using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MainMenuButton();
    }

    public void PlayNowButton()
    {
        Debug.Log("Text: start");
        UnityEngine.SceneManagement.SceneManager.LoadScene("move");
    }

    public void CreditsButton()
    {
    }

    public void MainMenuButton()
    {
    }

    public void QuitButton()
    {
        Debug.Log("Text: quit");
        Application.Quit();
    }
}
