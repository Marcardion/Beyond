using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallEventonStart : MonoBehaviour {

	//TODO Fazer uma interface para os eventos para reutilizar esse codigo para outros tipos de coisa
	[SerializeField] private Message_Group eventToCall;

	// Use this for initialization
	void Start () {

		StartCoroutine (StartDelay ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator StartDelay()
	{
		yield return new WaitForSeconds (2f);
		eventToCall.StartMessage ();
	}
}
