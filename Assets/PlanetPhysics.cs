using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetPhysics : MonoBehaviour
{
    public Vector3 initialVelocity;
    Vector3 currentVelocity;
    float mass;
    Rigidbody rb;
    Rigidbody rb2;
    public GameObject[] allBodies;
    
    // Start is called before the first frame update
    void Start(){

        rb = GetComponent<Rigidbody> ();
        mass = rb.mass;
        currentVelocity = initialVelocity;
        gameObject.tag = "celestialBody";
        allBodies = GameObject.FindGameObjectsWithTag("celestialBody");
        
        print(rb);
    }


    // Update is called once per frame
    public void FixedUpdate(){
        
        foreach(var body in allBodies){

            if(body != this){
                rb2 = body.GetComponent<Rigidbody> ();

                float distanceSqrd = (rb2.position - rb.position).sqrMagnitude;

                Vector3 forceDir = (rb2.position - rb.position).normalized;

                Vector3 acceleration = (forceDir * universeController.gravConst * rb2.mass) / distanceSqrd;

                currentVelocity += acceleration;

                print("forcedir "+forceDir);
                print("gravConst "+universeController.gravConst);
                print("rb2.mass "+rb2.mass);
                print("distanceSqrd "+distanceSqrd);
                print("currentvelocity "+currentVelocity);
                rb.MovePosition(currentVelocity);
                
            }
        }
    }
}
