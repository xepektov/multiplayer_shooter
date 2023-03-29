using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_script : MonoBehaviour
{
    public string menu_name;
    public bool open;

    public void Open()
    {
        gameObject.SetActive(true);
        open = true;
    }

    public void Close()
    {
        open = false;
        gameObject.SetActive(false);
    }
}
