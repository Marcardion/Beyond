using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class CockpitButton : MonoBehaviour {

	[SerializeField] private VRInteractiveItem m_InteractiveItem;
	[SerializeField] private Animator bodyAnimator;
	[SerializeField] private Animator buttomAnimator;
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
		m_InteractiveItem.OnOver += HandleOver;
		m_InteractiveItem.OnOut += HandleOut;

	}


	private void OnDisable()
	{
		m_InteractiveItem.OnClick -= HandleClick;
		m_InteractiveItem.OnOver -= HandleOver;
		m_InteractiveItem.OnOut -= HandleOut;
	}


	//Handle the Click event
	private void HandleClick()
	{
		Debug.Log ("Test");
		bodyAnimator.SetTrigger (animationCall);
	}

	//Handle the Click event
	private void HandleOver()
	{
		buttomAnimator.SetBool ("isOver", true);
		Debug.Log ("Test");

	}

	private void HandleOut()
	{
		buttomAnimator.SetBool ("isOver", false);
	}

}
