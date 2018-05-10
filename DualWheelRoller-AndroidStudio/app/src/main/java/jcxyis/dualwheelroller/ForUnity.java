package jcxyis.dualwheelroller;

import android.bluetooth.BluetoothAdapter;

import com.unity3d.player.UnityPlayer;

public class ForUnity
{
    static public void OpenBluetooth()
    {
        UnityPlayer.currentActivity.runOnUiThread(new Runnable()
        {
            @Override
            public void run()
            {
                BluetoothAdapter btAdapter = BluetoothAdapter.getDefaultAdapter();

                if(!btAdapter.isEnabled())
                    btAdapter.enable();
            }
        });
    }

    static public void ShowToast(final String content)//傳入的參入必須為final，才可讓Runnable()內部使用
    {
        UnityPlayer.currentActivity.runOnUiThread(new Runnable()
        {
            @Override
            public void run()
            {
                Toast.makeText(UnityPlayer.currentActivity, content, Toast.LENGTH_SHORT).show();
            }
        });
    }
}
