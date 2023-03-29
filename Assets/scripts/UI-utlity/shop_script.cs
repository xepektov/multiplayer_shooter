using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class shop_script : MonoBehaviour
{
    public TMP_Text crystal;

    public TMP_Text mg_dmg;
    public TMP_Text grenade_dmg;
    public TMP_Text lazer_dmg;
    public TMP_Text shield_time;
    public TMP_Text health;

    public Button mg_button;
    public Button grenade_button;
    public Button lazer_button;
    public Button shield_button;
    public Button health_button;

    public int mg_cost;
    public int grenade_cost;
    public int lazer_cost;
    public int shield_cost;
    public int health_cost;

    int temp;
    public int crystal_no;
    // Start is called before the first frame update
    void Awake()
    {
        PlayerPrefs.SetFloat("cur_mg_damage", 10);
        PlayerPrefs.SetFloat("cur_proj_damage", 50);
        PlayerPrefs.SetFloat("cur_lazer_damage", 20);
        PlayerPrefs.SetFloat("cur_shield_time", 30);
        PlayerPrefs.SetFloat("cur_lvl_health", 150);

        PlayerPrefs.SetInt("crystals",28);


        health.text = ((int)PlayerPrefs.GetFloat("cur_lvl_health")).ToString() + " / 300";
        //PlayerPrefs.SetFloat("max_lvl_health", max_lvl_health);

        mg_dmg.text = ((int)PlayerPrefs.GetFloat("cur_mg_damage")).ToString() + " / 20";
        //PlayerPrefs.SetFloat("max_mg_damage", max_mg_damage);

        lazer_dmg.text = ((int)PlayerPrefs.GetFloat("cur_lazer_damage")).ToString() + " / 40";
        //PlayerPrefs.SetFloat("cur_lazer_damage", cur_lazer_damage);

        grenade_dmg.text = ((int)PlayerPrefs.GetFloat("cur_proj_damage")).ToString() + " / 100";
        //PlayerPrefs.SetFloat("cur_proj_damage", cur_proj_damage);

        shield_time.text = ((int)PlayerPrefs.GetFloat("cur_shield_time")).ToString() + " / 60";
        //PlayerPrefs.SetFloat("max_shield_time", max_shield_time);

        crystal.text = ((int)PlayerPrefs.GetInt("crystals")).ToString();

        crystal_no = ((int)PlayerPrefs.GetInt("crystals"));

        
    }

    // Update is called once per frame
    void Update()
    {
        //crystal_no = ((int)PlayerPrefs.GetInt("crystals"));
    }

    public void mg_button_clicked()
    {
        temp = (int)PlayerPrefs.GetFloat("cur_mg_damage");

        if (crystal_no > mg_cost)
        {
            PlayerPrefs.SetFloat("cur_mg_damage", temp + 1);
            mg_dmg.text = ((int)PlayerPrefs.GetFloat("cur_mg_damage")).ToString() + " / 20";

            crystal_no = crystal_no - mg_cost;
            PlayerPrefs.SetInt("crystals", crystal_no);
            crystal.text = (PlayerPrefs.GetInt("crystals")).ToString();

            PlayerPrefs.Save();
        }

        
    }

    public void grenade_button_clicked()
    {
        temp = (int)PlayerPrefs.GetFloat("cur_proj_damage");

        if (crystal_no > grenade_cost)
        {
            PlayerPrefs.SetFloat("cur_proj_damage", temp + 5);
            grenade_dmg.text = ((int)PlayerPrefs.GetFloat("cur_proj_damage")).ToString() + " / 100";

            crystal_no = crystal_no - grenade_cost;
            PlayerPrefs.SetInt("crystals", crystal_no );
            crystal.text = (PlayerPrefs.GetInt("crystals")).ToString();

            PlayerPrefs.Save();
        }

    }

    public void lazer_button_clicked()
    {
        temp = (int)PlayerPrefs.GetFloat("cur_lazer_damage");

        if (crystal_no > lazer_cost)
        {
            PlayerPrefs.SetFloat("cur_lazer_damage", temp + 2);
            lazer_dmg.text = ((int)PlayerPrefs.GetFloat("cur_lazer_damage")).ToString() + " / 40";

            crystal_no = crystal_no - lazer_cost;
            PlayerPrefs.SetInt("crystals", crystal_no);
            crystal.text = (PlayerPrefs.GetInt("crystals")).ToString();

            PlayerPrefs.Save();
        }

    }

    public void shield_button_clicked()
    {
        temp = (int)PlayerPrefs.GetFloat("cur_shield_time");

        if (crystal_no > shield_cost)
        {
            PlayerPrefs.SetFloat("cur_shield_time", temp + 3);
            shield_time.text = ((int)PlayerPrefs.GetFloat("cur_shield_time")).ToString() + " / 60";

            crystal_no = crystal_no - shield_cost;
            PlayerPrefs.SetInt("crystals", crystal_no);
            crystal.text = (PlayerPrefs.GetInt("crystals")).ToString();

            PlayerPrefs.Save();
        }

    }

    public void health_button_clicked()
    {
        temp = (int)PlayerPrefs.GetFloat("cur_lvl_health");

        if (crystal_no > health_cost)
        {
            PlayerPrefs.SetFloat("cur_lvl_health", temp + 15);
            health.text = ((int)PlayerPrefs.GetFloat("cur_lvl_health")).ToString() + " / 300";

            crystal_no = crystal_no - health_cost;
            PlayerPrefs.SetInt("crystals", crystal_no);
            crystal.text = (PlayerPrefs.GetInt("crystals")).ToString();

            PlayerPrefs.Save();
        }

    }
}
