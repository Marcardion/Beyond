using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resource_Controller : MonoBehaviour {

	[SerializeField] private ResourceType m_ResourceType;
	private Resource_Manager resourceManager;
	private TextMeshProUGUI textMesh;

	// Use this for initialization
	void Awake () {

		resourceManager = GameObject.FindGameObjectWithTag ("GameManager").GetComponent<Resource_Manager> ();

		textMesh = GetComponent<TextMeshProUGUI> ();
	}

	//TODO Implementar o sistema de Event para reduzir custo de processamento.

	private void OnEnable()
	{
		resourceManager.OnUpdate += UpdateText;
	}

	private void OnDisable()
	{
		resourceManager.OnUpdate -= UpdateText;
	}
	
	// Update is called once per frame
	void Update () 
	{
		UpdateText();
	}

	public void UpdateText()
	{
		int temp = 0;

		switch (m_ResourceType) 
		{
		case ResourceType.Biomass:
			temp = resourceManager.GetCurrentBiomass ();
			break;
		case ResourceType.Gas:
			temp = resourceManager.GetCurrentGas ();
			break;
		case ResourceType.Crystal:
			temp = resourceManager.GetCurrentCrystal ();
			break;
		}

		textMesh.text = temp.ToString ();
	}
}
