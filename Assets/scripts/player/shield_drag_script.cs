using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shield_drag_script : MonoBehaviour
{
    public Rigidbody myrigidbody;
    public Vector3 shooter_velocity;
    public Vector3 direction;
    public GameObject shield;
    public float drag_value;
    public float rotation_z;
    public float mag;
    float shield_duration;

    public bool is_shield_Active;

    //public Image shield_bar;             <---

    float time_left;
    public float duration_fixing_parameter;


    // Start is called before the first frame update
    void Start()
    {
        shield.SetActive(false);
        //shield_bar.enabled = false;  <---
        //shield.transform.rotation = Quaternion.Euler(0f, 0f, -90f);

    }

    // Update is called once per frame
    void Update()
    {
        shooter_velocity = myrigidbody.velocity;
        mag = shooter_velocity.magnitude;

        myrigidbody.AddForce(-shooter_velocity * drag_value);




        if (is_shield_Active)
        {
            time_left = (time_left - duration_fixing_parameter*Time.deltaTime);
            //shield_bar.fillAmount = time_left / shield_duration;

            if(time_left < 0.2)
            {
                is_shield_Active = false;
                shield.SetActive(false);
                //shield_bar.enabled = false;  <---
            }

        }
    }

    public void shield_timer_caller(float duration)
    {
        shield_duration = duration;
        time_left = duration;

        shield.SetActive(true);

        //shield_bar.enabled = true;          <---

        //StartCoroutine(shield_timer());
        is_shield_Active = true;
    }

    /*IEnumerator shield_timer()
    {
        shield.SetActive(true);
        shield_bar.enabled = true;

        yield return new WaitForSeconds(shield_duration);

        shield.SetActive(false);
        shield_bar.enabled = false;
    }*/


}

/*if (shooter_velocity.magnitude > 90)
        {
            shield.SetActive(true);

            direction = Vector3.Normalize(shooter_velocity);
            rotation_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            shield.transform.rotation = Quaternion.Euler(0f, 0f, rotation_z);
        }
        else
        {
            shield.SetActive(false);
        }*/