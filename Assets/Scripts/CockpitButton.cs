using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class CockpitButton : MonoBehaviour {

	[SerializeField] private VRInteractiveItem m_InteractiveItem;
	[SerializeField] private Animator bodyAnimator;
	[SerializeField] private Animator buttomAnimator;
	[SerializeField] private string animationCall;

	private Popup_Controller popupControl;

	// Use this for initialization
	void Start () {

		popupControl = GetComponentInChildren<Popup_Controller> ();
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
		bodyAnimator.SetTrigger ("Press");
		if (popupControl != null) {
			popupControl.Activate ();
		}
	}

	//Handle the Click event
	private void HandleOver()
	{
		buttomAnimator.SetBool ("isOver", true);
		bodyAnimator.SetBool (animationCall, true);

	}

	private void HandleOut()
	{
		buttomAnimator.SetBool ("isOver", false);
		bodyAnimator.SetBool (animationCall, false);
	}

}
