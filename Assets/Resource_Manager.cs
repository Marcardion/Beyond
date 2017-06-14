using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType {Gas, Biomass, Crystal};

public class Resource_Manager : MonoBehaviour 
{

	[SerializeField] private int gasCounter;
	[SerializeField] private int biomassCounter;
	[SerializeField] private int crystalCounter;

	private int resourceLimit = 999;

	public event Action OnUpdate;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	public int GetCurrentGas()
	{
		return gasCounter;
	}

	public int GetCurrentBiomass()
	{
		return biomassCounter;
	}

	public int GetCurrentCrystal()
	{
		return crystalCounter;
	}

	public void IncreaseGas(int numGas)
	{
		gasCounter += numGas;
		if (gasCounter > resourceLimit) 
		{
			gasCounter = resourceLimit;
		}
		CallUpdate ();
	}

	public void DecreaseGas(int numGas)
	{
		gasCounter -= numGas;
		CallUpdate ();
	}
		
	public void IncreaseBiomass(int numBiomass)
	{
		biomassCounter += biomassCounter;
		if (biomassCounter > resourceLimit) 
		{
			biomassCounter = resourceLimit;
		}
		CallUpdate ();
	}

	public void DecreaseBiomass(int numBiomass)
	{
		biomassCounter -= biomassCounter;
		CallUpdate ();
	}

	public void IncreaseCrystal(int numCrystal)
	{
		crystalCounter += numCrystal;
		if (crystalCounter > resourceLimit) 
		{
			crystalCounter = resourceLimit;
		}
		CallUpdate ();
	}
		
	public void DecreaseCrystal(int numCrystal)
	{
		crystalCounter -= numCrystal;
		CallUpdate ();
	}

	public void CallUpdate()
	{
		if (OnUpdate != null) 
		{
			OnUpdate ();
		}
	}
}
