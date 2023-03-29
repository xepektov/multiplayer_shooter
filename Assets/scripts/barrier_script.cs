using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barrier_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision hit){
        
        if(hit.gameObject.tag == "projectile"){
            //Debug.Log("hit");
            Destroy(hit.gameObject);
            //Destroy(this.gameObject);
        }
    }
}
