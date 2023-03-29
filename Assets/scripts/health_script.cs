using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System.IO;

public class health_script : MonoBehaviourPunCallbacks, IDamageable
{
    public float Hitpoints,max_Hitpoints;
    public GameObject levelManager;
    //level_manager_script lvl;
    public enum object_type_list {shooter, ball_spawner, gunner,mortar};
    public object_type_list object_type;
    level_Manager_script manager;

    public Image health_bar;

    [SerializeField]
    player_manager_photon_script player_Manager_Photon_Script;

    PhotonView PV;


    private void Awake()
    {
        if (this.gameObject.CompareTag("Player"))
        {
            PV = GetComponentInParent<PhotonView>();
            player_Manager_Photon_Script = PhotonView.Find((int)PV.InstantiationData[0]).GetComponent<player_manager_photon_script>();
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {

        //setHitpoints(100);
        manager = levelManager.GetComponent<level_Manager_script>();

        if (object_type == object_type_list.ball_spawner)
        {
            setHitpoints(manager.hitpoint_ball_spawner);
        }
        //setHitpoints(levelManager.getcomponent<levelmanagerscript>().getBallSpawner().hitpoints);

        if (object_type == object_type_list.gunner)
        {
            setHitpoints(manager.hitpoint_gunner);
        }

        if (object_type == object_type_list.shooter)
        {
            setHitpoints(manager.hitpoint_shooter);
        }

        if (object_type == object_type_list.mortar)
        {
            setHitpoints(manager.hitpoint_mortar);
        }

        health_bar.fillAmount = 1;
        health_bar.fillAmount = Hitpoints / max_Hitpoints;

    }

    // Update is called once per frame
    void Update()
    {

        health_bar.fillAmount = Hitpoints / max_Hitpoints;
        /*if (Hitpoints <= 0)
        {
            //this.gameObject.SetActive(false);
            if (this.gameObject.CompareTag("Player"))
            {
                die();
            }
            else
            {
                //Destroy(this.gameObject);
            }
        }*/
    }

    public void setHitpoints(float hitpoints)
    {
        Hitpoints = hitpoints;
        max_Hitpoints = hitpoints;
    }

    public void setDamage(float damage)
    {
        //Hitpoints = Hitpoints - damage;
        Debug.Log("setdamage");
        //health_bar.fillAmount = Hitpoints / max_Hitpoints;
        PV.RPC(nameof(RPC_takeDamage), PV.Owner, damage);
    }

    [PunRPC]    
    void RPC_takeDamage(float damage, PhotonMessageInfo info)
    {
        /*if (!PV.IsMine)
        {
            return;
        }*/
        Hitpoints -= damage;
        health_bar.fillAmount = Hitpoints / max_Hitpoints;
        if (Hitpoints <= 0)
        {
            Debug.Log("rpcall");
            die();
            player_manager_photon_script.Find(info.Sender).getKill();

            Debug.Log(info.Sender.NickName + " killed " + info.photonView.Owner.NickName);
        }
    }

    public void health_powerup(float health)
    {
        if(health + Hitpoints > max_Hitpoints)
        {
            Hitpoints = max_Hitpoints;
            health_bar.fillAmount = Hitpoints / max_Hitpoints;
        }

        else
        {
            Hitpoints = Hitpoints + health;
            health_bar.fillAmount = Hitpoints / max_Hitpoints;
        }
    }

    void die()
    {
        //setHitpoints(150f);
        player_Manager_Photon_Script.Die();
    }
}
