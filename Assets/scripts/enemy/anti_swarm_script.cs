using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anti_swarm_script : MonoBehaviour
{
    Rigidbody rb;
    public float overlap_sphere_radius;
    public LayerMask swarm_layer;
    public float force_parameter;
    Vector3 total_force;
    int frame;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        total_force = Vector3.zero;
        frame = 0;
    }

    // Update is called once per frame
    void Update()
    {
        frame++;

        if (frame > 0)
        {
            frame = 0;
        }

        if (frame % 3 == 0)
        {
            move_aside();
        }
    }

    void move_aside()
    {
        Collider[] swarm_colliders = Physics.OverlapSphere(transform.position, overlap_sphere_radius, swarm_layer);

        Vector3 force_dir;

        foreach (var collider in swarm_colliders)
        {
            force_dir = -(collider.gameObject.transform.position - transform.position);

            total_force += force_dir;
        }

        total_force = total_force.normalized;
        total_force = new Vector3(total_force.x, 0, total_force.z);

        rb.AddForce(total_force * force_parameter);
    }
}
