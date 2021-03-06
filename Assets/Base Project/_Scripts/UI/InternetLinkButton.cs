﻿using UnityEngine;

namespace Base_Project._Scripts.UI
{
	public class InternetLinkButton : MonoBehaviour
	{
		// Open up an external URL, useful for social media
		public void OnClickLink(string url)
		{
			Application.OpenURL(url);
		}
	}
}
