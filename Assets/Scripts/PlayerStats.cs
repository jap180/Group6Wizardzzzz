/// <summary>
/// Player stats.
/// Contains:
///   Health (includes Death)
///   Focus
/// 
/// By Daniel Zapata | djz24
/// </summary>
using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {
	/// <summary>
	/// The primary variables of the Health functionality.
	/// </summary>
	public int health		=	100;			// The actual current health of the entity
	public int startHealth	=	100;			// The amount of health the entity starts with.
	public bool dead		=	false;			// The death? condition. If true, entity is dead.
	public bool startDead	=	false;			// The default death status of the entity.
	
	/// <summary>
	/// The variables for the 'Focus' functionality.
	/// </summary>
	public int currentFocus	=	1000;
	public int startFocus	=	1000;			// Initial Focus amount, and maximum focus amount.
	public int regenFactor	=	100;			// Used to calculate how quickly the Focus regenerates.
												// = amount of Focus to regen in 1 second, when focus is full.
	
	// Use this for initialization
	void Start () {
		// Do Health stuff.
		dead = startDead;						// Initializes the 'dead' status of the entity
		health = startHealth;					// Initializes the health of the entity
		
		// Do Focus stuff
		currentFocus = startFocus;
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0){						// If the health falls below Magic Number '0'...
			Died();								// ... then the entity died. Death is handled by Died()
		}
		
		regenFocus(Time.deltaTime);				// Regenerate the appropriate amount of Focus.
	}
	
	/// <summary>
	/// Takes the damage.
	/// </summary>
	/// <param name='dmgAmount'>
	/// Dmg amount.
	/// </param>
	public void TakeDamage(int dmgAmount){
		health -= dmgAmount;
	}
	
	/// <summary>
	/// Gains the health.
	/// </summary>
	/// <param name='healAmount'>
	/// Heal amount.
	/// </param>
	void GainHealth(int healAmount){
		health += healAmount;
	}
	
	/// <summary>
	/// This entity is dead. 
	/// Sends a message to tagged GameController.
	/// Sets 'dead' true.
	/// </summary>
	void Died(){
		dead = true;
		GameObject.FindGameObjectWithTag("GameController").SendMessage("Died", gameObject); 					// to game master that you are dead so it can update Targets of other Units.
		//Destroy(gameObject);
	}
	
	/// <summary>
	/// Regens the focus based on the regenFactor
	/// </summary>
	void regenFocus(float t){
		float addAmount = t * regenFactor * (currentFocus/startFocus);
		float tempFocus = currentFocus + addAmount;
		if (tempFocus > startFocus){
			tempFocus = startFocus;
		}
		else
			currentFocus = (int)tempFocus;
	}
}
