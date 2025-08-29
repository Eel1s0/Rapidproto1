using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public int attempt = 0;

    private static ButtonScript instance;

    private void Awake()
    {
        attempt = PlayerPrefs.GetInt("Attempts", 0);

        SceneManager.sceneLoaded += OnSceneLoaded;
        UpdateAttemptsUI();
    }
    public void Restart()
    {
        attempt++;
        PlayerPrefs.SetInt("Attempts", attempt);
        PlayerPrefs.Save();
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1.0f;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {


        UpdateAttemptsUI();
    }
    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
        PlayerPrefs.SetInt("Attempts", 0);
    }
    public void Game()
    {
        PlayerPrefs.SetInt("Attempts", 0);
        SceneManager.LoadScene("MainScene");
        Time.timeScale = 1.0f;
    }
    public void Quit()
    {
        Application.Quit();
    }
    private void UpdateAttemptsUI()
    {
        if (text != null)
            text.text = "Attempts: " + attempt;
    }
    private void OnDestroy()
    {

        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
