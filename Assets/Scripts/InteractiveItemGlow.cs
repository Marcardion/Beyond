using UnityEngine;
using VRStandardAssets.Utils;

namespace VRStandardAssets.Examples
{
    // This script is a simple example of how an interactive item can
    // be used to change things on gameobjects by handling events.
    public class InteractiveItemGlow : MonoBehaviour
    {
        [SerializeField] private Material m_NormalMaterial;                
        [SerializeField] private Material m_OverMaterial;                  
        [SerializeField] private Material m_ClickedMaterial;               
        [SerializeField] private Material m_DoubleClickedMaterial;         
        [SerializeField] private VRInteractiveItemGlow m_InteractiveItem;
        [SerializeField] private Renderer m_Renderer;
		[SerializeField] private GlowObject gObject;


		public Color GlowColor;
		private Color _targetColor;


        private void Awake ()
        {
            m_Renderer.material = m_NormalMaterial;
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
			
			gObject.ActiveGlow ();

            Debug.Log("Show over state");
          //  m_Renderer.material = m_OverMaterial;
        }


        //Handle the Out event
        private void HandleOut()
        {

			gObject.ActiveGlow ();

            Debug.Log("Show out state");
          //  m_Renderer.material = m_NormalMaterial;
        }


        //Handle the Click event
        private void HandleClick()
        {
			gObject.ActiveClickGlow ();
            Debug.Log("Show click state");
           // m_Renderer.material = m_ClickedMaterial;
        }


        //Handle the DoubleClick event
        private void HandleDoubleClick()
        {
			gObject.ActiveGlow ();
            Debug.Log("Show double click");
          //  m_Renderer.material = m_DoubleClickedMaterial;
        }
    }

}