using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawCreator : MonoBehaviour
{
    public Rigidbody2D craw;
    public float speed;
    //public GameObject boss;
    
    // Start is called before the first frame update
    void Start()
    {
        //bool bos = boss.GetComponent<Boss>().AttackingF;
        Rigidbody2D po = Instantiate(craw, gameObject.transform.position, gameObject.transform.rotation);
        po.velocity = transform.right * speed;

    }
    public void FixedUpdate()
    {
        //bool bos = boss.GetComponent<Boss>().AttackingF;
        
        //Debug.Log(bos);
        //new Vector2(-endPoint.position.x, endPoint.position.y)*4;
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
