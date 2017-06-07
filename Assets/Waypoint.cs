using System;
using UnityEngine;
using VRStandardAssets.Utils;

public class Waypoint : MonoBehaviour
{
    [SerializeField] private Material m_NormalMaterial;                
    [SerializeField] private Material m_OverMaterial;    
    [SerializeField] private VRInteractiveItem m_InteractiveItem;
    [SerializeField] private Renderer m_Renderer;
	[SerializeField] private Transform myCameraPosition;
	private Transform activeCameraPosition;
	private VRCameraFade cameraFade;



        private void Awake ()
        {
            m_Renderer.material = m_NormalMaterial;
        }

		void Start()
		{
			cameraFade = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<VRCameraFade> ();
			activeCameraPosition = GameObject.FindGameObjectWithTag ("CameraRig").transform;
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
            Debug.Log("Show over state");
            m_Renderer.material = m_OverMaterial;
        }


        //Handle the Out event
        private void HandleOut()
        {
            Debug.Log("Show out state");
            m_Renderer.material = m_NormalMaterial;
        }


        //Handle the Click event
        private void HandleClick()
        {
            Debug.Log("Show click state");
			
			StartCoroutine (cameraFade.BeginFadeOut (true));
			cameraFade.OnFadeComplete += StartTeleport;
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