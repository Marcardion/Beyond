using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Unit_State{Idle, Moving, Collecting, Carrying};

public class Unit_Controller : MonoBehaviour {

	public Unit_State myState;

	private bool collection_flag;

	[SerializeField] private GameObject biomassItem;
	[SerializeField] private GameObject gasItem;
	[SerializeField] private GameObject crystalItem;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetCollectionFlag(bool mode)
	{
		collection_flag = mode;
	}

	public bool GetCollectionFlag()
	{
		return collection_flag;
	}

	public void ChangeUnitState(Unit_State state)
	{
		myState = state;
	}

	public void SetOnItem(ResourceType type)
	{
		switch (type) 
		{
		case ResourceType.Biomass:
			biomassItem.SetActive (true);
			break;

		case ResourceType.Gas:
			gasItem.SetActive (true);
			break;

		case ResourceType.Crystal:
			crystalItem.SetActive (true);
			break;
		}
	}

	public void SetOffItem(ResourceType type)
	{
		switch (type) 
		{
		case ResourceType.Biomass:
			biomassItem.SetActive (false);
			break;

		case ResourceType.Gas:
			gasItem.SetActive (false);
			break;

		case ResourceType.Crystal:
			crystalItem.SetActive (false);
			break;
		}
	}
}
