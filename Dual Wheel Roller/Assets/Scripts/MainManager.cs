using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour {
	static public MainManager instance{get{return GameObject.Find("MainManager").GetComponent<MainManager>();}}
	private Scrollbar LboostScrollBar, RboostScrollBar, servoScrollBar;
	private SimpleTouchController joyStick;
	private Text LboostDisplay, RboostDisplay, usingFuncDisplay, joyStickValDisplay, statusDisplay, servoDisplay;
	private float lBoost, rBoost, servo;
	private string usingFunc;
	private float lastSentTime;//send message
	public string currentStat = "No Bluetooth";
	//"No Bluetooth" "No Connection" "Ready"


	// Use this for initialization
	void Start () 
	{
		Resources.UnloadUnusedAssets();
		LboostScrollBar = GameObject.Find("Canvas/Lboost").GetComponent<Scrollbar>();
		RboostScrollBar = GameObject.Find("Canvas/Rboost").GetComponent<Scrollbar>();
		servoScrollBar = GameObject.Find("Canvas/Servo").GetComponent<Scrollbar>();
		LboostDisplay = GameObject.Find("Canvas/Lboost/value").GetComponent<Text>();
		RboostDisplay = GameObject.Find("Canvas/Rboost/value").GetComponent<Text>();
		servoDisplay = GameObject.Find("Canvas/Servo/value").GetComponent<Text>();
		usingFuncDisplay = GameObject.Find("Canvas/UsingFunc/value").GetComponent<Text>();
		statusDisplay = GameObject.Find("Canvas/Status/value").GetComponent<Text>();
		joyStick = GameObject.Find("Canvas/SimpleTouch Joystick").GetComponent<SimpleTouchController>();
		joyStickValDisplay = GameObject.Find("Canvas/SimpleTouch Joystick/value").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		UsingFuncBehavior();
		CalcBoost();
		DisplayVal();
		SendMessage();	
	}
	//--------------------------------------------------------------------------------------
	void CalcBoost()
	{
		lBoost = (LboostScrollBar.value - 0.5f)*200;
		rBoost = (RboostScrollBar.value - 0.5f)*200;
		servo = servoScrollBar.value * 180;
	}
	void DisplayVal()
	{
		LboostDisplay.text = lBoost.ToString("0");
		RboostDisplay.text = rBoost.ToString("0");
		servoDisplay.text = servo.ToString("0");
		usingFuncDisplay.text = usingFunc;
		statusDisplay.text = currentStat;
		Vector2 joyStickMovement = joyStick.GetTouchPosition;
		joyStickValDisplay.text = (joyStickMovement.x*100).ToString("0.0");
		joyStickValDisplay.text += "\n" + (joyStickMovement.y*100).ToString("0.0");
	}
	void UsingFuncBehavior()
	{
		switch(usingFunc)
		{
			case "JoyStick":
				Vector2 joyStickMovement = joyStick.GetTouchPosition;
				LboostScrollBar.value = joyStickMovement.x/2 + 0.5f;
				RboostScrollBar.value = joyStickMovement.y/2 + 0.5f;
				break;
			case "BoostBar":
				break;
			case "ServoBar":
				break;
		}
	}
	void SendMessage()
	{	
		if(currentStat == "Ready" && Time.time > lastSentTime + 0.2f)
		{//MOTOR
			string msg = "";
			msg += "M";
			if(lBoost >= 0) msg+= "+";
			msg += (lBoost*2.55f).ToString("000");
			if(rBoost >= 0) msg+= "+";
			msg += (rBoost*2.55f).ToString("000");
			msg += '\n';
			bool ok = AndroidDo.instance.BtSendMessage(msg);
			Debug.Log( string.Format("OK?{0}, msg={1}",ok,msg) );
			lastSentTime = Time.time;
		}
		else if(currentStat == "Ready" && Time.time > lastSentTime + 0.1f)
		{
			string msg = "";
			msg += "S+";
			if(lBoost >= 0) msg+= "+";
			msg += servo.ToString("000");
			msg += '\n';
			bool ok = AndroidDo.instance.BtSendMessage(msg);
			Debug.Log( string.Format("OK?{0}, msg={1}",ok,msg) );
		}
	}

	public void GoMenu()
	{
		Debug.Log("GO Menu.");
		StartCoroutine(SwitchToScene("Menu"));
	}
	IEnumerator SwitchToScene(string scene)
	{
		AsyncOperation async = SceneManager.LoadSceneAsync(scene);
		Text lab = GameObject.Find("Canvas/BackToMenu/value").GetComponent<Text>();
		//lab.color = new Color(lab.color.r, lab.color.g, lab.color.b, 1);
		while(!async.isDone)
		{
			lab.text = string.Format("{0}%",async.progress*100);
			yield return false;
		}
		yield return true;
	}

	public void UpdateUsingFunc(string func)
	{
		usingFunc = func;
	}
	public void UpdateStat(string stat)
	{
		currentStat = stat;
	}
	
}
