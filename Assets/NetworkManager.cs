using UnityEngine;
using System.Collections;

public class NetworkManager: MonoBehaviour{
	
	float buttonX;
	float buttonY;
	float buttonW;
	float buttonH;
	
	//array to hold all of the data of the hosts
	HostData[] hostData;
	
	//boolean to determine if we should refresh the hosts or not
	bool refreshing;
	
	string gameName = "Wizard_game";
	
	void Start(){
		refreshing = false;
		buttonX = (float) (Screen.width * .05);
		buttonY = (float) (Screen.width * .05);
		buttonW = (float) (Screen.width * .1);
		buttonH = (float) (Screen.width * .1);
	}
	
	void Update(){
		//if we are in a refreshing frame, we add the extra servers to the host data list
		if(refreshing){
			if(MasterServer.PollHostList().Length > 0){
				refreshing = false;
				Debug.Log(MasterServer.PollHostList().Length);
				hostData = MasterServer.PollHostList();
			}
		}
	}
	
	void startServer(){
		Network.InitializeServer(2, 25000, !Network.HavePublicAddress());
		//Wizards is what all games will be called, planning to change this to a field entered by a user
		MasterServer.RegisterHost(gameName, "Wizards", "");
	}
	
	void refreshHostList(){
		MasterServer.RequestHostList(gameName);
		refreshing = true;
	}
	
	void OnServerInitialized(){
		Debug.Log("Server Initialized");	
	}
	
	void OnMasterServerEvent(MasterServerEvent mse){
		if(mse == MasterServerEvent.RegistrationSucceeded){
			Debug.Log("Registration Success!");
		}
	}

	
	//GUIs
	void OnGUI(){
		//only display the buttons when the player is not in a game already
		if(!Network.isClient && !Network.isServer){
			if(GUI.Button(new Rect(buttonX, buttonY, buttonW, buttonH), "Start Server")){
				Debug.Log("Starting Server");
				startServer();
			}
			
			if(GUI.Button(new Rect(buttonX, (float)(buttonY * 1.2 + buttonH), buttonW, buttonH), "Refresh Hosts")){
				refreshHostList();	
			}
			if(hostData.Length > 0){
				for(int i= 0; i < hostData.Length; i++){
					if(GUI.Button(new Rect((float)(buttonX * 2 + buttonW), (float) (buttonY * 1.2 + buttonH * i), buttonW * 3, buttonH), hostData[i].gameName)){
						Network.Connect(hostData[i]);
					}
				}
			}
		}
	}
}