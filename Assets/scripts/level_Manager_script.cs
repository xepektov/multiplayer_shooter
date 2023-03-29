using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*public struct powerup
{
    public Transform powerup_transform;
    public bool vacant;
}*/

public class level_Manager_script : MonoBehaviour
{
    public GameObject shooter;
    //player_stats_manager_script player_stats;


    //shooter health
    public float hitpoint_shooter;
    //enemy health
    public float hitpoint_ball_spawner, hitpoint_gunner,hitpoint_mortar;

    //bullet damage
    public float damage_mgbullet, damage_mgbullet_player, damage_ball,damage_grenade,damage_rate_lazer,damage_rate_player_lazer,damage_blueball,damage_mortar;

    //ball spawner
    public float ball_interval;

    //gunner
    public float gunner_shoot_dur, gunner_shoot_no, gunner_shoot_interval;

    public GameObject mgbullet, mgbullet_player , ball,grenade,lazer,player_lazer;

    public float health_powerup_value, crystal_number, shield_duration;

    //power_ups

    /*int powerup_count = 0;
    public Transform[] powerup_transform_array;  //location of powerups 
    public List<bool> powerup_bool_list = new List<bool>();
    //public bool[] powerup_bool_array;  //array of all powerup positions in the level

    //powerups gameobjects to be spawned :
    *//*public GameObject coin_bag;
    public GameObject life;
    public GameObject shield;*//*

    public GameObject[] powerup_spawn;*/


    private void Awake()
    {
        

        mgbullet_player.GetComponent<machine_gun_bullet_script>().levelManager = this.gameObject;
        mgbullet.GetComponent<machine_gun_bullet_script>().levelManager = this.gameObject;
        ball.GetComponent<enemy_ball_script>().levelManager = this.gameObject;
        grenade.GetComponent<grenade_script>().levelManager = this.gameObject;
        lazer.GetComponent<enemyLazer_script>().levelManager = this.gameObject;
        player_lazer.GetComponent<player_lazer_script>().levelManager = this.gameObject;



        
    }

    //instructions:
    // 1. assign hitpoints,damages in inspector of levelmanager
    // 2. assign levelmanager in the health scripts of each shooter or enemy
    // 3. assign projectiles in the level manager inspector( done automatically)

    // Start is called before the first frame update
    void Start()
    {
        damage_mgbullet = shooter.GetComponent<player_stats_manager_script>().cur_mg_damage;
        damage_grenade = shooter.GetComponent<player_stats_manager_script>().cur_proj_damage;
        damage_rate_player_lazer = shooter.GetComponent<player_stats_manager_script>().cur_lazer_damage;
        hitpoint_shooter = shooter.GetComponent<player_stats_manager_script>().cur_lvl_health;
        shield_duration = shooter.GetComponent<player_stats_manager_script>().cur_shield_time;


        /*powerup_count = 0;

        for(int i = 0; i < powerup_transform_array.Length ; i++)
        {
            //powerup_array[i].powerup_transform = powerup_transform_array[i];
            powerup_bool_list.Add(true);
            
        }

        StartCoroutine(powerup_timer());*/
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    /*IEnumerator powerup_timer()
    {
        while (true)
        {
            if (powerup_count<= 3)
            {
                yield return new WaitForSeconds(4);

                //
                int index = Random.Range(0, powerup_transform_array.Length);
                if (powerup_bool_list[index] == true)
                {
                    Instantiate(powerup_spawn[Random.Range(0, powerup_spawn.Length)], powerup_transform_array[index].position, Quaternion.identity);
                    powerup_count++;
                    powerup_bool_list[index] = false;
                    Debug.Log("done");
                }
                //
            }
            else
            {
                Debug.Log("limit");
            }
        }


    }*/

    /*void spawn_powerup()
    {
        int index = Random.Range(0,powerup_transform_array.Length);
        if (powerup_bool_list[index] == true)
        {
            Instantiate(powerup_spawn[Random.Range(0, powerup_spawn.Length)], powerup_transform_array[index].position, Quaternion.identity);
            powerup_count++;
            powerup_bool_list[index] = false;
            Debug.Log("done");
        }

        else
        {
            //spawn_powerup();
        }
    }*/
}
