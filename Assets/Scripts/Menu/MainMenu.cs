using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene("Level_1");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
