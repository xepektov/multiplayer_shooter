using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class player_lazer_script : MonoBehaviour
{

    [SerializeField] LayerMask lazer_layer1;
    [SerializeField] LineRenderer lazer_linerenderer;
    public GameObject levelManager;

    //[SerializeField] GameObject target_gameobject;
    public float lazer_length;

    float damage_rate,resultant;

    public FixedJoystick moveJoystick;
    public FixedJoystick rotateJoystick;


    public float cooldown_bar;
    float cooldown_max;
    float cooldown_rate;
    float overheat_rate;

    bool cooldown_enabled;

    Image cooldown_circle;

    PhotonView PV;

    private void Awake()
    {
        PV = GetComponentInParent<PhotonView>();
    }


    // Start is called before the first frame update
    void Start()
    {
        

        lazer_linerenderer.SetPosition(0, transform.position);
        lazer_linerenderer.SetPosition(1, transform.position + (Vector3.forward * lazer_length));
        damage_rate = levelManager.GetComponent<level_Manager_script>().damage_rate_player_lazer;
        this.gameObject.GetComponent<LineRenderer>().enabled = false;


        cooldown_circle = rotateJoystick.GetComponent<Image>();
        //    offset_y = 1.2f ;
        //  firerate = 1;
        

        cooldown_max = 80f;
        cooldown_bar = cooldown_max;
        cooldown_rate = 0.3f;
        overheat_rate = 5f;
        cooldown_enabled = false;

        cooldown_circle.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!PV.IsMine)
        {
            return;
        }

        float hoz1 = -rotateJoystick.Horizontal;

        float ver1 = rotateJoystick.Vertical;

        if ((cooldown_bar < cooldown_max) && (!cooldown_enabled))
        {
            StartCoroutine(cooldown());
            cooldown_enabled = true;
        }

        resultant = Mathf.Sqrt((hoz1 * hoz1) + (ver1 * ver1));

        if (resultant > 0.8 && (cooldown_bar > overheat_rate) )
        {
            this.gameObject.GetComponent<LineRenderer>().enabled = true;
            shoot_lazer();
            cooldown_bar = cooldown_bar - (overheat_rate * Time.deltaTime);
        }
        else
        {
            this.gameObject.GetComponent<LineRenderer>().enabled = false;
        }

        cooldown_circle.fillAmount = cooldown_bar / cooldown_max;

    }
    
    
    
    void shoot_lazer() 
    {
        lazer_linerenderer.SetPosition(0, transform.position);


        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo1, lazer_length))
        {
            //lazer_linerenderer.SetPosition(1, hitinfo1.transform.position);
            lazer_linerenderer.SetPosition(1, transform.position + (transform.TransformDirection(Vector3.forward) * hitinfo1.distance));


            

            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, hitinfo1.distance, lazer_layer1))
            {
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * lazer_length, Color.red);
                //lazer_linerenderer.SetPosition(1, hitinfo.transform.position);
                //lazer_linerenderer.SetPosition(1, transform.position + (Vector3.forward * lazer_length));
                //lazer_linerenderer.SetPosition(1, transform.position + (transform.TransformDirection(Vector3.forward) * (hitinfo.transform.position - this.transform.position).magnitude));
                Debug.Log("hit");
                hitinfo.collider.gameObject.GetComponent<health_script>().setDamage(damage_rate * Time.deltaTime);
            }

            else if (hitinfo1.collider.gameObject.CompareTag("enemy_ball"))
            {
                Destroy(hitinfo1.collider.gameObject);
            }

            /*else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo2, lazer_length, lazer_layer))
            {
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * lazer_length, Color.red);
                //lazer_linerenderer.SetPosition(1, hitinfo.transform.position);
                //lazer_linerenderer.SetPosition(1, transform.position + (Vector3.forward * lazer_length));
                //lazer_linerenderer.SetPosition(1, transform.position + (transform.TransformDirection(Vector3.forward) * (hitinfo.transform.position - this.transform.position).magnitude));
                //Debug.Log("hit");
                target_gameobject.GetComponent<health_script>().setDamage(damage_rate * Time.deltaTime);
            }*/

        }

        else
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * lazer_length, Color.green);
            //lazer_linerenderer.SetPosition(1, hitinfo.transform.position);
            //Debug.Log("nohit");
            lazer_linerenderer.SetPosition(1, transform.position + (transform.TransformDirection(Vector3.forward) * lazer_length));
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


}
