using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRStandardAssets.Utils;

public class HUD_Control: MonoBehaviour {

	private Transform cameraRig;
	private Renderer portraitRenderer;
	[SerializeField] private GameObject tooltip;
	[SerializeField] private VRInteractiveItem item;

	// Use this for initialization
	void Start () {

		cameraRig = GameObject.FindGameObjectWithTag ("CameraRig").transform;
		portraitRenderer = GetComponentInChildren<Renderer> ();

		if (portraitRenderer != null) 
		{
			portraitRenderer.enabled = false;
		}

		if (tooltip != null) 
		{
			DisableTooltip ();
		}
	}

	private void OnEnable()
	{
		item.OnOver += TurnOnTooltip;
		item.OnOut += TurnOffTooltip;
	}

	private void OnDisable()
	{
		item.OnOver -= TurnOnTooltip;
		item.OnOut -= TurnOffTooltip;
	}
	
	// Update is called once per frame
	void Update () {

		transform.LookAt (cameraRig.position);
	}

	public void TurnOnPortrait()
	{
		portraitRenderer.enabled = true;
		portraitRenderer.gameObject.GetComponent<Animator> ().SetBool ("Active", true);
	}

	public void TurnOffPortrait()
	{
		portraitRenderer.gameObject.GetComponent<Animator> ().SetBool ("Active", false);
		//portraitRenderer.enabled = false;
	}

	public void TurnOnTooltip()
	{
		tooltip.SetActive (true);
		tooltip.GetComponent<Animator> ().SetBool ("Active", true);
	}

	public void TurnOffTooltip()
	{
		//tooltip.SetActive (false);
		tooltip.GetComponent<Animator> ().SetBool ("Active", false);
	}

	public void DisableTooltip()
	{
		tooltip.SetActive (false);
	}
	//TODO IMPLEMENTAR UM METODO PARA DESLIGAR OS HUD PARA MELHORAR PERFORMANCE
}
