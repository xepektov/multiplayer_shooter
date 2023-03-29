using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell_script : MonoBehaviour
{
    public GameObject target ;
    //public Vector3 hit_location;
    public float shell_force;
    public float ceiling_height;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("shooter");
        //hit_location = Vector3.zero;
        GetComponent<Rigidbody>().AddForce(new Vector3(0, shell_force,0), ForceMode.Impulse);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > ceiling_height)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            transform.position = new Vector3(target.transform.position.x+Random.Range(-7,7),ceiling_height-5 , target.transform.position.z + Random.Range(-7, 7));
            GetComponent<Rigidbody>().AddForce(new Vector3(0, -(shell_force)/2, 0),ForceMode.Impulse);
        }
    }
}
