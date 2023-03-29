using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class player_stats_manager_script : MonoBehaviour
{
    public float cur_lvl_health, max_lvl_health;
    public float cur_mg_damage, max_mg_damage;
    public float cur_lazer_damage, max_lazer_damage;
    public float cur_proj_damage, max_proj_damage;
    public float cur_shield_time, max_shield_time;
    public int crystals;

    //public TMP_Text crystal_no;


    // Start is called before the first frame update
    void Awake()
    {
        /*PlayerPrefs.SetFloat("cur_lvl_health", cur_lvl_health);
        //PlayerPrefs.SetFloat("max_lvl_health", max_lvl_health);

        PlayerPrefs.SetFloat("cur_mg_damage", cur_mg_damage);
        //PlayerPrefs.SetFloat("max_mg_damage", max_mg_damage);

        PlayerPrefs.SetFloat("max_lazer_damage", max_lazer_damage);
        //PlayerPrefs.SetFloat("cur_lazer_damage", cur_lazer_damage);

        PlayerPrefs.SetFloat("max_proj_damage", max_proj_damage);
        //PlayerPrefs.SetFloat("cur_proj_damage", cur_proj_damage);

        PlayerPrefs.SetFloat("cur_shield_time", cur_shield_time);
        //PlayerPrefs.SetFloat("max_shield_time", max_shield_time);

        PlayerPrefs.SetInt("crystals", crystals);

        PlayerPrefs.Save();*/

        cur_lvl_health=PlayerPrefs.GetFloat("cur_lvl_health");
        //PlayerPrefs.SetFloat("max_lvl_health", max_lvl_health);

        cur_mg_damage=PlayerPrefs.GetFloat("cur_mg_damage");
        //PlayerPrefs.SetFloat("max_mg_damage", max_mg_damage);

        cur_lazer_damage=PlayerPrefs.GetFloat("cur_lazer_damage");
        //PlayerPrefs.SetFloat("cur_lazer_damage", cur_lazer_damage);

        cur_proj_damage=PlayerPrefs.GetFloat("cur_proj_damage");
        //PlayerPrefs.SetFloat("cur_proj_damage", cur_proj_damage);

        cur_shield_time=PlayerPrefs.GetFloat("cur_shield_time");
        //PlayerPrefs.SetFloat("max_shield_time", max_shield_time);

        crystals=PlayerPrefs.GetInt("crystals");
    }

    private void Start()
    {
        //crystal_no.text = crystals.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        


    }

    public void add_Crystals(int add)
    {
        crystals = crystals + add;
        Debug.Log(crystals);
        //crystal_no.text = crystals.ToString();

        PlayerPrefs.SetInt("crystals", crystals);

        PlayerPrefs.Save();
    }
}
