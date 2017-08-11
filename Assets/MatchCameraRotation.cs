using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchCameraRotation : MonoBehaviour {

	private Transform cameraTransform;

	// Use this for initialization
	void Start () {

		cameraTransform = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {

		transform.rotation = Quaternion.Euler (new Vector3 (0f, cameraTransform.eulerAngles.y , 0f));
	}
}
