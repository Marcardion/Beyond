using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class Popup_Controller : MonoBehaviour {

	[Header("Popup Objects")]
	[SerializeField] private GameObject popUp;
	[SerializeField] private VRInteractiveItem popUp_interactive;
	private Reticle_Controller reticle_ctrl;

	[Header("Audio Clips")]
	[SerializeField] private AudioClip nextMessageClip;
	[SerializeField] private AudioClip endMessageClip;

	// Use this for initialization
	void Start () {

		reticle_ctrl = GameObject.FindGameObjectWithTag ("CameraRig").GetComponent<Reticle_Controller> ();
		popUp.SetActive (false);	
	}

	private void OnEnable()
	{
		popUp_interactive.OnOver += HandleOver;
		popUp_interactive.OnOut += HandleOut;
		popUp_interactive.OnClick += HandleClick;

	}


	private void OnDisable()
	{
		popUp_interactive.OnOver -= HandleOver;
		popUp_interactive.OnClick -= HandleClick;
		popUp_interactive.OnOut -= HandleOut;
	}
		
	void HandleOver()
	{
		reticle_ctrl.SetOnReticleType (InteractionTypes.Message);
	}

	void HandleOut()
	{
		reticle_ctrl.SetOnReticleType (InteractionTypes.None);
	}

	void HandleClick()
	{
		StartCoroutine (TurnOnorOff (false, 0.25f));
		GetComponent<Animator> ().SetBool ("Active", false);
		SoundManager.instance.PlaySingle (endMessageClip, 0);
	}

	public void Activate()
	{
		popUp.SetActive (true);

		StartCoroutine (DelayStart ());
	}

	IEnumerator TurnOnorOff(bool mode, float time)
	{
		yield return new WaitForSeconds (time);

		popUp.SetActive (mode);
	}

	IEnumerator DelayStart()
	{
		yield return new WaitForSeconds (0.25f);
		SoundManager.instance.PlaySingle (nextMessageClip, 0);
		GetComponent<Animator> ().SetBool ("Active", true);
	}

}
