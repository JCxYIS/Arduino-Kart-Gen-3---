﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidDo : MonoBehaviour
{
    AndroidJavaClass jc;

    static public AndroidDo instance{ get {return GameObject.Find("AndroidDo").GetComponent<AndroidDo>();}}
    
    void Awake()
    {
        if(!GameObject.Find("AndroidDo"))
		{
			gameObject.name = "AndroidDo";
            DontDestroyOnLoad(gameObject);
			//Debug.Log("AndroidDo not exist! Now making.");
		}
		else
		{
			Debug.Log("AndroidDo exist! Now deleting new one.");
            Destroy(gameObject);
            return;
		}
        jc = new AndroidJavaClass ("JCxYIS.KartGen3.Act");
        Debug.Log("Get JC.");
    }

    /// <summary>
    /// 使用Toast
    /// </summary>
    public void makeText(string message)
    {
        //第一個參數為要呼叫的Method名稱
        jc.CallStatic("ShowToast", message);
    }
    /// <summary>
    /// 測試AddNum
    /// </summary>
    public int AddNum()
    {
        int i = jc.CallStatic<int> ("TestAddNum");
        return i;
    }
    /// <summary>
    /// open bt and start scan
    /// </summary>
    public void OpenBt()
    {
        jc.CallStatic("BtTurnOnAndStartScan");
    }
    /// <summary>
    /// close bt
    /// </summary>
    public void CloseBt()
    {
        jc.CallStatic("BtTurnOff");
    }
    /// <summary>
    /// true: success; false: fail
    /// </summary>
    public bool BtTryConnectToKart()
    {
        return jc.CallStatic<bool>("BtTryConnectToKart");
    }
    /// <summary>
    /// close bt
    /// </summary>
    public bool BtDisconnect()
    {
        return jc.CallStatic<bool>("BtDisconnect");
    }
    /// <summary>
    /// true: success; false: fail
    /// </summary>
    public bool BtSendMessage(string msg)
    {
        return jc.CallStatic<bool>("BtSendMessage", msg);
    }
}
