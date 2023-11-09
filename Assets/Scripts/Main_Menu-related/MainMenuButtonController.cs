using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenuButtonController : MonoBehaviour
{
    public GameObject settings;
    public GameObject playButton;
    public GameObject quitButton;
    public GameObject settingsButton;
    public GameObject creditsButton;

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void MainGame()
    {
        SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Credits()
    {
        SceneManager.LoadScene(3);
    }

    public void Settings()
    {
        // Disable Play, Quit, and HowToPlay buttons
        playButton.SetActive(false);
        quitButton.SetActive(false);
        gameObject.SetActive(false);
        creditsButton.SetActive(false);

        // Enable HowToPlayScreen and all its children
        if (settings != null)
        {
            settings.SetActive(true);

            foreach (Transform child in settings.transform)
            {
                child.gameObject.SetActive(true);
            }
        }
        else
        {
            Debug.LogError("HowToPlayScreen object is not assigned!");
        }
    }

    public void ToggleButton()
    {
        // Toggle the state of the current button
        gameObject.SetActive(!gameObject.activeSelf);

        // Toggle the state of HowToPlayScreen and all its children
        if (settings != null)
        {
            settings.SetActive(!settings.activeSelf);

            foreach (Transform child in settings.transform)
            {
                child.gameObject.SetActive(!child.gameObject.activeSelf);
            }
        }
        else
        {
            Debug.LogError("HowToPlayScreen object is not assigned!");
        }

        // Toggle the state of Play, Quit, and HowToPlay buttons
        playButton.SetActive(!playButton.activeSelf);
        quitButton.SetActive(!quitButton.activeSelf);
        settingsButton.SetActive(!settingsButton.activeSelf);
    }

    public void Retry()
    {
        // Load Scene 2
        SceneManager.LoadScene(2);
    }
}
