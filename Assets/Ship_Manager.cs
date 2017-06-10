using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRStandardAssets.Utils;

public class Ship_Manager : MonoBehaviour {

	private GameObject selected_unit;
	private Unit_Movement unit_movement;
	private VRInput input;
	private Reticle reticle;
	[SerializeField] private Image reticle_center;

	// Use this for initialization
	void Awake () {
		input = GetComponentInChildren<VRInput> ();
		reticle = GetComponentInChildren<Reticle> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnEnable()
	{
		input.OnCancel += DeselectUnit;
	}


	private void OnDisable()
	{
		input.OnCancel -= DeselectUnit;
	}

	public void SelectUnit(GameObject unit)
	{
		selected_unit = unit;
		unit_movement = unit.GetComponentInParent<Unit_Movement> ();
		reticle.UseNormal = true;
		reticle_center.enabled = true;
	}

	private void DeselectUnit()
	{
		if (selected_unit != null) 
		{
			selected_unit.GetComponent<GlowObject> ().DActiveAllGlow ();
			selected_unit = null;
			unit_movement = null;
			reticle.UseNormal = false;
			reticle_center.enabled = false;

		}
	}

	public void MoveUnitTo(Transform next_target)
	{
		if (unit_movement != null)
		{
			unit_movement.target = next_target.position;
		}
	}
}
