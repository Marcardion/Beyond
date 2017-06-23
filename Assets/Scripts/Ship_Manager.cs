﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using VRStandardAssets.Utils;
using VRStandardAssets.Maze;

public class Ship_Manager : MonoBehaviour {

	private GameObject selected_unit;
	private Unit_Movement unit_movement;
	private VRInput input;
	[SerializeField] private Image reticle_center;

	public Action OnSelect;
	public Action OnDeselect;

	// Use this for initialization
	void Awake () {
		input = GetComponentInChildren<VRInput> ();
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

		unit_movement.GetComponentInChildren<HUD_Control> ().TurnOnPortrait ();

		if (OnSelect != null)
		{
			OnSelect ();
		}
	}

	private void DeselectUnit()
	{
		if (selected_unit != null) 
		{
			selected_unit.GetComponent<UnitInteraction> ().ClearSelected ();
			unit_movement.GetComponentInChildren<HUD_Control> ().TurnOffPortrait ();
			selected_unit = null;
			unit_movement = null;

			if (OnDeselect != null)
			{
				OnDeselect ();
			}
		}
	}

	public void MoveUnitTo(Transform next_target)
	{
		if (unit_movement != null)
		{
			unit_movement.SetTarget (next_target.position);
			selected_unit.GetComponentInChildren<AgentTrail> ().SetDestination ();
			selected_unit.GetComponentInParent<Unit_Controller> ().SetCollectionFlag (false);
			if (selected_unit.GetComponentInParent<Unit_Controller> ().myState == Unit_State.Collecting) {
				selected_unit.GetComponentInParent<Unit_Controller> ().ChangeUnitState (Unit_State.Moving);
			}
			unit_movement.SetStop (false);
		}
	}

	public void StartExtraction(Transform location)
	{
		if (selected_unit != null) 
		{
			MoveUnitTo (location);
			selected_unit.GetComponentInParent<Unit_Controller> ().SetCollectionFlag (true);
		}
	}
}
