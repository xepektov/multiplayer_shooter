using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class server_launcher_script : MonoBehaviourPunCallbacks
{

    public static server_launcher_script L_instance;

    [SerializeField] TMP_InputField roomInputField;
    [SerializeField] TMP_Text errorText;
    [SerializeField] TMP_Text roomNameText;
    [SerializeField] Transform roomListContent;
    [SerializeField] Transform playerListContent;
    [SerializeField] GameObject roomListItemPrefab;
    [SerializeField] GameObject playerListItemPrefab;
    [SerializeField] GameObject StartGameButton;


    private void Awake()
    {
        L_instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("connecting to master");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("connected to master");
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedLobby()
    {
        menu_manager_script.Instance.OpenMenu("title"); 
        Debug.Log("joined lobby");
        
    }
    // Update is called once per frame
    
    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(roomInputField.text))
        {
            return;
        }
        PhotonNetwork.CreateRoom(roomInputField.text);
        menu_manager_script.Instance.OpenMenu("loading");

    }

    public override void OnJoinedRoom()
    {
        Debug.Log("lobby");
        menu_manager_script.Instance.OpenMenu("room");
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;

        Player[] players = PhotonNetwork.PlayerList;

        foreach(Transform child in playerListContent)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < players.Length; i++)
        {
            Instantiate(playerListItemPrefab, playerListContent).GetComponent<player_list_item_script>().SetUp(players[i]);
        }

        StartGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        StartGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        errorText.text = "room creation failed" + message;
        menu_manager_script.Instance.OpenMenu("error");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        menu_manager_script.Instance.OpenMenu("loading");
    }

    public void JoinRoom(RoomInfo info)
    {
        PhotonNetwork.JoinRoom(info.Name);
        menu_manager_script.Instance.OpenMenu("loading");

        
    }

    public void StartGame()
    {
        PhotonNetwork.LoadLevel(1);
    }

    public override void OnLeftRoom()
    {
        menu_manager_script.Instance.OpenMenu("title");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {

        foreach(Transform trans in roomListContent)
        {
            Destroy(trans.gameObject);
        }

        for(int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].RemovedFromList)
                continue;
            Instantiate(roomListItemPrefab, roomListContent).GetComponent<room_list_item_script>().SetUp(roomList[i]);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Instantiate(playerListItemPrefab, playerListContent).GetComponent<player_list_item_script>().SetUp(newPlayer);
    }
}
