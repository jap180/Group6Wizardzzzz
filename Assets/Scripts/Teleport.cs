/// <summary>
/// Teleportation functionality. Methods should be called by Input handler.
/// </summary>
using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {
	
	public string terrainTag = "Terrain";	// The tag of the ground
	public string imagePrefabName = "teleportImage";
	public int teleportFocusCost = 50;
	
	GameObject instanceOfImage;
	bool imageExists = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(1)){
			if(imageExists){
				/*Destroy(instanceOfImage);
				CreateTeleportImage();*/
				MoveTeleportImage();
			}
			else
				CreateTeleportImage();
			
		}
		if(Input.GetMouseButtonUp(1)){
			TeleportToLocation(instanceOfImage.transform.position);
			Destroy(instanceOfImage);
			imageExists = false;
		}
	}
	
	public void CreateTeleportImage(){
		RaycastHit hit;			// Make the thing to receive information on hits.
		// If the Raycast from the cam's position, along the cam's direction hits something within rayCastDistance meters, it'll put collision info in hit.
		if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit)){
			// If we hit the ground
			if ( (hit.collider.CompareTag(terrainTag)) ){
				imageExists = true;
				instanceOfImage = Instantiate(Resources.Load(imagePrefabName,typeof(GameObject)), hit.point, Quaternion.identity) as GameObject;
			}
		}
	}
	public void MoveTeleportImage(){
		RaycastHit hit;			// Make the thing to receive information on hits.
		// If the Raycast from the cam's position, along the cam's direction hits something within rayCastDistance meters, it'll put collision info in hit.
		if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit)){
			// If we hit the ground
			if ( (hit.collider.CompareTag(terrainTag)) ){
				instanceOfImage.transform.position =  hit.point;
			}
		}	
	}
	
	public void TeleportToLocation(Vector3 pos){
		Vector3 tempPos = new Vector3(pos.x, (pos.y + (gameObject.GetComponent<CharacterController>().height/2)+0.001f), pos.z);
		gameObject.transform.position = tempPos;
		gameObject.GetComponent<PlayerStats>().SendMessage("ReduceFocus", teleportFocusCost);
	}
}
