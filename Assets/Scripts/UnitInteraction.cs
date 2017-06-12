using System;
using System.Collections;
using UnityEngine;
using VRStandardAssets.Utils;

public class UnitInteraction : MonoBehaviour
{   
	[SerializeField]  GameObject selected;
	[SerializeField] private Material m_NormalMaterial;                
	[SerializeField] private Material m_OverMaterial;  
	[SerializeField] private Material m_ClickMaterial; 
	[SerializeField] private Renderer m_Renderer;

    private VRInteractiveItem m_InteractiveItem;
	private Ship_Manager player_ship;

    private void Awake ()
    {
		m_InteractiveItem = GetComponent<VRInteractiveItem> ();
		m_Renderer.material = m_NormalMaterial;

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
			if (m_Renderer.material != m_ClickMaterial) {	
				m_Renderer.material = m_OverMaterial;
			}
        }


        //Handle the Out event
        private void HandleOut()
        {
		if (m_Renderer.material == m_OverMaterial) {
				m_Renderer.material = m_NormalMaterial;
			}
			
        }


        //Handle the Click event
        private void HandleClick()
        {
			m_Renderer.material = m_ClickMaterial;

			player_ship.SelectUnit (this.gameObject);
        }
		
        //Handle the DoubleClick event
        private void HandleDoubleClick()
        {
           
        }
		
}