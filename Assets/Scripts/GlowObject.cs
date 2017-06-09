using UnityEngine;
using System.Collections.Generic;
using VRStandardAssets.Utils;

public class GlowObject : MonoBehaviour
{
	public Color GlowColor;
	public Color GlowClickColor;
	public float LerpFactor = 10;

	public Renderer[] Renderers
	{
		get;
		private set;
	}

	public Color CurrentColor
	{
		get { return _currentColor; }
	}

	private List<Material> _materials = new List<Material>();
	private Color _currentColor;
	private Color _targetColor;

	void Start()
	{
		Renderers = GetComponentsInChildren<Renderer>();

		foreach (var renderer in Renderers)
		{	
			_materials.AddRange(renderer.materials);
		}
	}

	private void OnMouseDown()
	{
		/*

		Debug.Log("On Mouse Down");

		if (_targetColor != GlowColor) {
			_targetColor = GlowColor;

		} else if(_targetColor != Color.black){
			_targetColor = Color.black;
		}
		enabled = true;
*/

	}



	private void HandleClick()
	{
		/*
		 if (_targetColor != GlowColor) {
			_targetColor = GlowColor;

		} else if(_targetColor != Color.black){
			_targetColor = Color.black;
		}
		enabled = true;
*/
	}



	public void ActiveGlow()
	{

		Debug.Log("Active Glow");

		if (_targetColor != GlowClickColor) {

			if (_targetColor != GlowColor) {
				_targetColor = GlowColor;

			} else if (_targetColor != Color.black) {
				_targetColor = Color.black;
			}
		}
		enabled = true;
	}


	public void ActiveClickGlow()
	{

		Debug.Log("Active Click Glow");

		if (_targetColor != GlowClickColor) {
			_targetColor = GlowClickColor;

		} else {
			_targetColor = GlowColor;
		}

		enabled = true;
	}



	public void DActiveOutGlow()
	{

		Debug.Log("Desactive All Glow");

		if (_targetColor != GlowClickColor) {
			_targetColor = Color.black;
		} 
			

		enabled = true;
	}


	public void DActiveAllGlow()
	{

		Debug.Log("Desactive All Glow");

		_targetColor = Color.black;

		enabled = true;
	}



	/*
	 private void OnMouseExit()
	{
		_targetColor = Color.black;
		enabled = true;
	}
	*/

	/// <summary>
	/// Loop over all cached materials and update their color, disable self if we reach our target color.
	/// </summary>
	private void Update()
	{
		_currentColor = Color.Lerp(_currentColor, _targetColor, Time.deltaTime * LerpFactor);

		for (int i = 0; i < _materials.Count; i++)
		{
			_materials[i].SetColor("_GlowColor", _currentColor);
		}

		if (_currentColor.Equals(_targetColor))
		{
			enabled = false;
		}
	}
}
