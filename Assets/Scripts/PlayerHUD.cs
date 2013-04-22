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
	
	// Focus Fields
	public PlayerStats playerStats;
	public int currentFocus;
	public int maxFocus;
	public Texture2D focusBar;			// Need to set in editor.
	public Texture2D focusBarOutline;	// Aslo need to set in editor.
	
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
				(3*Screen.width/5),
				(3*Screen.height/5),
				Screen.width-1000, 
				Screen.height-400);		// 60 is the bottom corner offset
		
		// Initialize game master
		gameMaster = GameObject.FindGameObjectWithTag(gameMasterTag);
		
		// Initialize the playerStats pointer.
		playerStats = gameObject.GetComponent<PlayerStats>();
		maxFocus = playerStats.startFocus;		// And set the maxFocus to the startFocus from playerStats.
	}
	
	// Update is called once per frame
	void Update () {
	}

	
	void OnGUI(){
		// Get current Focus
		currentFocus = playerStats.getCurrentFocus();
		// Draw Focus bars.
		GUI.DrawTexture(new Rect(0, 0, ((currentFocus/maxFocus)*Screen.width/4), (Screen.height/12)), focusBar); // Draw the blue, normalized by max length of width/4
		GUI.DrawTexture(new Rect(0, 0, Screen.width/4, (Screen.height/12)), focusBarOutline);	// Draw the outline
		
		// Draws the crosshair inside of the already created crosshairPosition
		GUI.DrawTexture(crosshairPosition, crosshairTexture);
		
		// Draws the wand inside of the already created wandPosition
		GUI.DrawTexture(wandPosition, wandTexture);
	}
}
