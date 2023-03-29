using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueball_script : MonoBehaviour
{
    public float speed;

    Vector3 fw_dir;

    public GameObject shooter;

    Rigidbody rb;

    public GameObject levelManager;
    public float damage = 10;

    // Start is called before the first frame update
    void Awake()
    {
        damage = levelManager.GetComponent<level_Manager_script>().damage_blueball;

        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(transform.forward * Time.deltaTime * speed);
        GetComponent<Rigidbody>().AddRelativeForce(transform.forward * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("its working");
        if (collision.gameObject.CompareTag("obstacle") || collision.gameObject.CompareTag("enemy") || collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.TryGetComponent<health_script>(out var health_Script))
            {
                health_Script.setDamage(damage);
            }
            Destroy(this.gameObject);
        }
    }

    /* void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("enemy") || hit.gameObject.CompareTag("Player"))
        {
            if(hit.gameObject.TryGetComponent<health_script>(out var health_Script))
            {
                health_Script.setDamage(damage);
            }
        }

        Destroy(this.gameObject);

    }*/

    /*private void OnTriggerEnter(Collider other)
    {
        Debug.Log("its working");
        if (other.gameObject.tag=="obstacle" || other.gameObject.CompareTag("enemy") || other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }*/
}
