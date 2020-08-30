using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetPhysics : MonoBehaviour
{
    float mass;
    public Vector3 initialVelocity;
    Vector3 currentVelocity;
    public GameObject[] allBodies;
    
    // Start is called before the first frame update
    void Start()
    {
        mass = GetComponent<Rigidbody>().mass;
        currentVelocity = initialVelocity;
        gameObject.tag ="celestialBody";
        allBodies = GameObject.FindGameObjectsWithTag("celestialBody");
        print(this);
    }

    // Update is called once per frame
    public void FixedUpdate(){

        foreach(var body in allBodies){

            if(body != this){
                float distanceSqrd = Mathf.Round((body.GetComponent<Rigidbody>().position - GetComponent<Rigidbody>().position).sqrMagnitude);

                Vector3 forceDir = (body.GetComponent<Rigidbody>().position - GetComponent<Rigidbody>().position).normalized;

                Vector3 acceleration = (forceDir * universeController.gravConst * body.GetComponent<Rigidbody>().mass) / distanceSqrd;

                currentVelocity += acceleration * universeController.timeStep;
                print(forceDir);
                print(universeController.gravConst);
                print(body.GetComponent<Rigidbody>().mass);
                print(distanceSqrd);
                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + currentVelocity * universeController.timeStep);
                
            }
        }
    }
}
