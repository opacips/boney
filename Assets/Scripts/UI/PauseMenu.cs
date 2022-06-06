using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject restartMenu;
    [SerializeField] private GameObject exitMenu;

    
    private void Start()
    {
        pauseMenu.SetActive(false);
        restartMenu.SetActive(false);
        exitMenu.SetActive(false);
    }


    private void Update()
    {
        bool pauseKey = Input.GetKeyDown(KeyCode.Escape);

        if (pauseKey)
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void ResumeR()
    {
        restartMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void ResumeE()
    {
        exitMenu.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void clickRestart()
    {
        restartMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void clickExit()
    {
        exitMenu.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void RestartScene()
    {
        restartMenu.SetActive(false);
        StartCoroutine(RestartTime(.5f)); 
        Time.timeScale = 1f;
    }

    public void SaveAndExit()
    {
        string activeScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("LevelSaved", activeScene);
        Debug.Log("Level Saved!");

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    private IEnumerator RestartTime(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentScene);
        Debug.Log("Waited seconds: " + Time.time);
    }

    
}