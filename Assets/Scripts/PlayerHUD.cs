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
	public Texture2D wandTexture4;		// Wand frames for running animation
	public Texture2D wandTexture3;		// Must set these in editor
	public Texture2D wandTexture2;
	public Texture2D wandTexture1;
	
	
	public GameObject gameMaster;
	public string gameMasterTag = "GameController";
	
	// Focus Fields
	public PlayerStats playerStats;
	public int currentFocus;
	public int maxFocus;
	public Texture2D focusBar;			// Need to set in editor.
	public Texture2D focusBarOutline;	// Aslo need to set in editor.
	
	// Time trackers.
	float runningTimeStart;
	
	// Movement trackers.
	bool running 	= 	false;
	
	
	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
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
		DrawFocus();
		
		DrawCrosshair();
		
		DrawWand();
	}
	
	/// <summary>
	/// Draws the focus bar HUD stuff.
	/// </summary>
	void DrawFocus(){
		// Get current Focus
		currentFocus = playerStats.getCurrentFocus();
		float temp = ((float)currentFocus)/((float)maxFocus);
		// Draw Focus bar
		GUI.DrawTexture(new Rect(0, 0, ((temp)*(Screen.width/4)), (Screen.height/12)), focusBar); // Draw the blue, normalized by max length of width/4
		GUI.DrawTexture(new Rect(0, 0, Screen.width/4, (Screen.height/12)), focusBarOutline);	// Draw the outline
	}
	
	/// <summary>
	/// Draws the crosshair.
	/// </summary>
	void DrawCrosshair(){
		// Draws the crosshair inside of the already created crosshairPosition
		GUI.DrawTexture(crosshairPosition, crosshairTexture);
	}
	
	/// <summary>
	/// Draws the wand.
	/// Decides whether to draw animated wand or static wand.
	/// </summary>
	void DrawWand(){
		// Preliminary calcs to determine movement information.
		if (Input.anyKey && !running){
			running = true;
			runningTimeStart = Time.time;
		}
		else if(!Input.anyKey){
			running = false;
		}
		// Drawing if-set to determine what kind of wand drawing scheme to use.
		if(!running){
			// Draws the static wand
			// Draws the wand inside of the already created wandPosition
			GUI.DrawTexture(wandPosition, wandTexture);
		}
		else{
			// draw last frame
			if(Time.time > (runningTimeStart+1.0f)){
				GUI.DrawTexture(wandPosition, wandTexture4);
				runningTimeStart = Time.time;
			}
			// draw 2nd to last frame
			else if(Time.time > (runningTimeStart+0.7f)){
				GUI.DrawTexture(wandPosition, wandTexture3);
			}
			// draw 3rd to last frame
			else if(Time.time > (runningTimeStart+0.5f)){
				GUI.DrawTexture(wandPosition, wandTexture2);
			}
			// draw 1st frame
			else if(Time.time > (runningTimeStart+0.2f)){
				GUI.DrawTexture(wandPosition, wandTexture1);
			}
			else{
				GUI.DrawTexture(wandPosition, wandTexture);
			}
		}
			
	}
}
