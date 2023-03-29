using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using TMPro;

public class room_list_item_script : MonoBehaviour
{

    [SerializeField] TMP_Text text;

    public RoomInfo info;

    // Start is called before the first frame update
    public void SetUp(RoomInfo _info)
    {
        info = _info;
        text.text = _info.Name;
    }

    // Update is called once per frame
    public void OnClick()
    {
        server_launcher_script.L_instance.JoinRoom(info);
    }
}
