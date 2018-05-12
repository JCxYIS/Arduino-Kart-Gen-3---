using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour {
	private Scrollbar LboostScrollBar, RboostScrollBar;
	private Text LboostDisplay, RboostDisplay, boostDisplay;
	private float lBoost, rBoost;


	// Use this for initialization
	void Start () 
	{
		LboostScrollBar = GameObject.Find("Canvas/Lboost").GetComponent<Scrollbar>();
		RboostScrollBar = GameObject.Find("Canvas/Rboost").GetComponent<Scrollbar>();
		LboostDisplay = GameObject.Find("Canvas/Lboost/value").GetComponent<Text>();
		RboostDisplay = GameObject.Find("Canvas/Rboost/value").GetComponent<Text>();
		boostDisplay = GameObject.Find("Canvas/boost/value").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		CalcBoost();
		DisplayVal();
	}

	void CalcBoost()
	{
		lBoost = (LboostScrollBar.value - 0.5f)*200;
		rBoost = (RboostScrollBar.value - 0.5f)*200;
	}
	void DisplayVal()
	{
		LboostDisplay.text = lBoost.ToString("0");
		RboostDisplay.text = rBoost.ToString("0");
		boostDisplay.text = ((lBoost+rBoost)/2).ToString("0.0");
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
			lab.text = string.Format("{0}%",async.progress);
			yield return false;
		}
		yield return true;
	}
}
