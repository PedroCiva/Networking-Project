using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkController : NetworkManager
{
    public static NetworkConnection connection;
    
    public override void OnServerConnect(NetworkConnection Conn)
    {
        //Assigning our static connection
        connection = Conn;

        //Only moves ball when second player connects
        if (Conn.hostId >= 0)
        {
            BallController.MoveBall();
        }
    }
}
