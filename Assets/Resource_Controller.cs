using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_Controller : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		if (col.CompareTag ("Unit")) 
		{
			
			bool check_flag = col.GetComponent<Unit_Controller> ().GetCollectionFlag ();

			if (check_flag) 
			{
				col.GetComponent<Unit_Controller> ().ChangeUnitState (Unit_State.Collecting);
			}
		}
	}
}
