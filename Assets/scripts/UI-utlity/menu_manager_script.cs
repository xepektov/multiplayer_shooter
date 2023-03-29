using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_manager_script : MonoBehaviour
{
    public static menu_manager_script Instance;

    [SerializeField] menu_script[] menus;

    private void Awake()
    {
        Instance = this;
        OpenMenu("title");
    }

    public void OpenMenu(string menuName)
    {
        for(int i = 0; i < menus.Length; i++)
        {
            if(menus[i].menu_name == menuName)
            {
                Debug.Log("open " + menuName);
                menus[i].Open();
            }

            else //if (menus[i].open)
            {
                Debug.Log("close " + menuName);
                CloseMenu(menus[i]);
            }
        }
    }

    public void OpenMenu(menu_script menu)
    {
        menu.Open();
    }

    public void CloseMenu(menu_script menu)
    {
        menu.Close();
    }
}
