using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Message_Group : MonoBehaviour {

	[SerializeField] private Message_Controller messageControl;
	[SerializeField] private TextMeshProUGUI[] messages;

	private int activeIndex = 0;

	// Use this for initialization
	void Start () {
		
	}

	private void OnEnable()
	{
		messageControl.message_interactive.OnDown += NextMessage;
	}

	private void OnDisable()
	{
		messageControl.message_interactive.OnDown -= NextMessage;
	}

	// Update is called once per frame
	void Update () {
		
	}

	void NextMessage()
	{
		if ((activeIndex+1) >= messages.Length) {
			messageControl.DeactivateMessage ();
		} else 
		{
			activeIndex++;
			messageControl.ChangeText (messages [activeIndex]);
		}
	}

	public void StartMessage()
	{
		activeIndex = 0;
		messageControl.ChangeText (messages [activeIndex]);
		messageControl.ActivateMessage ();
	}


}
