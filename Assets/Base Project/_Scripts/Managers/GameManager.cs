using System;
using Base_Project._Scripts.Game_Events;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //   private int sceneLoaded;
    //   public string UIPanelTagToShow;

    private int LastLevel;
    private int LastScene;
    public GameEventWithString LoadLevel;
    public GameEvent WonGame;

    [Serializable]
    public struct LevelParms
    {
        public int fishCount;
        public int fishChameleonCount;
        public float maxSpeed;
        public int levelSecondsDuration;
    }

    [SerializeField] public LevelParms[] myLevelParms;

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
        DontDestroyOnLoad(gameObject);
    }


    // Click to exit the app entirely
    public void QuitApplication()
    {
        Debug.Log("QUITTING @ " + Time.timeSinceLevelLoad);

#if UNITY_EDITOR || UNITY_EDITOR_64
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_WEBGL
#else
			Application.Quit();
#endif
    }

    public void LoadNextLevel()
    {
        if (LastLevel < myLevelParms.Length)
        {
            LoadSceneLevel(LastLevel + 1);
        }
        else
        {
            //Display Won GAME!
            WonGame.Raise();
        }
        
    }

    public void RestartCurrentLevel()
    {
        LoadSceneLevel(LastLevel);
    }

    public void LoadSceneLevel(int levelToLoad)
    {
        string parms = levelToLoad.ToString() + "|" +
                       myLevelParms[levelToLoad - 1].fishCount.ToString() + "|" +
                       myLevelParms[levelToLoad - 1].fishChameleonCount.ToString() + "|" +
                       myLevelParms[levelToLoad - 1].maxSpeed.ToString() + "|" +
                       myLevelParms[levelToLoad - 1].levelSecondsDuration.ToString();


        LoadLevel.Raise(parms);
        LastLevel = levelToLoad;
    }
}