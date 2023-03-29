using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class nickname_display : MonoBehaviour
{
    [SerializeField] PhotonView playerPV;
    [SerializeField] TMP_Text name_text;

    private void Start()
    {
        if (playerPV.IsMine)
        {
            gameObject.SetActive(false);
        }
        name_text.text = playerPV.Owner.NickName;   

    }
}
