using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestSceneManager : MonoBehaviour {
	[SerializeField]private InputField inputArea;
	public int RefusedMonika = 0;
	
	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		string dia = "Hi, I just want to sure if Monika is the only best girl.";
		dia += " JUST press OK to continue, REA~LLY an easy task.";
		PopUpBubbleManager.CreatePop("",dia, MonikaED, true, NotMonikaED);
	}
	void MonikaED()
	{
		string dia = "See, that's easy, right?";
		PopUpBubbleManager.CreatePop("MONIKAED",dia, null, false);
	}
	void NotMonikaED()
	{
		RefusedMonika += 1;
		string dia = "";
		if(RefusedMonika == 1)
		{
			dia = "Eh? I'll ask you again, is Monika the best girl?";
		}
		else if(RefusedMonika == 2)
		{
			dia = "Seriously? Isn't Monika the best girl?";
		}
		else if(RefusedMonika == 3)
		{
			dia = "Very funny, Courtney.";
		}
		else
		{
			for(int i = 0; i<RefusedMonika-3 ; i++)
			{
				dia += "<color=#ff0000ff>JUST MONIKA.</color> ";
			}
		}
		PopUpBubbleManager.CreatePop("",dia, MonikaED, true, NotMonikaED);
	}
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
