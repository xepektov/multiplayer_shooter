using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class granade_exp_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(vanish());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator vanish()
    {
        yield return new WaitForSeconds(1.7f);
        Destroy(this.gameObject);
    }
}
