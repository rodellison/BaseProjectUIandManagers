using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace baseProject
{
    public class PauseAndQuit : MonoBehaviour
    {
        public float buttonHoldTimeToQuit = 0.75f;
        public List<int> unpauseableScenes;

        public GameObject pausePanel;
        public GameObject WonPanel;
        public GameObject LostPanel;

        private bool canPauseOnScene;
        private bool isPaused;

        private void Awake()
        {
            //	pausePanel = transform.Find("Pause Panel").gameObject;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private void Update()
        {
            // When the esc key is pressed
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                // Start counting to quit time
                StartCoroutine("QuitGameTimer");

                // Pause/Unpause the game (if current scene supports it
                canPauseOnScene = !unpauseableScenes.Contains(SceneManager.GetActiveScene().buildIndex);
                if ((!isPaused && canPauseOnScene) || isPaused)
                {
                    PauseAndUnpause();
                }
            }

            // When the esc key is released
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                // Stop counting to quit time
                StopCoroutine("QuitGameTimer");
            }
        }

        // Alternates between pause and unpaused statuses
        private void PauseAndUnpause()
        {
            Debug.Log("PauseAndUnpause called");
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0f : 1f;
            pausePanel.SetActive(isPaused);
        }

        // Prevents potential error of game being stuck in "pause mode" if loaded into a screen that way, automatically unpauses
        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Debug.Log("OnSceneLoaded called");
            isPaused = false;
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
            WonPanel.SetActive(false);
            LostPanel.SetActive(false);
        }

        // Counts time while esc button is being held down, eventually resulting in app being exited.  Cancelled when esc is released early
        IEnumerator QuitGameTimer()
        {
            // Wait as the player holds down the esc key until quit time
            yield return new WaitForSecondsRealtime(buttonHoldTimeToQuit);
            Debug.Log("QUITTING @ " + Time.timeSinceLevelLoad + " with esc key");

#if UNITY_EDITOR || UNITY_EDITOR_64
            UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif


            // If app doesn't quit (ie in Web Player) return to menu instead
            yield return new WaitForSeconds(0.1f);
            SceneManager.LoadScene(0);
            StopCoroutine("QuitGameTimer");
        }
    }
}