using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UIElements;

public class Mover : MonoBehaviour
{

    public float maxVel;
    public float maxAcc;

    public float accMult;

    public Vector2 acc;
    public Vector2 vel;
    //public Vector2 pos;

    public float MoverAng;
    public float avel;
    public float aacc;

    public float rotOffset;

    public Boundary board;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        MoverAng = rb.rotation + rotOffset;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void FixedUpdate() 
    {

        updateMover();
        stopBoundary();

        //motion updates
        updateAcceleration();
        updateVelocity();
        updatePosition();

        //rotation updates

        updateComponents();
    }
    
    void updatePosition() {
        
        rb.position += vel * Time.deltaTime;
    }

    void updateAcceleration() {
        acc += forward2D() * Time.deltaTime;

        acc *= accMult;

        if (acc.magnitude > maxAcc) {
            acc = acc.normalized * maxAcc;
        }
    }

    void updateVelocity() {
        vel += acc * Time.deltaTime;
        if (vel.magnitude > maxVel) {
            vel.Normalize();
            vel *= maxVel;
        }
        acc *= 0;
    }
    void updateMover() { 
        MoverAng = rb.rotation + rotOffset;
    }
    
    void updateComponents() {
        rb.rotation = MoverAng - rotOffset;
    }

    Vector2 forward2D() 
    {
        Vector2 forward = new Vector2(0, 0);

        float angRad = DegToRad(MoverAng);
        //Debug.Log(angRad.ToString());
        forward.x = Mathf.Cos(angRad);
        forward.y = Mathf.Sin(angRad);
        return forward.normalized;
    }

    float DegToRad(float angDeg) {
        return angDeg * Mathf.PI / 180f;
    }

    void rotate(float deltaAng) {
        MoverAng += deltaAng * Time.deltaTime;
    }

    void stopBoundary() {
        if (rb.position.x <= board.corners[0])
        {
            stopMotion();
        }
        else if (rb.position.x >= board.corners[1]) {
            stopMotion();
        }
        if (rb.position.y >= board.corners[2]) {
            stopMotion();
        }
        else if (rb.position.y <= board.corners[3]) {
            stopMotion();
        }
    }
    void stopMotion() {
        vel *= 0;
        acc *= 0;
    }
    

}

