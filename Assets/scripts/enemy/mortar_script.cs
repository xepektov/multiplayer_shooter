using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mortar_script : MonoBehaviour
{
    public GameObject target;
    public bool in_range;
    public int range;
    public GameObject shell;
    public GameObject spawn_location;
    public GameObject new_shell;

    private void Awake()
    {
        this.gameObject.GetComponent<health_script>().object_type = health_script.object_type_list.mortar;
    }

    // Start is called before the first frame update
    void Start()
    {
        in_range = false;
        StartCoroutine(blast());
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Mathf.Abs(Vector3.Distance(target.transform.position, transform.position)));
        lookAtTarget();
        if ( (Mathf.Abs(Vector3.Distance(target.transform.position,transform.position)) < range) )
        {

            if (!(in_range)) { in_range = true; }
                
            
        }
        else
        {
            in_range = false;
        }
    }

    void lookAtTarget()
    {
        //Debug.Log("init");
        Vector3 difference_look = target.transform.position - transform.position;
        difference_look.Normalize();
        float rotation_y = Mathf.Atan2(-difference_look.z, difference_look.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, rotation_y + 90, 0f);
    }

    IEnumerator blast()
    {
        //Debug.Log("blst1");
        float interval_firing_mode;
        interval_firing_mode = Random.Range(4, 7);
        Debug.Log("blast_mode");

        while (true)
        {

            Debug.Log("blst");
            if (in_range)
            {
                Debug.Log("blst1");
                new_shell = Instantiate(shell, spawn_location.transform.position, spawn_location.transform.rotation) as GameObject;
            }

            //new_shell.GetComponent<shell_script>().hit_location = target.transform.position;
            //new_shell.GetComponent<Rigidbody>().AddForce(new Vector3(0, 10, 0), ForceMode.Impulse);

            yield return new WaitForSeconds(interval_firing_mode);
        }
        if (!in_range)
        {
            yield return new WaitForSeconds(interval_firing_mode);
        }
    }
}
