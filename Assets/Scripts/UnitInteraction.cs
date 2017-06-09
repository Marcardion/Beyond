using System;
using System.Collections;
using UnityEngine;
using VRStandardAssets.Utils;

public class UnitInteraction : MonoBehaviour
{   
    private VRInteractiveItem m_InteractiveItem;
	private Ship_Manager player_ship;

    private void Awake ()
    {
		m_InteractiveItem = GetComponent<VRInteractiveItem> ();
    }

	void Start () 
	{
		player_ship = GameObject.FindGameObjectWithTag ("CameraRig").GetComponent<Ship_Manager> ();

	}


    private void OnEnable()
    {
    	m_InteractiveItem.OnOver += HandleOver;
    	m_InteractiveItem.OnOut += HandleOut;
    	m_InteractiveItem.OnClick += HandleClick;
    	m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
   	}


    private void OnDisable()
    {
    	m_InteractiveItem.OnOver -= HandleOver;
        m_InteractiveItem.OnOut -= HandleOut;
        m_InteractiveItem.OnClick -= HandleClick;
        m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
    }


        //Handle the Over event
        private void HandleOver()
        {
		Debug.Log ("Over");
        }


        //Handle the Out event
        private void HandleOut()
        {
            
        }


        //Handle the Click event
        private void HandleClick()
        {
			Debug.Log ("Hello");
			player_ship.SelectUnit (this.gameObject);
        }
		
        //Handle the DoubleClick event
        private void HandleDoubleClick()
        {
           
        }
		
}