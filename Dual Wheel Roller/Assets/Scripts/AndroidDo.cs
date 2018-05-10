using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidDo : AndroidBehaviour<AndroidDo>
{
    protected override string javaClassName
    {
        //要呼叫的class所在的Package名稱.要呼叫的java class名稱
        get { return "jcxyis.dualwheelroller.ForUnity"; }
    }

    /// <summary>
    /// 使用Toast
    /// </summary>
    public static void makeText(string message)
    {
        //第一個參數為要呼叫的Method名稱
        instance.CallStatic("ShowToast", message);
    }
    /*<application
        android:theme="@style/UnityThemeSelector"
        android:icon="@drawable/app_icon"
        android:label="@string/app_name">
        <activity android:name="com.unity3d.player.UnityPlayerActivity"
                  android:label="@string/app_name">
            <intent-filter>
                <action android:name="android.intent.action.MAIN" />
                <category android:name="android.intent.category.LAUNCHER" />
            </intent-filter>
            <meta-data android:name="unityplayer.UnityActivity" android:value="true" />
        </activity>
    </application> */
}
