using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform followTransform;
    public float maxx;
    public float minx;
    public float maxy;
    public float miny;


    // Update is called once per frame
    void FixedUpdate()
    {
        if (followTransform.position.x > minx && followTransform.position.x < maxx)
        {
            this.transform.position = new Vector3(followTransform.position.x, this.transform.position.y, this.transform.position.z);
            //this.transform.position = Vector2.MoveTowards(transform.position, followTransform.position, 1);

        }
        if (followTransform.position.y > miny && followTransform.position.y < maxy)
        {
            //this.transform.position = Vector2.MoveTowards(transform.position, followTransform.position, 1);
            this.transform.position = new Vector3(this.transform.position.x, followTransform.position.y, this.transform.position.z);
        }
            
        
    }
}