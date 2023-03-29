using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class joystick_machine_gun_script : MonoBehaviour
{

    //float offset_y = 1.2f ;
    public float firerate;
    float nextfire;
    float resultant;

    [SerializeField]
    GameObject bullet;
    [SerializeField]
    GameObject spawn_loacation;

    public FixedJoystick moveJoystick;
    public FixedJoystick rotateJoystick;

    public float cooldown_bar;
    float cooldown_max;
    float cooldown_rate;
    float overheat_rate;
    
    bool cooldown_enabled;

    

    //public GameObject rotate_joystick;
    public Image cooldown_circle;
    // Start is called before the first frame update
    void Start()
    {
        //rotate_joystick = GameObject.Find("rotate_joystick");
        cooldown_circle = rotateJoystick.GetComponent<Image>();
        //    offset_y = 1.2f ;
        //  firerate = 1;
        nextfire = 0;

        cooldown_max = 50;
        cooldown_bar = cooldown_max;
        cooldown_rate = 0.3f;
        overheat_rate = 2;
        cooldown_enabled = false;

        cooldown_circle.fillAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if ((cooldown_bar < cooldown_max) && (!cooldown_enabled))
        {
            StartCoroutine(cooldown());
            cooldown_enabled = true;
        }

        float hoz1 = -rotateJoystick.Horizontal;

        float ver1 = rotateJoystick.Vertical;

        resultant = Mathf.Sqrt((hoz1 * hoz1) + (ver1 * ver1));

        if ((resultant > 0.8) && (Time.time > nextfire) && (cooldown_bar > overheat_rate) )
        {
            nextfire = Time.time + firerate;
            Instantiate(bullet, spawn_loacation.transform.position, transform.rotation);

            cooldown_bar = cooldown_bar - overheat_rate;
            //Debug.Log(cooldown_bar);
        }

        cooldown_circle.fillAmount = cooldown_bar / cooldown_max;

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
