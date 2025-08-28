using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1.0f;
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Game()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1.0f;
    }
    public void Quit()
    {
        Application.Quit();
    }
}
