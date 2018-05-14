using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour {
	private Scrollbar LboostScrollBar, RboostScrollBar;
	private SimpleTouchController joyStick;
	private Text LboostDisplay, RboostDisplay, usingFuncDisplay, joyStickValDisplay;
	private float lBoost, rBoost;
	private string usingFunc;


	// Use this for initialization
	void Start () 
	{
		Resources.UnloadUnusedAssets();
		LboostScrollBar = GameObject.Find("Canvas/Lboost").GetComponent<Scrollbar>();
		RboostScrollBar = GameObject.Find("Canvas/Rboost").GetComponent<Scrollbar>();
		LboostDisplay = GameObject.Find("Canvas/Lboost/value").GetComponent<Text>();
		RboostDisplay = GameObject.Find("Canvas/Rboost/value").GetComponent<Text>();
		usingFuncDisplay = GameObject.Find("Canvas/UsingFunc/value").GetComponent<Text>();
		joyStick = GameObject.Find("Canvas/SimpleTouch Joystick").GetComponent<SimpleTouchController>();
		joyStickValDisplay = GameObject.Find("Canvas/SimpleTouch Joystick/value").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		UsingFuncBehavior();
		CalcBoost();
		DisplayVal();
	}
	//--------------------------------------------------------------------------------------
	void CalcBoost()
	{
		lBoost = (LboostScrollBar.value - 0.5f)*200;
		rBoost = (RboostScrollBar.value - 0.5f)*200;
	}
	void DisplayVal()
	{
		LboostDisplay.text = lBoost.ToString("0");
		RboostDisplay.text = rBoost.ToString("0");
		usingFuncDisplay.text = usingFunc;
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

}
