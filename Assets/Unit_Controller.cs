using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Unit_State{Idle, Moving, Collecting};

public class Unit_Controller : MonoBehaviour {

	public Unit_State myState;

	private bool collection_flag;

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
}
