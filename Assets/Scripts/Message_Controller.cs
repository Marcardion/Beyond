using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;
using TMPro;

public class Message_Controller : MonoBehaviour {

	[Header("Message Objects")]
	[SerializeField] private GameObject message;
	public VRInteractiveItem message_interactive;
	[SerializeField] private TextMeshProUGUI message_text;

	private Reticle_Controller reticle_ctrl;
	private Transform cameraRig;

	[Header("Audio Clips")]
	[SerializeField] private AudioClip nextMessageClip;
	[SerializeField] private AudioClip endMessageClip;

	// Use this for initialization
	void Start () {

		cameraRig = GameObject.FindGameObjectWithTag ("CameraRig").transform;
		reticle_ctrl = GameObject.FindGameObjectWithTag ("CameraRig").GetComponent<Reticle_Controller> ();
		message.SetActive (false);
	}


	private void OnEnable()
	{
		message_interactive.OnOver += HandleOver;

	}


	private void OnDisable()
	{
		message_interactive.OnOver -= HandleOver;
	}


	// Update is called once per frame
	void Update () 
	{
		transform.LookAt (cameraRig.position);
	}

	void HandleOver()
	{
		reticle_ctrl.SetOnReticleType (InteractionTypes.Message);
	}


	public void ActivateMessage()
	{
		message.SetActive (true);
		message.GetComponent<Animator> ().SetBool ("Active", true);
	}

	public void DeactivateMessage()

	{
		SoundManager.instance.PlaySingle (endMessageClip, 0);
		StartCoroutine (TurnOnorOff (false, 0.25f));
		message.GetComponent<Animator> ().SetBool ("Active", false);
	}

	public void ChangeText(TextMeshProUGUI nextText)
	{
		SoundManager.instance.PlaySingle (nextMessageClip, 0);
		message_text.text = nextText.text;
	}

	IEnumerator TurnOnorOff(bool mode, float time)
	{
		yield return new WaitForSeconds (time);

		message.SetActive (mode);
	}
}
