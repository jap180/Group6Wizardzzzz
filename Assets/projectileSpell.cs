using UnityEngine;
using System.Collections;

public class projectileSpell : MonoBehaviour {
	public float speed = 5;
	public float spawnDistance = 1.0f;
	public Rigidbody spell;
	public GameObject HUD;
	
	// Use this for initialization
	void Start () {
	}
	
	void CastSpell () {
	Rigidbody spellClone = (Rigidbody) Instantiate(spell, transform.position, transform.rotation);
	spellClone.velocity = transform.forward * speed;
	}
	
// Update is called once per frame
	void Update () {
	if(Input.GetKeyDown ("Alpha1")) {//Receive message from player control to cast spell
		CastSpell();
		}
	}
}

/*		if (Input.GetKeyDown ("Alpha1") { //Receive message from player control to cast spell
			SendMessage(""); //Send casting message to HUD
			Rigidbody spell
 			spell = Instantiate(spell, transform.position + spawnDistance * transform.forward, transform.rotation) as Rigidbody;
			transform.position += Time.deltaTime * speed * transform.forward;
*/