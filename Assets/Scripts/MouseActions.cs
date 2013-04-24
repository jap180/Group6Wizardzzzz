using UnityEngine;
using System.Collections;

/**
 * MouseActions - John Phillips, jap180
 * Controls all actions performed by keyboard and mouse sans movement and looking
 **/
public class MouseActions : MonoBehaviour {
	
	public Teleport tele;
	public projectileSpell spell1;
	public selfCastSpell spell2;
	public string defSpell = "Protect";
	
	// Use this for initialization
	void Start () {	
	
	}
	
	// Update is called once per frame
	void Update () {
		//Left Click - Offensive Spell
		if(Input.GetMouseButtonDown(0) && !(Input.GetKey(KeyCode.LeftShift)))
			spell1.CastSpell();
		
		//Right Click - Defensive Spell
		if(Input.GetMouseButtonDown(1))
			spell2.CastSelfSpell(defSpell);
		
		//Shift + Left Click - Teleportation
		if(Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftShift)){
			if(tele.Image()){
				tele.MoveTeleportImage();
			} else {
				tele.CreateTeleportImage();
		} } if(Input.GetMouseButtonUp(0) && tele.Image()){
			tele.TeleportToLocation(tele.GetImage().transform.position);
			tele.DestroyImage();
			tele.SetImage(false);
		}
		
		//3 - Sets the defensive spell to Protect
		if(Input.GetKey(KeyCode.Alpha3))
			defSpell = "Protect";
		
		//4 - Sets the defensive spell to Heal
		if(Input.GetKey(KeyCode.Alpha4))
			defSpell = "Heal";
	}
}