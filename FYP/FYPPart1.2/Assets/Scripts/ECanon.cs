using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ECanon : MonoBehaviour
{
    public GameObject SBullet;
    public Transform startingPoint;
    public Transform endPoint;
    public Rigidbody2D projectile;
    public float RateOfFire;
    public float speed;
    
   
   
    // Start is called before the first frame update
    void Start()
    {

        if (startingPoint.position.x - endPoint.position.x > 0)
        {

                Instantiate(SBullet, startingPoint.position, startingPoint.rotation);
                Rigidbody2D po = Instantiate(projectile, startingPoint.position, startingPoint.rotation);
                po.velocity = transform.right * speed;//new Vector2(-endPoint.position.x, endPoint.position.y)*4;
                projectile = po;
            

        }
        else
        {

                Instantiate(SBullet, startingPoint.position, startingPoint.rotation);
                Rigidbody2D po = Instantiate(projectile, startingPoint.position, startingPoint.rotation);
                po.velocity = transform.right * speed * -1;//new Vector2(-endPoint.position.x, endPoint.position.y)*4;
                projectile = po;
            
        }


    }

    // Update is called once per frame
    
    void FixedUpdate()
    {



        if (startingPoint.position.x - endPoint.position.x > 0)
        {
            if (startingPoint.position.x - projectile.transform.position.x > RateOfFire)
            {
                Instantiate(SBullet, startingPoint.position, startingPoint.rotation);
                Rigidbody2D po = Instantiate(projectile, startingPoint.position, startingPoint.rotation);
                po.velocity = transform.right * speed;//new Vector2(-endPoint.position.x, endPoint.position.y)*4;
                projectile = po;
            }

        }
        else
        {
            if (startingPoint.position.x - projectile.transform.position.x < RateOfFire)
            {
                Instantiate(SBullet, startingPoint.position, startingPoint.rotation);
                Rigidbody2D po = Instantiate(projectile, startingPoint.position, startingPoint.rotation);
                po.velocity = transform.right * speed*-1;//new Vector2(-endPoint.position.x, endPoint.position.y)*4;
                projectile = po;
            }
        }
        
        
        //transform.forward * speed;
      
    }
    void Update()
    {
        
    }
}
