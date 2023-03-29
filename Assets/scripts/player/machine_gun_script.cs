using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class machine_gun_script : MonoBehaviour
{

    public float firerate;
    float nextfire;
    float resultant;

    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject spawn_loacation;

    public float cooldown_bar;
    float cooldown_max;
    float cooldown_rate;
    float overheat_rate;

    bool cooldown_enabled;

    PhotonView PV;

    //GameObject[] bullets;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    // Start is called before the first frame update
    void Start()
    {
        


        //    offset_y = 1.2f ;
        //  firerate = 1;
        nextfire = 0;

        cooldown_max = 50;
        cooldown_bar = cooldown_max;
        cooldown_rate = 0.3f;
        overheat_rate = 2;
        cooldown_enabled = false;

        
    }

    // Update is called once per frame
    void Update()
    {
        if (!PV.IsMine)
        {
            return;
        }

        if ((cooldown_bar < cooldown_max) && (!cooldown_enabled))
        {
            StartCoroutine(cooldown());
            cooldown_enabled = true;
        }

        if ( (Input.GetKey(KeyCode.Mouse0)) && (Time.time> nextfire) && (cooldown_bar > overheat_rate))
        {
            nextfire = Time.time + firerate;
            bullet = PhotonNetwork.Instantiate("Capsule_player", spawn_loacation.transform.position, transform.rotation);
            bullet.GetComponent<machine_gun_bullet_script>().machine_gun = this;

            cooldown_bar = cooldown_bar - overheat_rate;
        }

    }

    IEnumerator cooldown()
    {
        while (cooldown_bar < cooldown_max)
        {
            cooldown_bar++;
            //Debug.Log(cooldown_bar);

            yield return new WaitForSeconds(cooldown_rate);


            /*if (cooldown_bar >= cooldown_max)
            {
             break;
            }*/
        }
        cooldown_enabled = false;

    }

    public void destory_bullet(GameObject bullet1)
    {
        PhotonNetwork.Destroy(bullet1);
        Debug.Log("bullet_uda");
    }

}
