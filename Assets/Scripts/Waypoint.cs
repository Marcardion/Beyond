using System;
using System.Collections;
using UnityEngine;
using VRStandardAssets.Utils;

public class Waypoint : MonoBehaviour
{
	enum MovementType {Teleport, LinearMovement};

	[SerializeField] private MovementType m_Type;
    [SerializeField] private Material m_NormalMaterial;                
    [SerializeField] private Material m_OverMaterial;    
    [SerializeField] private VRInteractiveItem m_InteractiveItem;
    [SerializeField] private Renderer m_Renderer;
	[SerializeField] private Transform myCameraPosition;
	private Transform activeCameraPosition;
	private VRCameraFade cameraFade;
	private Reticle_Controller reticle_ctrl;



    private void Awake ()
    {
     	m_Renderer.material = m_NormalMaterial;
    }

	void Start()
	{
		cameraFade = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<VRCameraFade> ();
		activeCameraPosition = GameObject.FindGameObjectWithTag ("CameraRig").transform;
		reticle_ctrl = GameObject.FindGameObjectWithTag ("CameraRig").GetComponent<Reticle_Controller> ();

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
			reticle_ctrl.SetOnReticleType (InteractionTypes.Waypoint);
            m_Renderer.material = m_OverMaterial;
        }


        //Handle the Out event
        private void HandleOut()
        {
			reticle_ctrl.SetOnReticleType (InteractionTypes.None);
            m_Renderer.material = m_NormalMaterial;
        }


        //Handle the Click event
        private void HandleClick()
        {
            Debug.Log("Show click state");
			
			if (m_Type == MovementType.Teleport)
			{
				StartCoroutine (cameraFade.BeginFadeOut (true));
				cameraFade.OnFadeComplete += StartTeleport;
			}
        }
		
        //Handle the DoubleClick event
        private void HandleDoubleClick()
        {
            Debug.Log("Show double click");
        }

		private void StartTeleport()
		{
			activeCameraPosition.position = myCameraPosition.position;
			activeCameraPosition.rotation = myCameraPosition.rotation;
			cameraFade.OnFadeComplete -= StartTeleport;
			StartCoroutine (cameraFade.BeginFadeIn (true));	
		}
}