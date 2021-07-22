using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menucontroller : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    [SerializeField] private GameObject UsernameMenu;
    [SerializeField] private GameObject ConnectPanel;
    [SerializeField] private GameObject StartButton;
    
    [SerializeField] private InputField UsernameInput;
    [SerializeField] private InputField CreateGameInput;
    [SerializeField] private InputField JoinGameInput;

    [SerializeField] private Text status;
    [SerializeField] private Text temporal;
    // Update is called once per frame
    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    private void Start()
    {
        UsernameMenu.SetActive(true);
        status.text = "Connecting to server";
    }
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
     
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
        status.text = "Connected to " + PhotonNetwork.ServerAddress;
        
    }

    public void ChangeUsernameInput()
    {
        if (UsernameInput.text.Length >= 3)
        {
            StartButton.SetActive(true);
        }
        else
        {
            StartButton.SetActive(false);
        }
    }

    public void SetUsername()
    {
        UsernameMenu.SetActive(false);
        PhotonNetwork.NickName = UsernameInput.text;
    }

    public void CreateGame()
    {temporal.text = "conectado";
        Photon.Realtime.RoomOptions options = new Photon.Realtime.RoomOptions();
        options.MaxPlayers = 2;
        //options.IsOpen = true;
        //options.IsVisible = true;
        PhotonNetwork.CreateRoom(CreateGameInput.text, options, null);
        
    }

    public void JoinGame()
    {
     
        PhotonNetwork.JoinRoom(JoinGameInput.text);
        temporal.text = "Joining to " + JoinGameInput.text;
        
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        PhotonNetwork.LoadLevel("Tablero");
        
    }
    
}
