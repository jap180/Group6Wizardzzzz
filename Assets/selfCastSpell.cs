using UnityEngine;
using System.Collections;

public class selfCastSpell : MonoBehaviour {
	public GameObject PlayerStats;
	public int protectionValue;
	public int protectionUp;
	public int focusValue;
	public int focusCost = 5;

	// Use this for initialization
	void Start () {
		PlayerStats = GameObject.Find("PlayerStats");
	
	}
	void CastSelfSpell() {
		focusValue = focusValue - focusCost;
		protectionValue = protectionUp + protectionValue;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey (KeyCode.Alpha2)) {//Receive message from player control to cast spell
		CastSelfSpell();
		}
	
	}
}
