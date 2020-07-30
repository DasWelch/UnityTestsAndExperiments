using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Mover : MonoBehaviour
{

    public Vector3 acc;
    public Vector3 vel;
    public Vector3 pos;

    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    { 
    
    }

    void FixedUpdate() 
    {
        var move = Forward2d();
        rb.transform.position += move * Time.deltaTime; //gameObject.transform.forward * Time.deltaTime;
    }

    Vector3 Forward2d() 
    {
        Vector3 forward = new Vector3(0, 0, 0);

        float angRad = rb.transform.rotation.z;
        //Debug.Log(angRad.ToString());
        forward.x = Mathf.Cos(angRad);
        forward.y = Mathf.Sin(angRad);
        Debug.Log(forward.ToString());
        return forward;
    }

    float DegToRad(float angDeg) {
        return angDeg * Mathf.PI / 180f;
    }

}
