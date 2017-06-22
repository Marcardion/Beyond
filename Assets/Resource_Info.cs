using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_Info : MonoBehaviour {

	[SerializeField] private ResourceType myType;
	[SerializeField] private int resourceAmmount;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int GetAmmount()
	{
		return resourceAmmount;
	}

	public ResourceType GetType ()
	{
		return myType;
	}

	public void SetAmmount(int ammount)
	{
		resourceAmmount = ammount;
	}

	public void SetType (ResourceType type)
	{
		myType = type;
	}
}
