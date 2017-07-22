using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class BlockedGround_Interaction : MonoBehaviour {


	[SerializeField] private VRInteractiveItem m_InteractiveItem;
	private Reticle_Controller reticle_ctrl;

	// Use this for initialization
	void Start () {
		reticle_ctrl = GameObject.FindGameObjectWithTag ("CameraRig").GetComponent<Reticle_Controller> ();
	}

	// Update is called once per frame
	void Update () {

	}

	private void OnEnable()
	{
		m_InteractiveItem.OnOver += HandleOver;
		m_InteractiveItem.OnOut += HandleOut;
		m_InteractiveItem.OnClick += HandleClick;
		m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
	}


	private void OnDisable()
	{
		m_InteractiveItem.OnOver -= HandleOver;
		m_InteractiveItem.OnOut -= HandleOut;
		m_InteractiveItem.OnClick -= HandleClick;
		m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
	}


	//Handle the Over event
	private void HandleOver()
	{
		reticle_ctrl.SetOnReticleType (InteractionTypes.None);
	}


	//Handle the Out event
	private void HandleOut()
	{
	}


	//Handle the Click event
	private void HandleClick()
	{

	}


	//Handle the DoubleClick event
	private void HandleDoubleClick()
	{

	}
}
