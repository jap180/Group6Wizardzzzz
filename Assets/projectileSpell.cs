using UnityEngine;
using System.Collections;

public class projectileSpell : MonoBehaviour {
	public float speed = 5;
	public float spawnDistance = 1.0f;
	public Rigidbody DestructiveSpell;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("Alpha1")) {
 
			GameObject.Instatiate(DestructiveSpell, transform.position + spawnDistance * transform.forward, transform.rotation);
			transform.position += Time.deltaTime * speed * transform.forward;
		}
	
	}
}
