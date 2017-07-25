﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;
using UnityEngine.SceneManagement;


public class SplashManager : MonoBehaviour {


	[SerializeField] private string scene_name;

	private Resource_Manager resourceManager;
	private VRCameraFade cameraFade;

	private bool loadingScene = false;
	bool end_flag = false;

	// Use this for initialization
	void Start () {

		resourceManager = GetComponent<Resource_Manager> ();
		cameraFade = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<VRCameraFade> ();

	}

	// Update is called once per frame
	void Update () {
		

		if (end_flag) 
		{
			// Colocar codigo de fim de jogo
			StartCoroutine (cameraFade.BeginFadeOut (true));
			//LoadNextScene ();
			cameraFade.OnFadeComplete += LoadNextScene;
		}
	}
		

	void LoadNextScene()
	{
		if (loadingScene == false) 
		{
			loadingScene = true;
			SceneManager.LoadSceneAsync (scene_name);
		}
	}
}
