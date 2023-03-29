using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class player_movement : MonoBehaviour
{

    public Rigidbody myrigidbody;
    public float xvelocity,zvelocity,speed;
    public Vector3 player_velocity;

    public float force_value;
    float force_multiplier_a ,force_multiplier_w,force_multiplier_s,force_multiplier_d;
    public float braking_force_multiplier,default_force_multiplier;

    PhotonView PV;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }


    // Start is called before the first frame update
    void Start()
    {

        
        //this.transform.position = new Vector3(0,1f,1f);
        
        myrigidbody = this.gameObject.GetComponent<Rigidbody>();
        xvelocity = myrigidbody.velocity.x;
        zvelocity = myrigidbody.velocity.z;
        speed = Mathf.Sqrt(Mathf.Pow(xvelocity,2) + Mathf.Pow(zvelocity,2));
        default_force_multiplier=1f;
        braking_force_multiplier=2f;

        //force_value =15;
        myrigidbody.velocity = new Vector3(0f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        player_velocity = myrigidbody.velocity;
    }

    void FixedUpdate(){

        if (!PV.IsMine)
        {
            return;
        }

        if(Input.GetKey(KeyCode.A)){
            if( Vector3.Dot( new Vector3(1,0,0) , myrigidbody.velocity) <0 ){
                force_multiplier_a = braking_force_multiplier;
            }
            else{
                force_multiplier_a=default_force_multiplier;
            }
            myrigidbody.AddForce( force_value*force_multiplier_a , 0 , 0);
        }

        else if(Input.GetKey(KeyCode.D)){
            if( Vector3.Dot( new Vector3(-1,0,0) , myrigidbody.velocity) <0 ){
                force_multiplier_d = braking_force_multiplier;
            }
            else{
                force_multiplier_d=default_force_multiplier;
            }
            myrigidbody.AddForce(-1 * force_value *force_multiplier_d, 0 , 0);
        }

        if(Input.GetKey(KeyCode.W)){
            if( Vector3.Dot( new Vector3(0,1,0) , myrigidbody.velocity) <0 ){
                force_multiplier_w = braking_force_multiplier;
            }
            else{
                force_multiplier_w=default_force_multiplier;
            }
            myrigidbody.AddForce( 0,0, -1 * force_value * force_multiplier_w);
        }

        else if(Input.GetKey(KeyCode.S)){
            if( Vector3.Dot( new Vector3(0,-1,0) , myrigidbody.velocity) <0 ){
                force_multiplier_s = braking_force_multiplier;
            }
            else{
                force_multiplier_s=default_force_multiplier;
            }
            myrigidbody.AddForce( 0,0, 1 * force_value * force_multiplier_s);
        }

        

    }
}
