using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestSceneManager : MonoBehaviour {
	[SerializeField]private InputField inputArea;

	public void CheckConsoleLog()
	{
		LunarConsolePlugin.LunarConsole.Show();
	}
	public void TestAddNum()
	{
		int i = AndroidDo.instance.AddNum();
		Debug.Log("GET i is now "+i);
	}
	public void TestToastQuest()
	{
		string x = inputArea.text;
		if(x == ""){x = "Unity調用Android Studio的Java函數成功！";}
		AndroidDo.instance.makeText(x);	
	}
	public void TestOpenBt()
	{
		AndroidDo.instance.OpenBt();
	}
}
