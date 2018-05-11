package JCxYIS.KartGen3Lib.activity;

import com.unity3d.player.UnityPlayerActivity;
import android.bluetooth.BluetoothAdapter;
import android.widget.Toast;
import com.unity3d.player.UnityPlayer;

public class Activity extends UnityPlayerActivity
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
