using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenade_script : MonoBehaviour
{

    public GameObject levelManager;
    float damage;
    public float blast_radius;
    public float force_parameter;
    public LayerMask player_enemy_layer;

    public bool is_player_granade;

    public GameObject granade_explosion;
    


    // Start is called before the first frame update
    void Start()
    {
        damage = levelManager.GetComponent<level_Manager_script>().damage_grenade;

        if (this.gameObject.name == "shell")
        {
            damage = levelManager.GetComponent<level_Manager_script>().damage_mortar;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision hit)
    {
        /*if (hit.gameObject.CompareTag("enemy"))
        {
            hit.gameObject.GetComponent<health_script>().setDamage(damage);
            Destroy(this.gameObject);
        }
        if (hit.gameObject.CompareTag("Player"))
        {
            hit.gameObject.GetComponent<health_script>().setDamage(damage);
            Destroy(this.gameObject);
        }
        else if (hit.gameObject.CompareTag("obstacle"))
        {
            Destroy(this.gameObject);
        }*/

        if (!hit.gameObject.CompareTag("shield"))
        {
            Collider[] blast_objects = Physics.OverlapSphere(transform.position, blast_radius, player_enemy_layer);

            Vector3 force_dir;

            foreach (var collider in blast_objects)
            {
                force_dir = (collider.gameObject.transform.position - transform.position);
                force_dir = force_dir.normalized;

                collider.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(force_dir.x, 0, force_dir.z) * force_parameter, ForceMode.Impulse);

                collider.gameObject.GetComponent<health_script>().setDamage(damage);
            }

            if (!(is_player_granade && hit.gameObject.CompareTag("Player")))
            {
                Instantiate(granade_explosion, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }

        
    }
}
