using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class mega_weapon_script : MonoBehaviour
{
    public GameObject blueball;
    public GameObject spawn_location;
    public bool active;
    public GameObject mega_weapon_button;


    public Vector3 fw_dir = Vector3.forward;

    PhotonView PV;


    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    // Start is called before the first frame update
    void Start()
    {
        

        active = false;
        mega_weapon_button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!PV.IsMine)
        {
            return;
        }

        fw_dir = Vector3.forward;
        if (active)
        {
            mega_weapon_button.SetActive(true);
        }
    }

    public void blue_ball()
    {
        if (active) { Instantiate(blueball, spawn_location.transform.position, this.transform.rotation); }
        active = false;
        mega_weapon_button.SetActive(false);
    }

    


}
