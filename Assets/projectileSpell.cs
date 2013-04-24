using UnityEngine;
using System.Collections;

public class projectileSpell : MonoBehaviour {
	public float speed = 5; //Movement speed of the spell
	public GameObject spell; //The object to be instantiated
	public int focusCost = 50; //The cost of the spell to cast it
	public PlayerStats playerStats;
	
	// Use this for initialization
	void Start () {
		playerStats = gameObject.GetComponent<PlayerStats>(); //Point at the PlayerStats script to get values needed
	}
	
// <<<<<<< HEAD
	/*public void CastSpell () {
		focusValue = focusValue - focusCost; //Reduce focus resource
		Rigidbody spellClone = (Rigidbody) Instantiate(spell, transform.position, transform.rotation);
		spellClone.velocity = Camera.main.transform.forward * speed;
	}
//=======*/
	public void CastSpell () {
		playerStats.currentFocus = playerStats.currentFocus - focusCost; //Reduce focus resource
		Rigidbody spellClone = (Rigidbody) Instantiate(spell, transform.position, transform.rotation); //Create the spell moving
	spellClone.velocity = Camera.main.transform.forward * speed; //Send spell outward from camera
//>>>>>>> Obtain the Focus from PlayerStats
	}
	
// Update is called once per frame
	void Update () {
//<<<<<<< HEAD
		
//=======
	if(Input.GetKey (KeyCode.Alpha1)) {//Receive message from player control to cast spell
		if (playerStats.currentFocus >= focusCost) { //If the player has enough focus to cast the spell and casts it if they do
			CastSpell();
			SendMessage("SpellCast");
		}
		else {
			SendMessage("NeedFocus");
		}
		}
//>>>>>>> Obtain the Focus from PlayerStats
	}
}
