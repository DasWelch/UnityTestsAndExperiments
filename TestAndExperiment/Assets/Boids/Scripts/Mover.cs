using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    public Vector3 acc;
    public Vector3 vel;
    public Vector3 pos;
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
        gameObject.transform.position += move * Time.deltaTime;//gameObject.transform.forward * Time.deltaTime;
    }

    Vector3 Forward2d() 
    {
        Vector3 forward = new Vector3(0, 0, 0);

        float ang = gameObject.transform.position.z;
        forward.x = Mathf.Cos(ang);
        forward.y = Mathf.Sin(ang);

        return forward;
    }

}
