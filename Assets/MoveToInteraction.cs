using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class MoveToInteraction : MonoBehaviour {

	[SerializeField] private VRInteractiveItem m_InteractiveItem;
	[SerializeField] private Reticle reticle;
	[SerializeField] private Unit_Movement unit;

	// Use this for initialization
	void Start () {
		
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
		
	}


	//Handle the Out event
	private void HandleOut()
	{
		//raycaster.OnRaycasthit -= SetTarget;
	}


	//Handle the Click event
	private void HandleClick()
	{
		SetTarget (reticle.ReticleTransform);
	}

	private void SetTarget(Transform next_target)
	{
		unit.target = next_target.position;
	}


	//Handle the DoubleClick event
	private void HandleDoubleClick()
	{
		
	}
}
