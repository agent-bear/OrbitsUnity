using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class planetPhysics : MonoBehaviour{

    public Vector3 initialVelocity;
    public Vector3 planetRotation;
    public Rigidbody rb;
    const float constant = 0.02f;

    public static List<planetPhysics> physicsBodies;

    void OnEnable(){
        if( physicsBodies == null){
            physicsBodies = new List<planetPhysics>();
        }

        physicsBodies.Add(this);
        rb.constraints = RigidbodyConstraints.FreezeRotation;

    }

    void OnDisable(){
        physicsBodies.Remove(this);
    }

    void Start(){
        rb.AddForce(initialVelocity, ForceMode.VelocityChange);
        rb.AddTorque(planetRotation, ForceMode.VelocityChange);
    }

    void FixedUpdate(){
        foreach(planetPhysics body in physicsBodies ){
            if(body != this){
                simulateGravity(body);
                //print(body);
            }
            
        }
    }

    void simulateGravity(planetPhysics body){
        Vector3 difference = body.rb.position - rb.position;
        Vector3 direction = difference.normalized;
        float distance = difference.sqrMagnitude;
        float attractionStr = constant * (rb.mass * body.rb.mass) / distance;

        Vector3 attraction = direction * attractionStr;

        rb.AddForce(attraction);
    }
}

