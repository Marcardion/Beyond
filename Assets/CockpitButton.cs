using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class CockpitButton : MonoBehaviour {

	[SerializeField] private VRInteractiveItem m_InteractiveItem;
	[SerializeField] private Animator bodyAnimator;
	[SerializeField] private string animationCall;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
		Debug.Log ("Test");
		bodyAnimator.SetTrigger (animationCall);
	}
}
