using UnityEngine;
using System.Collections;

public class projectileSpell : MonoBehaviour {
	public float speed = 5; //Movement speed of the spell
	public GameObject spell;
	public GameObject PlayerStats;
	public int focusValue;
	public int focusCost = 10;
	
	// Use this for initialization
	void Start () {
	}
	
	public void CastSpell () {
	focusValue = focusValue - focusCost; //Reduce focus resource
	Rigidbody spellClone = (Rigidbody) Instantiate(spell, transform.position, transform.rotation);
	spellClone.velocity = Camera.main.transform.forward * speed;
	}
	
// Update is called once per frame
	void Update () {
		
	}
}

/*		if (Input.GetKeyDown ("Alpha1") { //Receive message from player control to cast spell
			SendMessage(""); //Send casting message to HUD
			Rigidbody spell
 			spell = Instantiate(spell, transform.position + spawnDistance * transform.forward, transform.rotation) as Rigidbody;
			transform.position += Time.deltaTime * speed * transform.forward;
*/