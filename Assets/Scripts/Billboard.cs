using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class Billboard: MonoBehaviour {

	private Transform cameraRig;


	// Use this for initialization
	void Start () {

		cameraRig = GameObject.FindGameObjectWithTag ("CameraRig").transform;

	}

	// Update is called once per frame
	void Update () {

		transform.LookAt (cameraRig.position);
	}


}
