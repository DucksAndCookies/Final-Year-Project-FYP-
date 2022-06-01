using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutorialscript : MonoBehaviour
{
    public GameObject x;
    public float z;
    public bool dir;
    public GameObject valE;
    public int val;
    // Start is called before the first frame update
    void Start()
    {
       
    }
   
    private void FixedUpdate()
    {
        if (dir==true)
        {
            x.transform.position = new Vector2(valE.transform.position.x, x.transform.position.y + z);
        }
        else
        {
            x.transform.position = new Vector2(valE.transform.position.x, x.transform.position.y - z);
        }
        
        
        
    }
    // Update is called once per frame
    void Update()
    {
        //Debug.Log(valE.transform.position.y - x.transform.position.y);
        if (x.transform.position.y-valE.transform.position.y  < 6)
        {
            dir = true;
        }
        if(x.transform.position.y - valE.transform.position.y > 7)
        {
            dir = false;
        }
    }
}
