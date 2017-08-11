using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class SceneSelect : MonoBehaviour {

	[SerializeField] private VRInteractiveItem m_InteractiveItem;
	[SerializeField] private LoadScene scene_loader;
	[SerializeField] private string scene_name;

	// Use this for initialization
	void Start () {
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
		scene_loader.StartLoad (scene_name);
		m_InteractiveItem.OnClick -= HandleClick;
	}


}
