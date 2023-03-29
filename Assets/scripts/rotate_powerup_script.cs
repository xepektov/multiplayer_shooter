using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_powerup_script : MonoBehaviour
{
    public float rotation_speed;
    public GameObject shooter;
    public GameObject level_manager;
    public GameObject mega_weapon_button;
    public int index;

    float value; // hitpoints for health , seconds duration for shield , amount of crystals for crystal
    public enum powerup_enum
    {
        health,
        shield,
        crystal,
        blueball
    }

    public powerup_enum powerup_type;

    // Start is called before the first frame update
    void Start()
    {
        shooter = GameObject.Find("shooter");
        level_manager = GameObject.Find("Level_Manager");
        //rotation_speed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotation_speed, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            if (powerup_type == powerup_enum.health)
            {
                value = level_manager.GetComponent<level_Manager_script>().health_powerup_value; 
                shooter.GetComponent<health_script>().health_powerup(value);
            }

            else if (powerup_type == powerup_enum.shield)
            {
                value = level_manager.GetComponent<level_Manager_script>().shield_duration;
                shooter.GetComponent<shield_drag_script>().shield_timer_caller(value);
            }

            else if (powerup_type == powerup_enum.blueball)
            {
                value = 1;
                shooter.GetComponent<mega_weapon_script>().active= true;
                mega_weapon_button.SetActive(true);
            }

            else if (powerup_type == powerup_enum.crystal)
            {
                value = (Random.Range(3,9));
                shooter.GetComponent<player_stats_manager_script>().add_Crystals((int)value);
                
            }



            level_manager.GetComponent<powerup_script>().powerup_count--;
            level_manager.GetComponent<powerup_script>().powerup_bool_list[index] = true;

            Destroy(this.gameObject);
        }
    }
}
