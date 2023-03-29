using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class player_list_item_script : MonoBehaviourPunCallbacks
{
    Player player;
    [SerializeField] TMP_Text text;

    // Start is called before the first frame update
    public void SetUp(Player _player)
    {
        player = _player;
        text.text = _player.NickName;
    }

    // Update is called once per frame
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        if(player == otherPlayer)
        {
            Destroy(gameObject);
        }
    }

    public override void OnLeftRoom()
    {
        Destroy(gameObject);
    }
}
