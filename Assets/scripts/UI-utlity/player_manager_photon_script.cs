using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Photon.Pun;
using System.IO;
using Photon.Realtime;
//using System.Data.Entity;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class player_manager_photon_script : MonoBehaviour
{
    PhotonView PV;
    public int kills;
    public int deaths;

    public GameObject shooter_pack;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    // Start is called before the first frame update
    void Start()
    {
        kills = 0;
        if (PV.IsMine)
        {
            CreateController(); 
        }
    }

    // Update is called once per frame
    void CreateController()
    {
        Transform spawnpoint = SpawnManager.spawn_instance.getSpawnpoint();
        shooter_pack = PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "shooter_pack"), spawnpoint.transform.position, Quaternion.identity,0, new object[] {PV.ViewID });
    }

    public void Die()
    {
        PhotonNetwork.Destroy(shooter_pack);
        CreateController();

        deaths++;

        Hashtable hash = new Hashtable();
        hash.Add("deaths", deaths);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }

    public static player_manager_photon_script Find(Player player)
    {
        return FindObjectsOfType<player_manager_photon_script>().SingleOrDefault(x => x.PV.Owner == player);
    }

    public void getKill()
    {
        PV.RPC(nameof(RPC_getKill), PV.Owner);
    }


    [PunRPC]
    void RPC_getKill()
    {
        kills++;

        Hashtable hash = new Hashtable();
        hash.Add("kills", kills);
        PhotonNetwork.LocalPlayer.SetCustomProperties(hash);
    }
}
