using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;
using TMPro;

public class Message_Controller : MonoBehaviour {

	private Transform cameraRig;
	[SerializeField] private GameObject message;
	public VRInteractiveItem message_interactive;
	[SerializeField] private TextMeshProUGUI message_text;


	// Use this for initialization
	void Start () {

		cameraRig = GameObject.FindGameObjectWithTag ("CameraRig").transform;
		message.SetActive (false);
	}



	// Update is called once per frame
	void Update () 
	{
		transform.LookAt (cameraRig.position);
	}

	public void ActivateMessage()
	{
		message.SetActive (true);
		message.GetComponent<Animator> ().SetBool ("Active", true);
	}

	public void DeactivateMessage()

	{
		StartCoroutine (TurnOnorOff (false, 0.25f));
		message.GetComponent<Animator> ().SetBool ("Active", false);
	}

	public void ChangeText(TextMeshProUGUI nextText)
	{
		message_text.text = nextText.text;
	}

	IEnumerator TurnOnorOff(bool mode, float time)
	{
		yield return new WaitForSeconds (time);

		message.SetActive (mode);
	}
}
