using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {
	[SerializeField]private Text tiptext;
	public void GoScene(string scene)
	{
		Debug.Log("GO "+scene);
		StartCoroutine(SwitchToScene(scene));
	}
	IEnumerator SwitchToScene(string scene)
	{
		AsyncOperation async = SceneManager.LoadSceneAsync(scene);
		while(!async.isDone)
		{
			tiptext.text = string.Format("Now loading: {0}%",async.progress);
			yield return false;
		}
		yield return true;
	}
}
