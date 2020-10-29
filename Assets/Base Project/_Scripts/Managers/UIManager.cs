using System;
using System.Collections;
using System.IO;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NAMESPACE
{
    public class UIManager : MonoBehaviour
    {
        public GameObject
            SettingsPausePanel; //treating this UI slightly differently as during it's presentation, we'll stop time

        public float buttonHoldTimeToQuit = 1f;
        public GameObject[] panelsToManage;
        public GameEvent QuitEvent;
        private bool isPaused;

        public void SwitchToPanel(string panelToPresent)
        {
            foreach (GameObject g in panelsToManage)
            {
                g.SetActive(g.gameObject.name.Equals(panelToPresent));
            }
        }

        IEnumerator ShowCreditsBeforeExit()
        {
            SwitchToPanel("CreditsPanel");
                        yield return new WaitForSeconds(3.0f);
                        QuitEvent.Raise();
        }

        public void InitiateExitGame()
        {
            StartCoroutine(ShowCreditsBeforeExit());
        }

        // Counts time while esc button is being held down, eventually resulting in app being exited.  Cancelled when esc is released early
        IEnumerator QuitGameTimer()
        {
            // Wait as the player holds down the esc key until quit time
            yield return new WaitForSecondsRealtime(buttonHoldTimeToQuit);
            Debug.Log("QUITTING @ " + Time.timeSinceLevelLoad + " with esc key");
            InitiateExitGame();
        }

        public void GameStarted()
        {
            foreach (GameObject g in panelsToManage)
            {
                g.SetActive(false);
                isPaused = false;
            }
        }

        public void GameEnded()
        {
            Debug.Log("Unloading Scene");
            //Note, below doesn't work if there is no Scene that can be made active, and we're on the last scene..
            // Scene initialScene = SceneManager.GetSceneByBuildIndex(0);
            // SceneManager.SetActiveScene(initialScene);
            // SceneManager.UnloadSceneAsync(1);
        }

        private void Start()
        {
            SwitchToPanel("TitlePanel");
        }

        private void Update()
        {
            // When the esc key is pressed
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Start counting to quit time
                StartCoroutine("QuitGameTimer");
            } // When the esc key is released
            else if (Input.GetKeyUp(KeyCode.Escape))
            {
                // Stop counting to quit time
                StopCoroutine("QuitGameTimer");
            }

            // When the esc key is pressed
            if (Input.GetKeyDown(KeyCode.P))
            {
                PauseAndUnpause();
            }
        }

        // Alternates between pause and unpaused statuses
        public void PauseAndUnpause()
        {
            isPaused = !isPaused;
            Debug.Log("Pause state: " + isPaused);
            Time.timeScale = isPaused ? 0f : 1f;
            SettingsPausePanel.SetActive(isPaused);
        }
    }
}