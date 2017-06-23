using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit_Movement : MonoBehaviour {

	private NavMeshAgent my_agent;
	private Animator my_animator;
	private Unit_Controller my_controller;

	// Use this for initialization
	void Start () {

		my_agent = GetComponent<NavMeshAgent> ();
		my_animator = GetComponentInChildren<Animator> ();
		my_controller = GetComponentInChildren<Unit_Controller> ();
	}
	
	// Update is called once per frame
	void Update () {

	
			// Colocar Animacão aqui
			if (my_agent.remainingDistance > 0.1 && my_agent.isStopped == false)
			{
				my_animator.SetBool ("Is_Walking", true);
			if (my_controller.myState == Unit_State.Idle) {
				my_controller.ChangeUnitState (Unit_State.Moving);
				}
			} else
			{
				my_animator.SetBool ("Is_Walking", false);
				if (my_controller.myState == Unit_State.Moving)
				{
					my_controller.ChangeUnitState (Unit_State.Idle);
				}
			}
	}

	public void SetTarget(Vector3 next_target)
	{
		my_agent.SetDestination (next_target);
	}

	public void SetStop(bool mode)
	{
		my_agent.isStopped = mode;
	}
}
