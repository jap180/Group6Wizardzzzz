using UnityEngine;
using System.Collections;

public class selfCastSpell : MonoBehaviour {
	public PlayerStats stats;
	//public GameObject PlayerStats;
	public int protectionValue;
	public int protectionUp;
	public int focusCost = 50;
	public PlayerStats playerStats;

	// Use this for initialization
	void Start () {
<<<<<<< HEAD
		//PlayerStats = GameObject.Find("PlayerStats");
	
	}
	public void CastSelfSpell(string s) {
		if (s.Equals("Protect")) {
			focusCost = 100; //Focus costs change with spells - JAP
			stats.ReduceFocus(focusCost); //Defensive spells now properly reduce focus - JAP
			protectionValue = protectionUp + protectionValue;
		} if (s.Equals("Heal")) {
			focusCost = 300;
			stats.ReduceFocus(focusCost);
			stats.GainHealth(20);
		}
			
=======
		playerStats = gameObject.GetComponent<PlayerStats>(); //Point at the PlayerStats script to get values needed
	
	}
	void CastSelfSpell() {
		playerStats.currentFocus = playerStats.currentFocus - focusCost; //Reduce focus resource
		protectionValue = protectionUp + protectionValue;
>>>>>>> Obtain the Focus from PlayerStats
	}
	
	// Update is called once per frame
	void Update () {
<<<<<<< HEAD
		
=======
		if(Input.GetKey (KeyCode.Alpha2)) {//Receive message from player control to cast spell
			if(playerStats.currentFocus >= focusCost) {
			CastSelfSpell();
			SendMessage("SpellCast");
			}
			else {
				SendMessage("NeedFocus");
			}
		}
	
>>>>>>> Obtain the Focus from PlayerStats
	}
}
