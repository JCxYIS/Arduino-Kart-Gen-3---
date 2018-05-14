package JCxYIS.KartGen3;

import com.unity3d.player.UnityPlayerActivity;

import android.app.Activity;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.content.Intent;
import android.widget.Toast;
import com.unity3d.player.UnityPlayer;

import java.io.IOException;
import java.util.ArrayList;
import java.util.Set;
import java.util.UUID;


public class Act extends UnityPlayerActivity
{
    static public BluetoothAdapter bt;
    static public int i = 0;
    static public BluetoothDevice btKart;
    static public BluetoothSocket btSocket;



    static public int TestAddNum()
    {
        i += 1;
        ShowToast("i is now " + i);
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

    static public void BtTurnOnAndStartScan()
    {
        i = 8787;
        bt = BluetoothAdapter.getDefaultAdapter();
        if (!bt.isEnabled())
            bt.enable();
        bt.startDiscovery();
        ShowToast("Bluetooth is on! Now Discovering devices!");
    }
    static public void BtTurnOff()
    {
        i = 0;
        bt = BluetoothAdapter.getDefaultAdapter();
        bt.disable();
        ShowToast("Bluetooth is off!");
    }

    static public boolean BtTryConnectToKart()
    {
         btKart = bt.getRemoteDevice("98:D3:32:11:0A:44");
        UUID myUUID = UUID.fromString("00001101-0000-1000-8000-00805F9B34FB");
        try {
            btSocket = btKart.createInsecureRfcommSocketToServiceRecord(myUUID);//create a RFCOMM (SPP) connection
            bt.cancelDiscovery();
            btSocket.connect();//start connection
            ShowToast("Successfully Connect to kart!");
            return true;
        }catch (IOException e) {
            bt.startDiscovery();
            ShowToast("Failed to connect to kart!");
            return false;
        }

    }

    static public boolean BtSendMessage(final String message)
    {
        if (btSocket!=null)
        {
            try
            {
                btSocket.getOutputStream().write(message.getBytes());
                return true;
            }
            catch (IOException e)
            {
                return false;
            }
        }
        return false;
    }

    static public boolean BtDisconnect()
    {
        if (btSocket!=null) //If the btSocket is busy
        {
            try
            {
                btSocket.close(); //close connection
                ShowToast("Successfully disconnected!");
                return true;
            }
            catch (IOException e)
            {
                ShowToast("Failed to disconnect.");
                return false;
            }
        }
        return false;
    }

}


