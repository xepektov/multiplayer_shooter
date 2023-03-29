using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class shooter_manager_script : MonoBehaviour
{

    //public TextMeshProUGUI button;
    string[] weapons = { "machine_gun", "projectile" ,"lazer"};
    int current_weapon;
    public GameObject shooter;

    // Start is called before the first frame update
    void Start()
    {
        current_weapon = 0;
        shooter.GetComponent<joystick_machine_gun_script>().enabled = true;
        shooter.GetComponent<joy_stick_cannon_controller>().enabled = false;
        shooter.GetComponentInChildren<player_lazer_script>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void weapon_switch_button_clicked()
    {
        if (current_weapon == 0)
        {
            current_weapon = 1;
            shooter.GetComponent<joystick_machine_gun_script>().enabled = false;
            shooter.GetComponent<joy_stick_cannon_controller>().enabled = true;
            shooter.GetComponentInChildren<player_lazer_script>().enabled = false;
        }

        else if (current_weapon == 1)
        {
            current_weapon = 2;
            shooter.GetComponent<joystick_machine_gun_script>().enabled = false;
            shooter.GetComponent<joy_stick_cannon_controller>().enabled = false;
            shooter.GetComponentInChildren<player_lazer_script>().enabled = true;
        }

        else if (current_weapon == 2)
        {
            current_weapon = 0;
            shooter.GetComponent<joystick_machine_gun_script>().enabled = true;
            shooter.GetComponent<joy_stick_cannon_controller>().enabled = false;
            shooter.GetComponentInChildren<player_lazer_script>().enabled = false;
        }

    }

    public void mega_weapon_button_clicked()
    {
        shooter.GetComponent<mega_weapon_script>().blue_ball();
    }
}
