using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource_Controller : MonoBehaviour {

	[SerializeField] GameObject parent;

	private bool active = true;
	private bool beingCollected = false;
	private bool collection_ended = false;

	public Renderer[] models;

	// Use this for initialization
	void Start () {
		models = GetComponentsInChildren<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider col)
	{
		if (active)
		{
			if (col.CompareTag ("Unit"))
			{
			
				bool check_flag = col.GetComponent<Unit_Controller> ().GetCollectionFlag ();

				if (check_flag == true && beingCollected == false)
				{
					col.GetComponent<Unit_Controller> ().ChangeUnitState (Unit_State.Collecting);
					beingCollected = true;
					StartCoroutine (StartCollecting ());
				}
			}
		}
	}

	void OnTriggerExit(Collider col)
	{
		if (active)
		{
			if (col.CompareTag ("Unit"))
			{

				bool check_flag = col.GetComponent<Unit_Controller> ().GetCollectionFlag ();

				if (check_flag)
				{
					col.GetComponent<Unit_Controller> ().SetCollectionFlag (false);
					beingCollected = false;
				}
			}
		}
	}

	IEnumerator StartCollecting()
	{
		float timer = 0;

		while (beingCollected == true && collection_ended == false)
		{
			timer += Time.deltaTime;
			if (timer >= 5)
			{
				collection_ended = true;
				active = false;
			}

			yield return new WaitForEndOfFrame();
		}

		StartCoroutine (FadeAndDestroy ());
	}

	IEnumerator FadeAndDestroy()
	{


		float fade = 1;

		Renderer[] models = GetComponentsInChildren<Renderer> ();

		while (fade > 0)
		{

			fade -= Time.deltaTime*0.5f;

			if (fade < 0)
			{
				fade = 0;
			}

			foreach (Renderer model in models)
			{
				foreach (Material material in model.materials)
				{
					material.color = new Color (material.color.r, material.color.g, material.color.b, fade);
				}

			}

			yield return new WaitForEndOfFrame ();
		}

		yield return new WaitForSeconds (1f);

		Destroy (parent.gameObject);
	}
}
