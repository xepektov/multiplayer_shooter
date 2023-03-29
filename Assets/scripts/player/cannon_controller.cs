using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class cannon_controller : MonoBehaviour
{
    //CannonController cannonController;
    public LineRenderer lineRenderer;
    public Transform ShotPoint;
    public GameObject Cannonball;

    public float BlastPower = 5;

    // Number of points on the line
    public int numPoints = 50;

    // distance between those points on the line
    public float timeBetweenPoints = 0.1f;

    // The physics layers that will cause the line to stop being drawn
    public LayerMask CollidableLayers;

    //public FixedJoystick moveJoystick;
    //public FixedJoystick rotateJoystick;
    float resultant;

    //bool hold;

    public float cooldown_bar;
    float cooldown_max;
    float cooldown_rate;
    float overheat_rate;

    bool cooldown_enabled;
    void Start()
    {
       // cannonController = GetComponent<CannonController>();
        lineRenderer = GetComponent<LineRenderer>();

        cooldown_max = 50;
        cooldown_bar = cooldown_max;
        cooldown_rate = 0.3f;
        overheat_rate = 10;
        cooldown_enabled = false;
    }


    void Update()
    {
        if ((cooldown_bar < cooldown_max) && (!cooldown_enabled))
        {
            StartCoroutine(cooldown());
            cooldown_enabled = true;
        }

        if (Input.GetKey(KeyCode.Mouse1) && (cooldown_bar > overheat_rate))
        {
            lineRenderer.positionCount = numPoints;

            List<Vector3> points = new List<Vector3>();

            Vector3 startingPosition = ShotPoint.position;
            Vector3 startingVelocity = ShotPoint.up * BlastPower;


            for (float t = 0; t < numPoints; t += timeBetweenPoints)
            {
            
              Vector3 newPoint = startingPosition + t * startingVelocity;
              newPoint.y = startingPosition.y + startingVelocity.y * t + Physics.gravity.y/2f * t * t;
              points.Add(newPoint);

              if(Physics.OverlapSphere(newPoint, 1, CollidableLayers).Length > 2)
                {
                    lineRenderer.positionCount = points.Count;
                    break;
                }
            }

            lineRenderer.SetPositions(points.ToArray());


            // if (Input.GetKeyUp(KeyCode.Mouse1)){
            //     GameObject CreatedCannonball = Instantiate(Cannonball, ShotPoint.position, ShotPoint.rotation);
            //     CreatedCannonball.GetComponent<Rigidbody>().velocity = ShotPoint.transform.up * BlastPower;
            // }

        }

        else if (Input.GetKeyUp(KeyCode.Mouse1) && (cooldown_bar > overheat_rate))
        {
            GameObject CreatedCannonball = Instantiate(Cannonball, ShotPoint.position, ShotPoint.rotation);
            CreatedCannonball.GetComponent<Rigidbody>().velocity = ShotPoint.transform.up * BlastPower;
            lineRenderer.positionCount=0;

            cooldown_bar = cooldown_bar - overheat_rate;
        }
        
        
    }

    IEnumerator cooldown()
    {
        while (cooldown_bar < cooldown_max)
        {
            cooldown_bar++;
            //Debug.Log(cooldown_bar);

            yield return new WaitForSeconds(cooldown_rate);


            /*if (cooldown_bar >= cooldown_max)
            {
             break;
            }*/
        }
        cooldown_enabled = false;

    }
}