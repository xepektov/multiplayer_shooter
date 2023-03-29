using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class player_rotation_fixer_script : MonoBehaviour


{

    public Rigidbody myrigidbody;
    public Camera mainCamera;
    //public LayerMask layerMask;

    PhotonView PV;

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!PV.IsMine)
        {
            mainCamera.gameObject.SetActive(false);
        }

        myrigidbody = this.gameObject.GetComponent<Rigidbody>();

        // myrigidbody.centerOfMass = Vector3.zero;
        // myrigidbody.inertiaTensorRotation = Quaternion.identity;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate(){

        if (!PV.IsMine)
        {
            return;
        }

        // Vector3 difference = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.transform.position.z * -1));
        //    difference.Normalize();
        //     float rotation_z = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        //    Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        //     transform.rotation = Quaternion.Euler(0f,0f , rotation_z );

        Ray mouse_ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(mouse_ray , out RaycastHit raycastHit , float.MaxValue)) {
            Vector3 difference = raycastHit.point - transform.position;
            difference.Normalize();
            float rotation_y = Mathf.Atan2(difference.z, difference.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(-90f, -(rotation_y+90), 0f);
        }
    
    }
}
