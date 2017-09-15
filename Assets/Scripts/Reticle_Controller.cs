using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRStandardAssets.Utils;
using VRStandardAssets.Maze;

public class Reticle_Controller : MonoBehaviour {

	InteractionTypes onReticleType = InteractionTypes.None;

	[Header("Reticle Types")]
	[SerializeField] private Sprite groundSelectReticle;
	[SerializeField] private Sprite resourceHarvestReticle;
	[SerializeField] private Sprite waypointReticle;
	[SerializeField] private Sprite unitReticle;
	[SerializeField] private Sprite messageReticle;

	private bool unitSelected = false;


	private Reticle reticle;
	[Header("Reticle")]
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

		switch (onReticleType)
		{
			case InteractionTypes.Resource:
				if (unitSelected)
				{
					SetReticleToResourceHarvest ();
				} else
				{
					ResetReticle();
				}
				break;
			case InteractionTypes.Waypoint:
				SetReticleToWaypoint ();
				break;
			case InteractionTypes.Unit:
				SetReticleToUnitSelect ();
				break;
			case InteractionTypes.Ground:
				if (unitSelected)
				{
					SetReticleToGroundSelect ();
				} else
				{
					ResetReticle ();
				}
				break;
			default:
				ResetReticle ();
				break;
		}

	}

	public void SetReticleToGroundSelect()
	{
		reticle.UseNormal = true;
		reticle_center.enabled = true;
		reticle_center.sprite = groundSelectReticle;
		reticle_center.color = new Color (104 / 255f, 233 / 255f, 30 / 255f);
	}

	public void SetReticleToWaypoint()
	{
		reticle.UseNormal = false;
		reticle_center.enabled = true;
		reticle_center.sprite = waypointReticle;
		reticle_center.color = new Color (168 / 255f, 251 / 255f, 241 / 255f);
	}

	public void SetReticleToResourceHarvest()
	{
		reticle.UseNormal = false;
		reticle_center.enabled = true;
		reticle_center.sprite = resourceHarvestReticle;
		reticle_center.color = new Color (250 / 255f, 251 / 255f, 168 / 255f);
	}

	public void SetReticleToUnitSelect()
	{
		reticle.UseNormal = false;
		reticle_center.enabled = true;
		reticle_center.sprite = unitReticle;
		reticle_center.color = new Color (168 / 255f, 251 / 255f, 203 / 255f);
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

	public void SetOnReticleType (InteractionTypes type)
	{
			
			onReticleType = type;
			HandleReticle ();
	}
}
