using System;
using System.Collections;
using System.Collections.Generic;
using Base_Project._Scripts.Game_Events;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace baseProject
{
	public class SceneLoader : MonoBehaviour
	{
		bool isLoading = false;
		private GameObject UICamera;
		public GameEventWithInt SceneLoaded;

	// When the button is clicked, the new button will be loaded
		public void StartSceneLoad(int level)
		{
			if (!isLoading)
			{
				StartCoroutine(LoadScene(level));
			}
		}

		// New level is loaded asynchronously in case it's a very large level. Can add loading effects here.
		IEnumerator LoadScene(int level)
		{
			isLoading = true;
			AsyncOperation async = SceneManager.LoadSceneAsync(level);

			while (!async.isDone)
			{
				yield return new WaitForSeconds(0.1f);
			}

			isLoading = false;
			SceneLoaded.Raise(level);

		}
		
		
	}
}

