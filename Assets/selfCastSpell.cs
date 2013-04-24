using UnityEngine;
using System.Collections;

public class selfCastSpell : MonoBehaviour {
	public PlayerStats stats;
	//public GameObject PlayerStats;
	public int protectionValue;
	public int protectionUp;
	public int focusValue;
	public int focusCost = 5;

	// Use this for initialization
	void Start () {
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
			
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
