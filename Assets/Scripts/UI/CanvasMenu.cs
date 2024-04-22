using AppodealAds.Unity.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasMenu : MonoBehaviour
{
    private DataSaver _dataSaver;

    private void Awake()
    {
        _dataSaver = FindObjectOfType<DataSaver>();
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void RestartLevel()
    {
        /*
        if (Appodeal.isLoaded(Appodeal.INTERSTITIAL))
        {
            Debug.Log("Interstitial ad is loaded. Showing interstitial ad.");
            Appodeal.show(Appodeal.INTERSTITIAL);
        }
        else
        {
            Debug.Log("Interstitial ad is not loaded.");
        }
        */
        _dataSaver.SavePlayerData();
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Reloading scene with index: " + currentSceneIndex);
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
