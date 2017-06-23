﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Controller : MonoBehaviour {

	private Resource_Manager resourceManager;



	// Use this for initialization
	void Start () {
		resourceManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<Resource_Manager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
			if (col.CompareTag ("Unit"))
			{
				if (col.gameObject.GetComponent<Unit_Controller>().myState == Unit_State.Carrying)
				{
					IncreaseResource (col.gameObject.GetComponent<Resource_Info> ());
					col.gameObject.GetComponent<Unit_Controller> ().SetOffItem (col.gameObject.GetComponent<Resource_Info> ().GetType ());
					col.gameObject.GetComponent<Unit_Controller> ().ChangeUnitState (Unit_State.Idle);
					col.gameObject.GetComponent<Animator> ().SetBool ("Is_Carrying", false);
				}
			}
	}

	void IncreaseResource(Resource_Info info)
	{
		switch (info.GetType ()) 
		{
		case ResourceType.Biomass:
			Debug.Log ("Hello");
			resourceManager.IncreaseBiomass (info.GetAmmount());
			break;
		case ResourceType.Gas:
			resourceManager.IncreaseGas (info.GetAmmount());
			break;
		case ResourceType.Crystal:
			resourceManager.IncreaseCrystal (info.GetAmmount());
			break;
		}
	}
}