using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRStandardAssets.Utils;
using VRStandardAssets.Maze;

public class Reticle_Controller : MonoBehaviour {

	InteractionTypes onReticleType;

	public bool unitSelected = false;

	private Reticle reticle;
	[SerializeField] private Image reticle_center;
	private Ship_Manager shipManager;


	private void OnEnable()
	{
		shipManager.OnSelect += SetSelected;
		shipManager.OnDeselect += SetDeselected;
	}


	private void OnDisable()
	{
		shipManager.OnSelect -= SetSelected;
		shipManager.OnDeselect -= SetDeselected;
	}


	// Use this for initialization
	void Awake () {

		shipManager = GetComponent<Ship_Manager> ();
		reticle = GetComponentInChildren<Reticle> ();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	void HandleReticle()
	{
		if (unitSelected)
		{
			SetReticleToGroundSelect ();
		} else
		{
			ResetReticle ();
		}
	}

	public void SetReticleToGroundSelect()
	{
		reticle.UseNormal = true;
		reticle_center.enabled = true;
	}

	public void ResetReticle()
	{
		reticle.UseNormal = false;
		reticle_center.enabled = false;
	}


	public void SetSelected()
	{
		unitSelected = true;
		HandleReticle ();
	}

	public void SetDeselected()
	{
		unitSelected = false;
		HandleReticle ();
	}
}
