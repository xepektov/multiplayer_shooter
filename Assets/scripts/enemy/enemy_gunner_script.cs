using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class enemy_gunner_script : MonoBehaviour
{

    NavMeshAgent navMeshAgent;
    Vector3 direction,displacement,destination,difference,target_position;
    public float step_range,step_min;
    public GameObject target;
    public bool found,out_of_range, toggle_firing_mode;
    Rigidbody rb;
    public GameObject destination_visual,bullet,spawn_location;


    private void Awake()
    {
        this.gameObject.GetComponent<health_script>().object_type = health_script.object_type_list.gunner;
    }

    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log("start");
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        step_range = 20;
        step_min = 10;
        navMeshAgent.Warp(this.transform.position);
        destination = new Vector3(0, 3.1f, 0);
        navMeshAgent.SetDestination(new Vector3(0, 3.1f, 0));   //I think we cound use the this.transform.position as the initial destination , will look into it later
        found = false;
        out_of_range = true;
        navMeshAgent.updateRotation = true;
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //destination_visual.transform.position = destination;

        target_position = target.transform.position;



        if (!found &&(target_position - transform.position).magnitude < 85)
        {
           // Debug.Log("in range");
            found = true;
        }

        //if (rb.velocity.magnitude < 0.1)
        //{
        //    StartCoroutine("Stopped");

        //}
        
        //if (!navMeshAgent.isOnNavMesh)
        //{
        //    transform.position = new Vector3(0f,3.1f,0f);
        //    navMeshAgent.Warp(this.transform.position);
        //    navMeshAgent.enabled = false;
        //    navMeshAgent.enabled = true;
        //}

        /*if (!found)
        {
            gotoRandomLoactions(step_min,step_range);
            //difference = destination - this.transform.position;
            ////Debug.Log(difference.magnitude);
            //if ((difference).magnitude < 2)
            //{
            //    Debug.Log("new");
            //    direction = new Vector3(Random.Range(-3, 3), 0, Random.Range(-3, 3)).normalized;
            //    displacement = direction * Random.Range(5, step_range);
            //    destination = this.transform.position + displacement;
            //    //Debug.Log(direction);
            //    //Debug.Log(displacement);
            //    //Debug.Log(destination);

            //    navMeshAgent.SetDestination(destination);
            //}
        }*/
        
        else if (found)
        {
            if (!toggle_firing_mode)
            {
                toggle_firing_mode = true;
                StartCoroutine(Firing_mode());

            }
            if((target_position - transform.position).magnitude < 47)
            {

                if (out_of_range)
                {
                    direction = new Vector3(Random.Range(-4, 4), 0, Random.Range(-4, 4)).normalized;
                    displacement = direction * Random.Range(5, 8);
                    destination = this.transform.position + displacement;
                    //destination_visual.transform.position = destination;
                    navMeshAgent.SetDestination(destination);
                    out_of_range = false;


                    //gotoRandomLoactions(4f, 8f);
                    //destination_visual.transform.position = destination;
                }

                navMeshAgent.updateRotation = false;
                lookAtTarget();
                
                gotoRandomLoactions(4f,8f);

                //difference = destination - this.transform.position;


                ////Debug.Log(difference.magnitude);
                //if ((difference).magnitude < 2)
                //{
                //    navMeshAgent.updateRotation = false;
                //    Debug.Log("new");
                //    direction = new Vector3(Random.Range(-3, 3), 0, Random.Range(-3, 3)).normalized;
                //    displacement = direction * Random.Range(4, 8);
                //    destination = this.transform.position + displacement;
                //    //Debug.Log(direction);
                //    //Debug.Log(displacement);
                //    //Debug.Log(destination);

                //    navMeshAgent.SetDestination(destination);
                //}


                //Debug.Log("fire!");
            }


            else 
            {
                navMeshAgent.SetDestination(target_position);
                navMeshAgent.updateRotation = true;
                out_of_range = true;
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
       // Debug.Log("collide");
        
        direction = (new Vector3(0f, 3.1f, 0f)-this.transform.position).normalized;
        displacement = -direction * Random.Range(2, 4);
        destination = this.transform.position + displacement;
        //Debug.Log(direction);
        //Debug.Log(displacement);
       //Debug.Log(destination);

        navMeshAgent.SetDestination(destination);
    }

    void gotoRandomLoactions(float step_min, float step_range)
    {
        difference = destination - this.transform.position;
        //Debug.Log(difference.magnitude);
        if ((difference).magnitude < 2.5)
        {
            //Debug.Log("new");
            direction = new Vector3(Random.Range(-4, 4), 0, Random.Range(-4, 4)).normalized;
            displacement = direction * Random.Range(step_min, step_range);
            destination = this.transform.position + displacement;
            //Debug.Log(direction);
            //Debug.Log(displacement);
            //Debug.Log(destination);

            navMeshAgent.SetDestination(destination);
        }
    }

    void lookAtTarget()
    {
        //Debug.Log("init");
        Vector3 difference_look = target_position - transform.position;
        difference_look.Normalize();
        float rotation_y = Mathf.Atan2(-difference_look.z, difference_look.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, rotation_y + 90, 0f);
    }

    //IEnumerator Stopped()
    //{
    //    yield return new WaitForSeconds(1f);
    //    if(rb.velocity.magnitude < 0.1)
    //    {
    //        gotoRandomLoactions(4f,9f);
    //    }
    //}

    IEnumerator Shoot()
    {
        
        float bullet_interval = Random.Range(0.3f, 0.7f);
        int bullet_no = Random.Range(3, 5);
        
        for(int i = 0; i < bullet_no; i++)
        {
            //Debug.Log("shooting");
            Instantiate(bullet, spawn_location.transform.position, spawn_location.transform.rotation);
            yield return new WaitForSeconds(bullet_interval);
        }
    }

    IEnumerator Firing_mode()
    {
        float interval_firing_mode;
        Debug.Log("firing_mode");
        while (true)
        {
            interval_firing_mode = Random.Range(3, 6);
            StartCoroutine(Shoot());
            yield return new WaitForSeconds(interval_firing_mode);
        }
    }
}
