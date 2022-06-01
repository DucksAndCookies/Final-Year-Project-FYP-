using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flame : MonoBehaviour
{
    public GameObject flame;
    public float max=1.5f;
    public float min=1;
    public float x = 0.1f;
    private bool dir = true;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        if (dir==false)
        {
            flame.transform.localScale += new Vector3(0, x, 0);
        }
        else
        {
            flame.transform.localScale -= new Vector3(0, x, 0);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
       

        if (flame.transform.localScale.y > max)
        {
            dir = true;
        }
        if (flame.transform.localScale.y < min)
        {
            dir = false;
        }

    }
}
