using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Transform toRotate;
    public float amount = 0.1f;
    private float ang;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        toRotate.eulerAngles = new Vector3(0, 0, ang);
        ang += amount;

    }
    // Update is called once per frame
    void Update()
    {
        if (ang >= 360)
        {
            ang = 0;
        }
    }
}
