using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lazer_turnoff_script : MonoBehaviour
{
    public GameObject spawner;
    string Name;
    // Start is called before the first frame update
    void Start()
    {
        Name = spawner.name;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find(Name))
        {
            this.gameObject.SetActive(false);
        }
    }

    /*private void OnDestroy()
    {
        
    }*/
}
