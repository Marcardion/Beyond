using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit_Movement : MonoBehaviour {

	private NavMeshAgent my_agent;
	private Animator my_animator;

	public Vector3 target;

	// Use this for initialization
	void Start () {

		my_agent = GetComponent<NavMeshAgent> ();
		my_animator = GetComponentInChildren<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		my_agent.SetDestination (target);

		// Colocar Animacão aqui
		if (my_agent.velocity != Vector3.zero) {
			my_animator.SetBool ("Is_Walking", true);
		} else 
		{
			my_animator.SetBool ("Is_Walking", false);
		}
	}

	public void SetTarget(Vector3 next_target)
	{
		next_target = target;
	}
}
