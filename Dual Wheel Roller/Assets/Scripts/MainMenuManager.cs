using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour {
	[SerializeField]private Text appName;
	bool isShowing; 

	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		GetComponent<Animation>().Rewind();
		appName.text = "二箍輾轉 -  Dual Wheel Roller "+GameManager.version;
	}

	public void ToggleMenu()
	{
		Animation a = GetComponent<Animation>();
		if(!isShowing)
		{
			a["Main-MenuFlyIn"].speed = 1;
			a.Play();
			isShowing = true;
		}
		else
		{
			a["Main-MenuFlyIn"].speed = -1;
			a["Main-MenuFlyIn"].time = a["Main-MenuFlyIn"].length;
			a.Play();
			isShowing = false;
		}
	}

	public void OpenBt()
    {
        AndroidDo.instance.OpenBt();
		MainManager.instance.UpdateStat("No Connection");
    }
	public void TryCoonectToKart()
	{
		if(MainManager.instance.currentStat == "No Connection")
		{
			AndroidDo.instance.makeText("Now trying connect to kart.");
			bool x = AndroidDo.instance.BtTryConnectToKart();
			if(x)
			{
				MainManager.instance.UpdateStat("Ready");
				ToggleMenu();
			}
		}
		else
		{
			AndroidDo.instance.makeText("Please turn on BT and make Status = No connection");
		}
	}
	public void TryDisconnectToKart()
	{
		if(MainManager.instance.currentStat == "Ready")
		{
			bool x = AndroidDo.instance.BtDisconnect();
			if(x)
				MainManager.instance.UpdateStat("No Connection");
		}
		else
		{
			AndroidDo.instance.makeText("Only when you are ready...");
		}
	}
}
