using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer_rotate_script : MonoBehaviour
{
    public float angle1;
    public float angle2;
    public float angular_speed;
    public bool caught;
    public GameObject target;

    public bool full_rotate;

    // Start is called before the first frame update
    void Start()
    {
        caught = false;
    }

    // Update is called once per frame
    void Update()
    {

        normal();

       /* if (!caught)
        {
            normal();
        }*/

       /* else
        {
            lookAtTarget();
        }*/

    }

    void normal()
    {
        if (full_rotate){
            transform.Rotate(new Vector3(0, 0, angular_speed) * Time.deltaTime);
        }
        else
        {
            transform.localEulerAngles = new Vector3(-90, 0, Mathf.PingPong(Time.time * angular_speed, (angle1 - angle2)));
        }
        
    }

    void lookAtTarget()
    {
        //Debug.Log("init");
        Vector3 difference_look = target.transform.position - transform.position;
        difference_look.Normalize();
        float rotation_y = Mathf.Atan2(-difference_look.z, difference_look.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(-90f, rotation_y - 90, 0f);
    }

}
