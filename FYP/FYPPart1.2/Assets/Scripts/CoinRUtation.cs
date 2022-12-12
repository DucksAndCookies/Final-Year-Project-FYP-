using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRUtation : MonoBehaviour
{
    public GameObject thisOBJ;
    public bool direction;
    public float speed= 0.05f;
    public Vector3 scalx;
    // Start is called before the first frame update
    void Start()
    {
        scalx = new Vector3(speed, 0,0);
    }
    private void FixedUpdate()
    {
        

        
        if ((thisOBJ.transform.localScale.x < 0.01 && speed<0) || (thisOBJ.transform.localScale.x > 1 && speed > 0))
        {
            speed = -1 * speed;
        }
        thisOBJ.transform.localScale += scalx;
        scalx = new Vector3(speed, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("this is coin");
            Destroy(thisOBJ);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
