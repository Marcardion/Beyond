using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRStandardAssets.Utils;

public class LoadScene : MonoBehaviour {

	private string scene_name;
	private bool loadingScene = false;
	private VRCameraFade cameraFade;

	// Use this for initialization
	void Start () 
	{
		cameraFade = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<VRCameraFade> ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartLoad(string nextSceneName){

		scene_name = nextSceneName;
		StartCoroutine (cameraFade.BeginFadeOut (true));	
		cameraFade.OnFadeComplete += LoadNextScene;

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
