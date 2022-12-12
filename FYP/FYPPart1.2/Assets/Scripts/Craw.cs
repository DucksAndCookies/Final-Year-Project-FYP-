using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Craw : MonoBehaviour
{
    public GameObject startingPoint;
    public GameObject self;
    public float distanceTravel;
    public bool freze;
    public LayerMask what_is_freezing;
    public float freze_meter;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }
    
    
    private void FixedUpdate()
    {
        freze = Physics2D.OverlapCircle(self.transform.position, 0.2f, what_is_freezing);
        if (freze == true && freze_meter<6)
         {
            freze_meter += 1f;
         }
        if (freze_meter >= 5)
        {
            self.GetComponent<SpriteRenderer>().color = new Color(0.2122642f, 0.327697f, 1, 0.9f);
            self.GetComponent<SpriteRenderer>().flipY = true;
            self.GetComponent<Rigidbody2D>().velocity = transform.right * 0;
            self.GetComponent<Rigidbody2D>().gravityScale += 0.2f;
        }
        
        if ((self.transform.position.x - startingPoint.transform.position.x < distanceTravel) || (self.transform.position.y<-15))
        {
            Destroy(self);
        }
        //Debug.Log(freze_meter);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
