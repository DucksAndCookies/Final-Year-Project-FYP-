using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject BulletTop;
    public GameObject bEnd;
    public Rigidbody2D bullet;
    //public int Direction=1;
    public float speed=5f;
    public GameObject endPoint;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
        if (collision.CompareTag("BulletEnd"))
        {
            Instantiate(bEnd, BulletTop.transform.position, BulletTop.transform.rotation);
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {

        //bullet.velocity = new Vector2(speed, bullet.velocity.y);
       
        
    }

    void Update()
    {
        
    }
}
