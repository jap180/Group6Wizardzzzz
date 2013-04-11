/// <summary>
/// Player HUD.
/// Displays information to player.
/// 
/// By Daniel Zapata.
/// </summary>

using UnityEngine;
using System.Collections;

public class PlayerHUD : MonoBehaviour {
	
	// Crosshair Feilds
	public Texture2D crosshairTexture;
	Rect crosshairPosition;
	
	// Wand Fields
	public Texture2D wandTexture;
	Rect wandPosition;
	
	public GameObject gameMaster;
	public string gameMasterTag = "GameController";
	
	// Use this for initialization
	void Start () {
		// Make the rectangle in the center of the screen.
		crosshairPosition = new Rect(
				((Screen.width - crosshairTexture.width)/2),
				((Screen.height - crosshairTexture.height)/2), 
				crosshairTexture.width, 
				crosshairTexture.height);
				
		// Make the wand rectangle in the right corner of the screen.
		wandPosition = new Rect(
				(Screen.width/2),
				(Screen.height/2), 
				Screen.width, 
				Screen.height);
		
		// Initialize game master
		gameMaster = GameObject.FindGameObjectWithTag(gameMasterTag);
	}
	
	// Update is called once per frame
	void Update () {
	}

	
	void OnGUI(){
		// Draws the crosshair inside of the already created crosshairPosition
		GUI.DrawTexture(crosshairPosition, crosshairTexture, ScaleMode.ScaleToFit, true, 0.0f);
		
		// Draws the wand inside of the already created wandPosition
		GUI.DrawTexture(wandPosition, wandTexture, ScaleMode.ScaleToFit, true, 0.0f);
	}
}