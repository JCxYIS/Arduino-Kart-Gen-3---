package JCxYIS.KartGen3;

import com.unity3d.player.UnityPlayerActivity;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.widget.Toast;
import com.unity3d.player.UnityPlayer;

import java.util.ArrayList;
import java.util.Set;

public class Act extends UnityPlayerActivity
{
    static public BluetoothAdapter btAdapter;
    static public int i = 0;

    static public int TestAddNum()
    {

        i += 1;
        ShowToast("i is now" + i);
        return i;
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

    static public void GetBluetooth()
    {
        btAdapter = BluetoothAdapter.getDefaultAdapter();

        if (!btAdapter.isEnabled())
            btAdapter.enable();

    }

    static public ArrayList<String> GetBlueToothDevices()
    {
        Set<BluetoothDevice> pairedDevices;
        pairedDevices = btAdapter.getBondedDevices();
        btAdapter.()

        ArrayList<String> list = new ArrayList<String>();
        for(BluetoothDevice bt : pairedDevices)
            list.add(bt.getName());
    }
}


