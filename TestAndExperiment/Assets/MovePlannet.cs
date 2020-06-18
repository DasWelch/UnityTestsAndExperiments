using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class MovePlannet : MonoBehaviour
{
    public Rigidbody2D rb;
    public float orbitDistance;
    public float rpm;
    public float rotationRateDeg;

    private float angRad;
    
    

    void Start()
    {
        angRad = 0;
        SetPosition();
    }

    void FixedUpdate()
    {
        // rpm - 6f is the degrees to travel in a minute
        // Time.deltaTime adjusts for updates and movement persecond
        float degreeChange = (rpm * 6f * Time.deltaTime);// rpm in degreee accounting for deltatime 
        float radChange = degreeChange * (math.PI / 180);


        angRad += radChange;

        SetPosition();
    }

    void SetPosition() {

        float xpos = orbitDistance * math.cos(angRad);
        float ypos = orbitDistance * math.sin(angRad);

        rb.rotation += rotationRateDeg * Time.deltaTime;
        rb.position = new Vector2(xpos,ypos);
    }
}
