using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_ball_script : MonoBehaviour
{
    public float speed;
    public GameObject target;
    public GameObject levelManager;
    public float damage ;

    Vector3 difference;
    //public float diff_mag, times_hit;

    //int done =0;
    private NavMeshAgent navMeshAgent;
    

    // Start is called before the first frame update
    void Start()
    {
        //speed = 25f;
        //times_hit =2;
        navMeshAgent = this.GetComponent<NavMeshAgent>();
        damage = levelManager.GetComponent<level_Manager_script>().damage_ball;
    }

    // Update is called once per frame
    void Update()
    {
        //    difference = player.transform.position - transform.position;
        //    //Vector3.Normalize(difference);                   //  idk why but this doesn't work 
        //    difference = difference.normalized;   

        //    if(transform.position.z < -0.1 && done<2){
        //        transform.position = new Vector3(transform.position.x, transform.position.y, 1);
        //        done ++;
        //    } 

        navMeshAgent.destination = target.transform.position;
    }

    //void FixedUpdate(){
        
    //    diff_mag = Vector3.Magnitude(difference);
    //    transform.Translate(new Vector3( difference.x , difference.y , 0) * speed * Time.deltaTime, Space.World);
    //}

    void OnCollisionEnter(Collision hit){
        if (hit.gameObject.CompareTag("Player"))
        {
            hit.gameObject.GetComponent<health_script>().setDamage(damage);
            Destroy(this.gameObject);
        }

        

        else if(hit.gameObject.tag == "projectile"){
            //Debug.Log("hit1");
            Destroy(hit.gameObject);
            Destroy(this.gameObject);
        }

        else if(hit.gameObject.tag == "shield")
        {
            Destroy(this.gameObject);
        }

    }

}
