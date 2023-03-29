using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class name_manager : MonoBehaviour
{
    [SerializeField] TMP_InputField nickname_inputfield;

    private void Start()
    {
        if (PlayerPrefs.HasKey("nickname"))
        {
            nickname_inputfield.text = PlayerPrefs.GetString("nickname");
            PhotonNetwork.NickName = PlayerPrefs.GetString("nickname");
        }
        else
        {
            nickname_inputfield.text =  "Player " + Random.Range(0, 1000).ToString("0000");
            OnNicknameInputValueChanged();
        }
    }

    public void OnNicknameInputValueChanged()
    {
        PhotonNetwork.NickName = nickname_inputfield.text;
        PlayerPrefs.SetString("nickname", nickname_inputfield.text);
    }
}
