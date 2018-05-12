using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestSceneManager : MonoBehaviour {

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		
	}
	public void TestAddNum()
	{
		int i = AndroidDo.GetInstance().AddNum();
		Debug.Log("GET i is now "+i);
	}
	public void TestToastQuest()
	{
		AndroidDo.GetInstance().makeText("Unity調用Android Studio的Java函數成功！");	
	}
	public void CheckConsoleLog()
	{
		LunarConsolePlugin.LunarConsole.Show();
	}
}
