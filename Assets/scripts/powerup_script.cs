using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup_script : MonoBehaviour
{

    //power_ups

    public int powerup_count = 0;
    public int max_powerup_count;
    public Transform[] powerup_transform_array;  //location of powerups 
    public List<bool> powerup_bool_list = new List<bool>();
    //public bool[] powerup_bool_array;  //array of all powerup positions in the level

    //powerups gameobjects to be spawned :
    /*public GameObject coin_bag;
    public GameObject life;
    public GameObject shield;*/

    public GameObject[] powerup_spawn;
    


    void Start()
    {
        powerup_count = 0;

        for (int i = 0; i < powerup_transform_array.Length; i++)
        {
            //powerup_array[i].powerup_transform = powerup_transform_array[i];
            powerup_bool_list.Add(true);

        }

        StartCoroutine(powerup_timer());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator powerup_timer()
    {
        while (true)
        {

            yield return new WaitForSeconds(4);

            if (powerup_count <= max_powerup_count)
            {
                

                //
                int index = Random.Range(0, powerup_transform_array.Length);
                if (powerup_bool_list[index] == true)
                {
                    GameObject powerup_object = Instantiate(powerup_spawn[Random.Range(0, powerup_spawn.Length)], powerup_transform_array[index].position, Quaternion.Euler(-90,0,0)) as GameObject;
                    powerup_object.GetComponent<rotate_powerup_script>().index = index;
                    powerup_count++;
                    powerup_bool_list[index] = false;
                    //Debug.Log("done");
                }
                //
            }
            else
            {
                //Debug.Log("limit");
            }
        }


    }
}
