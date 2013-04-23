/// <summary>
/// Teleportation functionality. Methods should be called by Input handler.
/// </summary>
using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {
	
	public string terrainTag = "Terrain";	// The tag of the ground
	public GameObject image;				// The prefab of the player's teleport image
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		ShowTeleportImage();
	}
	
	public void ShowTeleportImage(){
		RaycastHit hit;			// Make the thing to receive information on hits.
		// If the Raycast from the cam's position, along the cam's direction hits something within rayCastDistance meters, it'll put collision info in hit.
		if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit)){
			// If we hit the ground
			if ( (hit.collider.CompareTag(terrainTag)) ){
				Instantiate(image, hit.collider.transform.position, Quaternion.identity);
			}
		}	
	}
	
	
}
