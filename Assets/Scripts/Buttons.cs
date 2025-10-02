using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("Level");
    }

    public void HelpButton()
    {
        SceneManager.LoadScene("Help Menu");
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits Menu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }

    public void BackButton()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
