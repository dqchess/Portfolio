using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
public class Network : MonoBehaviourPunCallbacks
{
    private readonly string gameVersion = "1.0";
    // Start is called before the first frame update
    private void Start()
    {
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();       
    }

    // Update is called once per frame
    private void Update()
    {

    }

    public override void OnConnectedToMaster()
    {
        Connect();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.LogError(cause.ToString());
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        PhotonNetwork.CreateRoom(null, new RoomOptions{MaxPlayers = 2});
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Stage");
        Debug.Log("Joined!");
    }
    public void Connect()
    {
        if(PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
        }
        else
        {
            Debug.LogError("TRY RECONNECTING!");
            PhotonNetwork.ConnectUsingSettings();
        }
    }
}
