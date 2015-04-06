using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

    // networking feature that began development but was cut from project due to a change in design and for time

    private int port = 25000;
    private int maximumPlayerAmount = 2;
    private const string  typeName = "RubIt_Multiplayer_Balance_of_Power";
    private const string gameName = "Room_Name";

    private void StartServer()
    {
        Network.InitializeServer(maximumPlayerAmount, port, !Network.HavePublicAddress());
        MasterServer.RegisterHost(typeName, gameName);
    }

    void OnServerInitialized()
    {
        Debug.Log("Server Initialized");
    }
}
