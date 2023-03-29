using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ball_spawner_script : MonoBehaviour
{

    public GameObject ball,player,spawnlocation;
    public float ball_speed,interval;
    public GameObject levelManager; 

    //int boundary_x1 , boundary_x2 , boundary_y1 , boundary_y2;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {

        ball_speed=20;
        this.gameObject.GetComponent<health_script>().object_type = health_script.object_type_list.ball_spawner;

        // boundary_x1 = 110;
        // boundary_x2 = -110;
        // boundary_y1 = 110;
        // boundary_y2 = -110;

        StartCoroutine(ball_spawner_timer());
        //interval=4f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void spawn(){
         GameObject enemy = Instantiate(ball) as GameObject;
        //// enemy.transform.position = new Vector3(Random.Range(boundary_x1,boundary_x2),Random.Range(boundary_y1,boundary_y2),1);
         //enemy.transform.position = spawnlocation.transform.position;
        enemy.GetComponent<NavMeshAgent>().Warp(spawnlocation.transform.position);

    //    GameObject enemy = new GameObject("ball");
    //    Vector3 sourcePostion = spawnlocation.transform.position;//The position you want to place your agent
    //    NavMeshHit closestHit;
    //    if (NavMesh.SamplePosition(sourcePostion, out closestHit, 500, 1))
    //    {
    //        enemy.transform.position = closestHit.position;
    //        enemy.AddComponent<NavMeshAgent>();
    //        //TODO
    //    }
    //    else
    //    {
    //        Debug.Log("...");
    //    }

        enemy.GetComponent<enemy_ball_script>().target =player;
        
        enemy.GetComponent<enemy_ball_script>().speed =ball_speed;
    }

    IEnumerator ball_spawner_timer(){
        while(true){
            yield return new WaitForSeconds(interval);
            spawn();
        }
    }
}
