using UnityEngine;
using System.Collections;
public class MouseActions : MonoBehaviour {
	
	
	public Teleport tele;
	public projectileSpell spell1;
	public selfCastSpell spell2;
	
	// Use this for initialization
	void Start () {	
	
	}
	
	// Update is called once per frame
	void Update () {
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
	}
}
