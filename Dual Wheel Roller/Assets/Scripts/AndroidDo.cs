using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidDo : MonoBehaviour
{
    AndroidJavaClass jc;

    static public AndroidDo GetInstance(){return GameObject.Find("AndroidDo").GetComponent<AndroidDo>();}
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        jc = new AndroidJavaClass ("JCxYIS.KartGen3.Act");
        //jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
    }

    /// <summary>
    /// 使用Toast
    /// </summary>
    public void makeText(string message)
    {
        //第一個參數為要呼叫的Method名稱
        jc.CallStatic("ShowToast", message);
    }

    public int AddNum()
    {
        int i = jc.CallStatic<int> ("TestAddNum");
        return i;
    }
    
}
