package jcxyis.dualwheelroller;

import android.bluetooth.BluetoothAdapter;

import com.unity3d.player.UnityPlayer;

public class BTforUnity
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


}
