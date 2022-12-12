
using UnityEngine.SceneManagement;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public LayerMask what_is_Ground;
    public LayerMask what_is_enemy;
    public LayerMask what_is_boss;
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
    public bool freeze;
    private bool push=false;
    private int TrueDirectionIs=1;
    private SpriteRenderer Sprite;
    public bool boosTouch;
    
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
        if (SceneManager.GetActiveScene().buildIndex == 25)
        {
            boosTouch = Physics2D.OverlapCircle(define_enemy.GetComponent<Transform>().position, 6.1f, what_is_boss);
            GameObject boss = GameObject.Find("boss");
            if (freeze==false && Physics2D.OverlapCircle(define_enemy.GetComponent<Transform>().position, 6.1f, what_is_boss)==true)
            {
                rb2d.gravityScale = 0;
                define_enemy.GetComponent<CapsuleCollider2D>().isTrigger = true;
                Debug.Log("true");
            }
            if (Physics2D.OverlapCircle(define_enemy.GetComponent<Transform>().position, 4.1f, what_is_boss) == false)
            {
                if (freeze == false)
                {
                    rb2d.gravityScale = 36;
                }
                
                define_enemy.GetComponent<CapsuleCollider2D>().isTrigger = false;
                Debug.Log("false");
            }
        }

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
                //GetComponent<SpriteRenderer>().flipX = false;
                TrueDirectionIs = -1;
            }
            if (directionCheckL == true && directionCheckR == false)
            {
                //GetComponent<SpriteRenderer>().flipX = true;
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
        if (define_Player.GetComponent<Movement>().releasedb == true && Physics2D.OverlapCircle(define_enemy.GetComponent<Transform>().position, 0.49999f, what_is_enemy) == true)
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
        if (TrueDirectionIs == 1)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        if (TrueDirectionIs == -1)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        if ( define_enemy.GetComponent<Transform>().position.y < -40)
        {
            Instantiate(DeathCall, transform.position, Quaternion.identity);
            Destroy(define_enemy);
        }

    }
}
