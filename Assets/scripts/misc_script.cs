using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misc_script : MonoBehaviour
{
    Vector3 direction, displacement, destination, difference, target_position;
    public float step_range, step_min;
    public GameObject target,bullet,spawn_loc;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
        target_position = target.transform.position;
        
    }

    void lookAtTarget()
    {
        //Debug.Log("init");
        Vector3 difference_look = target_position - transform.position;
        difference_look.Normalize();
        float rotation_y = Mathf.Atan2(-difference_look.z, difference_look.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, rotation_y + 90, 0f);
    }

    IEnumerator Shoot()
    {

        float bullet_interval = Random.Range(0.5f, 1f);
        int bullet_no = Random.Range(3, 5);

        for (int i = 0; i < bullet_no; i++)
        {
            Debug.Log("shooting");
           // while (true)
          //  {
                Instantiate(bullet, spawn_loc.transform.position, spawn_loc.transform.rotation);
                yield return new WaitForSeconds(bullet_interval);
           // }
        }
    }
}
