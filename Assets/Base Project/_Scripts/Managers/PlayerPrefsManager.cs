﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace baseProject
{
	public static class PlayerPrefsManager
	{
		[RuntimeInitializeOnLoadMethod]
		static void OnRuntimeMethodLoad()
		{
			if (!PlayerPrefs.HasKey("MasterVol"))
			{
				PlayerPrefs.DeleteAll();
				Init();
				Save();
			}
		}

		static void Init()
		{
			SetVolume("MasterVol", 0f);
			SetVolume("MusicVol", 0f);
			SetVolume("EffectsVol", 0f);
			SetVolume("InterfaceVol", 0f);
			
			SetMouseSensitivity("MouseXSensitivity", 1f);
			SetMouseSensitivity("MouseYSensitivity", 1f);
			
		}

		public static void Save()
		{
			Debug.Log("Saving Player Prefs");
			PlayerPrefs.Save();
		}

		public static void SetVolume(string volumeName, float vol)
		{
			PlayerPrefs.SetFloat(volumeName, vol);
		}

		public static float GetVolume(string volumeName)
		{
			var vol = PlayerPrefs.GetFloat(volumeName);
			return vol;
		}
		
		public static void SetMouseSensitivity(string mouseSensitivityName, float val)
		{
			PlayerPrefs.SetFloat(mouseSensitivityName, val);
		}

		public static float GetMouseSensitivity(string mouseSensitivityName)
		{
			var val = PlayerPrefs.GetFloat(mouseSensitivityName);
			return val;
		}

	}
}
