using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyLazer_script : MonoBehaviour
{

    [SerializeField] LayerMask lazer_layer, lazer_layer1 , no_powerup_layer;
    [SerializeField] LineRenderer lazer_linerenderer;
    public GameObject levelManager;
    

    [SerializeField] GameObject target_gameobject;
    [SerializeField] GameObject lazer_holder;
    public float lazer_length;

    float damage_rate;

    //public GameObject dummy_hitpos;
    
    // Start is called before the first frame update
    void Start()
    {
        lazer_linerenderer.SetPosition(0, transform.position);
        lazer_linerenderer.SetPosition(1, transform.position + (Vector3.forward* lazer_length) );
        damage_rate = levelManager.GetComponent<level_Manager_script>().damage_rate_lazer;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo1, lazer_length,no_powerup_layer))
        {
            //lazer_linerenderer.SetPosition(1, hitinfo1.transform.position);
            lazer_linerenderer.SetPosition(0, transform.position);
            //lazer_linerenderer.SetPosition(1, transform.position + ( transform.TransformDirection(Vector3.forward) * (hitinfo1.transform.position - this.transform.position).magnitude));
            lazer_linerenderer.SetPosition(1, transform.position + (transform.TransformDirection(Vector3.forward) * hitinfo1.distance));
            //dummy_hitpos.transform.position = hitinfo1.transform.position;
            //Debug.Log(hitinfo1.transform.position);
            

            if (hitinfo1.collider.gameObject.CompareTag("obstacle"))
            {
                lazer_holder.GetComponent<lazer_rotate_script>().caught = false;
                
            }

            /*else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, hitinfo1.distance, lazer_layer1))
            {
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * lazer_length, Color.red);
                //lazer_linerenderer.SetPosition(1, hitinfo.transform.position);
                //lazer_linerenderer.SetPosition(1, transform.position + (Vector3.forward * lazer_length));
                //lazer_linerenderer.SetPosition(1, transform.position + (transform.TransformDirection(Vector3.forward) * (hitinfo.transform.position - this.transform.position).magnitude));
                //Debug.Log("hit");
                hitinfo.collider.gameObject.GetComponent<health_script>().setDamage(damage_rate * Time.deltaTime);
            }*/

            else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo2, hitinfo1.distance, lazer_layer))
            {
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * lazer_length, Color.red);
                //lazer_linerenderer.SetPosition(1, hitinfo.transform.position);
                //lazer_linerenderer.SetPosition(1, transform.position + (Vector3.forward * lazer_length));
                //lazer_linerenderer.SetPosition(1, transform.position + (transform.TransformDirection(Vector3.forward) * (hitinfo.transform.position - this.transform.position).magnitude));
                //Debug.Log("hit");
                hitinfo2.collider.gameObject.GetComponent<IDamageable>()?.setDamage(damage_rate*Time.deltaTime);

                if (hitinfo1.collider.gameObject.CompareTag("Player"))
                {
                    lazer_holder.GetComponent<lazer_rotate_script>().caught = true;
                }
                
            }

            else if (hitinfo1.collider.gameObject.CompareTag("enemy_ball"))
            {
                Destroy(hitinfo1.collider.gameObject);
            }

            /*else
            {
                lazer_holder.GetComponent<lazer_rotate_script>().caught = false;
            }*/

        }

        else
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * lazer_length, Color.green);
            //lazer_linerenderer.SetPosition(1, hitinfo.transform.position);
            //Debug.Log("nohit");
            lazer_linerenderer.SetPosition(0, transform.position);
            lazer_linerenderer.SetPosition(1, transform.position + (transform.TransformDirection(Vector3.forward) * lazer_length));
            //Debug.Log("nothing");
        }
    }
}
