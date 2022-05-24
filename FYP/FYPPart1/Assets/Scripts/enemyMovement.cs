using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public LayerMask what_is_Ground;
    public LayerMask what_is_enemy;
    public GameObject define_enemy;
    public GameObject define_Player;
    public float movmentSpeed;
    public float freezeCount;
    public float kickValocity;
    private Rigidbody2D rb2d;
    public Transform what_is_checkerL;
    public Transform what_is_checkerR;
    public Transform Nitrogen;
    public ParticleSystem DeathCall;




    private bool directionCheckL;
    private bool directionCheckR;
    private bool death=false;
    private bool freeze;
    private bool push=false;
    private int TrueDirectionIs=1;
    private SpriteRenderer Sprite;
    
    // Start is called before the first frame update
    private void Awake()
    {
        rb2d = transform.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
        //freeze=Nitrogen.GetComponent<ParticleCollisionEvent>

    }

    // Update is called once per frame
    public void kickB()
    {

        if (freeze == true && push==false)
        {
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionY;
            push = true;
            if (define_Player.GetComponent<SpriteRenderer>().flipX == true )//&& Physics2D.OverlapCircle(define_enemy.GetComponent<Transform>().position, 0.1f, what_is_Ground) == true)
            {
                TrueDirectionIs = 1;
                //rb2d.velocity = Vector2.left * kickValocity;
            }
            else
            {
                TrueDirectionIs = -1;
                //rb2d.velocity = Vector2.right * kickValocity;
            }
            rb2d.velocity = Vector2.left * kickValocity * TrueDirectionIs;
            

        }
        Debug.Log("kick was called");
    }
    
    void OnParticleCollision(GameObject other)
    {
        freezeCount -= 1.0f;
        if (freezeCount <= 0)
        {
            freezeCount = 0;
            freeze = true;
        }
        
        Debug.Log("Partical got hit!!!!");
    }
    private void FixedUpdate()
    {
        if (freezeCount < 20 && freezeCount>0 && freeze == false)
        {
            freezeCount += 0.1f;
        }
       
        if (death == true || freeze==true)
        {
            //define_enemy.GetComponent<DeathPush>().enabled = true;
            if (push == false)
            {
                rb2d.velocity = Vector2.left * 0;
            }
            
            Sprite.color = new Color(0.2122642f, 0.327697f, 1, 0.9f);
        }
        else
        {
            directionCheckL = Physics2D.OverlapCircle(what_is_checkerL.position, 0.1f, what_is_Ground);
            directionCheckR = Physics2D.OverlapCircle(what_is_checkerR.position, 0.1f, what_is_Ground);
            if (directionCheckL == false && directionCheckR == true)
            {
                TrueDirectionIs = -1;
            }
            if (directionCheckL == true && directionCheckR == false)
            {
                TrueDirectionIs = 1;
            }

            rb2d.velocity = Vector2.left * TrueDirectionIs * movmentSpeed;


        }
        if (freeze == true && Physics2D.OverlapCircle(define_enemy.GetComponent<Transform>().position, 0.1f, what_is_Ground)==true)
        {
            rb2d.gravityScale = 0;
            
            rb2d.drag = 0.1f;
            //kickB();

        }
        if (define_Player.GetComponent<Movement>().releasedb == true && Physics2D.OverlapCircle(define_enemy.GetComponent<Transform>().position, 1.1f, what_is_Ground) == true)
        {
            kickB();
        }
        if (push==true && rb2d.velocity.x <= 5 && rb2d.velocity.x >= -5)
        {
            death = true;
        }
        if (death == true)
        {
            Instantiate(DeathCall,transform.position,Quaternion.identity);
            Destroy(define_enemy);
        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.GetComponent<Wall>() && push == true)
        {
            death = true;
        }
        if (collision.GetComponent<Wall>())
        {
            TrueDirectionIs *= -1;
        }
        
    }
    void Update()
    {

    }
}
