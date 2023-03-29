using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_stat_manager : MonoBehaviour
{
    public float cur_lvl_health, max_lvl_health;
    public float cur_mg_damage, max_mg_damage;
    public float cur_lazer_damage, max_lazer_damage;
    public float cur_proj_damage, max_proj_damage;
    public float cur_shield_time, max_shield_time;
    public float crystals;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetFloat("cur_lvl_health", cur_lvl_health);
        //PlayerPrefs.SetFloat("max_lvl_health", max_lvl_health);

        PlayerPrefs.SetFloat("cur_mg_damage", cur_mg_damage);
        //PlayerPrefs.SetFloat("max_mg_damage", max_mg_damage);

        PlayerPrefs.SetFloat("max_lazer_damage", max_lazer_damage);
        //PlayerPrefs.SetFloat("cur_lazer_damage", cur_lazer_damage);

        PlayerPrefs.SetFloat("max_proj_damage", max_proj_damage);
        //PlayerPrefs.SetFloat("cur_proj_damage", cur_proj_damage);

        PlayerPrefs.SetFloat("cur_shield_time", cur_shield_time);
        //PlayerPrefs.SetFloat("max_shield_time", max_shield_time);

        PlayerPrefs.SetFloat("crystals", crystals);

        PlayerPrefs.Save();


    }
}
