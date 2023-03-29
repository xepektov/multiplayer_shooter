using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class machine_gun_bullet_script : MonoBehaviour
{
    // Start is called before the first frame update

    public int speed;
    //public GameObject player;
    //public Vector3 player_velocity;
    Rigidbody rb;
    Vector3 bullet_direction;
    public GameObject levelManager;
    public float damage = 10;
    public machine_gun_script machine_gun;



    //int boundary_x1 , boundary_x2 , boundary_y1 , boundary_y2;
    void Start()
    {
        
        //player_velocity = player.GetComponent<player_movement>().player_velocity;

        // boundary_x1 = 110;
        // boundary_x2 = -110;
        // boundary_y1 = 110;
        // boundary_y2 = -110;

        damage = levelManager.GetComponent<level_Manager_script>().damage_mgbullet;
        if (this.gameObject.name == "Capsule_player")
        {
            damage = levelManager.GetComponent<level_Manager_script>().damage_mgbullet_player;
        }

        rb = this.gameObject.GetComponent<Rigidbody>();

        bullet_direction = new Vector3(0, 1, 0);
        //rb.velocity = bullet_direction * speed;
        rb.AddRelativeForce(bullet_direction * speed);

    }

    // Update is called once per frame
    void Update()
    {
       // this.gameObject.transform.localPosition =   new Vector3(transform.localPosition.x,transform.localPosition.y + Time.deltaTime * speed,transform.localPosition.z);

       // transform.Translate( ( new Vector3(0,1,0) + (player_velocity/((speed * Time.deltaTime))  ) ) * Time.deltaTime * speed , Space.Self  );
        //transform.Translate( (bullet_direction) * Time.deltaTime * speed *3, Space.Self  );
        
        
        // if(transform.position.x>boundary_x1 || transform.position.x<boundary_x2){
        //     Destroy(this.gameObject);
        // }

        // if(transform.position.y>boundary_y1 || transform.position.y<boundary_y2){
        //     Destroy(this.gameObject);
        // }

        //rb.AddRelativeForce( new Vector3(0,20,0) , ForceMode.Acceleration );
    }

    void OnCollisionEnter(Collision hit){
        //if (hit.gameObject.CompareTag("enemy") || hit.gameObject.CompareTag("Player"))
        if (hit.gameObject.CompareTag("Player"))
        {
            Debug.Log("bullet hit player");
            hit.gameObject.GetComponent<IDamageable>()?.setDamage(damage);
        }

        //Destroy(this.gameObject);
        machine_gun.destory_bullet(this.gameObject);
    }
}
