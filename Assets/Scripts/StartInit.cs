using System;
using System.Collections;
using UnityEngine;
using VRStandardAssets.Utils;
using UnityEngine.SceneManagement;

public class StartInit : MonoBehaviour {

	[SerializeField] private VRInteractiveItem m_InteractiveItem;
	[SerializeField] private string scene_name;
	private VRCameraFade cameraFade;
	private bool loadingScene = false;
	bool end_flag = false;
	[SerializeField]  private Animator my_animator;



	void Start()
	{
		cameraFade = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<VRCameraFade> ();
		cameraFade = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<VRCameraFade> ();

	}



	private void OnEnable()
	{
		
		m_InteractiveItem.OnClick += HandleClick;

	}


	private void OnDisable()
	{
		m_InteractiveItem.OnClick -= HandleClick;
	}


	//Handle the Click event
	private void HandleClick()
	{
		Debug.Log("Show click state");

		//my_animator.SetTrigger ("gameStart");
		my_animator.Play("endShip");

		//my_animator.GetNextAnimatorClipInfo [0].length;
	


		//StartCoroutine (cameraFade.BeginFadeIn (true));	

		//cameraFade.OnFadeComplete += LoadNextScene;
	}



	// Update is called once per frame
	void Update () {


	}


	public void InitLoadNextScene(float theValue){

		StartCoroutine (cameraFade.BeginFadeIn (true));	
		LoadNextScene ();
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





