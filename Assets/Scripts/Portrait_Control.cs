using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portrait_Control: MonoBehaviour {

	private Transform cameraRig;
	private Renderer portraitRenderer;

	// Use this for initialization
	void Start () {

		cameraRig = GameObject.FindGameObjectWithTag ("CameraRig").transform;
		portraitRenderer = GetComponentInChildren<Renderer> ();

		portraitRenderer.enabled = false;
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.LookAt (cameraRig.position);
	}

	public void TurnOnPortrait()
	{
		portraitRenderer.enabled = true;
	}

	public void TurnOffPortrait()
	{
		portraitRenderer.enabled = false;
	}
}
