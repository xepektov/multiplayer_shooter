using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball_spawner_health_script : MonoBehaviour
{
    //float hitpoints = 300;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.CompareTag("projectile"))
        {
            
        }
    }
}
