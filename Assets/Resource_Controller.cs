using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Resource_Controller : MonoBehaviour {

	private bool active = true;
	private bool beingCollected = false;
	private bool collection_ended = false;

	private Renderer[] models;

	private GameObject unitCollecting;

	private Resource_Info myInfo;

	// Use this for initialization
	void Start () {
		models = GetComponentsInChildren<MeshRenderer> ();
		myInfo = GetComponent<Resource_Info> ();
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
					unitCollecting = col.gameObject;
					SetupCollecting ();
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
				if (col.gameObject == unitCollecting)
				{
					bool check_flag = col.GetComponent<Unit_Controller> ().GetCollectionFlag ();

					if (check_flag)
					{
						unitCollecting.GetComponent<Unit_Controller> ().SetCollectionFlag (false);
						beingCollected = false;
						unitCollecting = null;
					}
				}
			}
		}
	}

	IEnumerator StartCollecting()
	{
		Debug.Log ("Start");
		float timer = 0;

		while (beingCollected == true && collection_ended == false)
		{
			Debug.Log ("Enter");
			timer += Time.deltaTime;

			if (timer >= 5f)
			{
				Debug.Log ("Hello");
				EndCollecting ();
			}

			yield return new WaitForFixedUpdate ();
		}

		Debug.Log ("End");

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

		Destroy (this.gameObject);
	}

	void CopyResource()
	{
		unitCollecting.AddComponent<Resource_Info> ();
		unitCollecting.GetComponent<Resource_Info> ().SetAmmount (myInfo.GetAmmount());
		unitCollecting.GetComponent<Resource_Info> ().SetType (myInfo.GetType());
		unitCollecting.GetComponentInParent<NavMeshAgent> ().isStopped = false;
	}

	void SetupCollecting()
	{
		StartUnit ();

		beingCollected = true;
		StartCoroutine (StartCollecting ());
	}

	void EndCollecting()
	{
		ResetUnit ();

		CopyResource ();
		collection_ended = true;
		active = false;
		unitCollecting = null;
		StartCoroutine (FadeAndDestroy ());
	}

	void ResetUnit()
	{
		unitCollecting.GetComponent<Unit_Controller> ().ChangeUnitState (Unit_State.Idle);
		unitCollecting.GetComponentInParent<NavMeshAgent> ().isStopped = false;
		unitCollecting.transform.localRotation = Quaternion.Euler (0, 0, 0);
		unitCollecting.GetComponentInParent<Animator> ().SetBool ("Is_Collecting", false);
	}

	void StartUnit()
	{
		unitCollecting.GetComponent<Unit_Controller> ().ChangeUnitState (Unit_State.Collecting);
		unitCollecting.GetComponentInParent<NavMeshAgent> ().isStopped = true;
		unitCollecting.transform.LookAt (this.transform);
		unitCollecting.GetComponentInParent<Animator> ().SetBool ("Is_Collecting", true);

	}
}
