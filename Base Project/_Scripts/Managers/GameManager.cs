using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int sceneLoaded;
    public string UIPanelTagToShow;
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // If a second version is created, delete it immediately
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;
        // Make the singleton persist between scenes
        DontDestroyOnLoad(this.gameObject);
    }
 

    // Click to exit the app entirely
    public void QuitApplication()
    {
        Debug.Log("QUITTING @ " + Time.timeSinceLevelLoad );

#if UNITY_EDITOR || UNITY_EDITOR_64
        UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
			
    }
 
}