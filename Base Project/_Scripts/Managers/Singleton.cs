using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace baseProject
{
	public class Singleton : MonoBehaviour
	{
		[RuntimeInitializeOnLoadMethod]
		static void OnRuntimeMethodLoad()
		{
			// Get the current scene so that it can remain active even after the "_Managers" scene is loaded
			// Scene initialScene = SceneManager.GetActiveScene();
			// SceneManager.LoadScene("_UICanvases", LoadSceneMode.Additive);
			// SceneManager.SetActiveScene(initialScene);
		}

		/*	The single instance of a singleton (note, this assumse there will only be one singleton EVER.
			In this case, the "Managers" prefab object.  If you want multiple singletons, I suggest making them children of "Managers".
		*/
		public static Singleton Instance { get; private set; }

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
	}
}