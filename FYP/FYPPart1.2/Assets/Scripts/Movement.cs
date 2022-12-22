using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;
using System.Collections;

public class Movement : MonoBehaviour
{
    public ParticleSystem dusty;
    
    public ParticleSystem JumpDusty;
    public LayerMask What_is_wind;
    public LayerMask what_is_Ground;
    //public LayerMask what_is_Enemy;
    public LayerMask what_is_Element;
    //public float MovementSpeedmax;
    //public float incrementingSpeed;
    public float minYDeathTrigger = -10f;
    public float MovementSpeed;
    //public float MovementSpeedMultiplier;
    public float JumpVelocity ;
    public float increasingJumpVelovity;
    public float maxJumpVelocityVal;
    public float minAnimationspeed;
    public float temp;
    public float GChangeRate=0.3f;
    public float GcunversionFromTop;
    public float PlayerghangeYRateBefore;
    public float PlayerghangeYRateafter;
    public GameObject Around;
    public GameObject nitrogenflip;
    public GameObject nitrogenCollisionFlip;
    //for tutorial
    public GameObject ResetJStick;
    public GameObject canv;



    //private int mov = 0;
    public FixedJoystick lPosJoystick;
    public Animator animator;
   
    public bool releasedl;
    public bool releasedr;
    public bool releaseda;
    public bool releasedb;
    public bool releasedc;
    public bool grounded;
    //public bool Enemy_head;
    public bool elementDetect;
    public bool elementSet;
    public bool elementSet1;
    public bool elementSet2;
    public bool Quit;
    public bool cutscene = false;
    public bool flying;
    public Transform foot;
    public Transform Element;
    public Transform Nitrogen;
    private Rigidbody2D rb2d;


    //private BoxCollider2D box2d;
    public GameObject KeyA;
    public GameObject KeyB;
    public GameObject KeyC;
    public GameObject PouseButton;
    public GameObject PlayButton;

    public AudioClip[] sounds;
    AudioSource aud;



    void Start()
    {
        Nitrogen.GetComponent<ParticleSystem>().enableEmission = false;

        aud = GetComponent<AudioSource>();

    }
    
    public void CreateDust()
    {
        dusty.Play();
    }
    public void CreateJumpDust()
    {
        JumpDusty.Play();
    }

    void Awake()
    {
        rb2d = transform.GetComponent<Rigidbody2D>();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            SetInt("hyd", 0);
            SetInt("nitrogen", 0);
            SetInt("Helium", 0);



        }
        if (Getint("hyd") == 1)
        {
            KeyA.SetActive(true);
            elementSet = true;
        }
        if (Getint("nitrogen") == 1)
        {
            KeyB.SetActive(true);
            elementSet1 = true;
        }
        if (Getint("Helium") == 1)
        {
            KeyC.SetActive(true);
            elementSet2 = true;
        }
        //box2d = transform.GetComponent<BoxCollider2D>();

    }
    
    
    public void SetInt(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }

    public int Getint(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }
    




    public void PointerDown()
    {
        releasedl = true;
        //transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * MovementSpeed;
        //Debug.Log("You have clicked the button!");
    }
    public void releasedL()
    {
        releasedl = false;
        //transform.position += new Vector3(0, 0, 0) * Time.deltaTime * MovementSpeed;
        //Debug.Log("You have clicked the button!");
    }
    public void PointerDownr()
    {
        releasedr = true;
        //transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * MovementSpeed;
        //Debug.Log("You have clicked the button!");
    }
    public void releasedR()
    {
        releasedr = false;
        //transform.position += new Vector3(0, 0, 0) * Time.deltaTime * MovementSpeed;
       // Debug.Log("You have clicked the button!");
    }
    public void PointerDownc()//Collider2D collision)
    {
        releasedc = true;
        if (elementSet2 == true && grounded == false && flying==false)// && rb2d.gravityScale>0)
        {
           
            rb2d.gravityScale = 3f;
            
        }
        
        
        
        

        //transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * MovementSpeed;
       // Debug.Log("You have clicked the button!");
    }
    public void releasedC()
    {
        releasedc = false;
        rb2d.gravityScale = 18;
        //SceneManager.LoadScene("SampleScene");
        //Application.Quit();//Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        //transform.position += new Vector3(0, 0, 0) * Time.deltaTime * MovementSpeed;
        Debug.Log("You have clicked the button!");
    }
    public void QuitButton()
    {
        Quit = true;

        //transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * MovementSpeed;
        Debug.Log("You have clicked the button!");
    }
    public void QuitButtonRealeased()
    {
        Quit = false;
        //SceneManager.LoadScene("SampleScene");
        Application.Quit();//Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        //transform.position += new Vector3(0, 0, 0) * Time.deltaTime * MovementSpeed;
        Debug.Log("You have clicked the button!");
    }
    public void PointerDownA()
    {
        releaseda = true;
        if (grounded == true)
        {
            CreateJumpDust();
        }
        Debug.Log(Getint("hyd"));
        Debug.Log(Getint("nitrogen"));
        Debug.Log(Getint("Helium"));

    }
    public void PauseGame()
    {
        PouseButton.SetActive(false);
        PlayButton.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        PouseButton.SetActive(true);
        PlayButton.SetActive(false);
        Time.timeScale = 1;
    }
    public void PointerDownB()
    {
        if (elementSet1 == true)
        {
            Nitrogen.GetComponent<ParticleSystem>().enableEmission = true;
            nitrogenCollisionFlip.SetActive(true);

        }
        //SoundManager.Instance.PlaySoundEffect("fire");
        
        releasedb = true;

    }
    public void releasedB()
    {
        Nitrogen.GetComponent<ParticleSystem>().enableEmission = false;
        nitrogenCollisionFlip.SetActive(false);
        releasedb = false;
        
    }
    private void Reset()
    {
        if (lPosJoystick.Horizontal > 0.4)
        {
            Debug.Log("planted");
            lPosJoystick.input.x = 0;//new Vector2(0,0);
            //lPosJoystick.OnDrag;// new Vector2(0, 0);
            //ResetJStick =  //GameObject.FindWithTag("GameController");

        }
    }

   


    private void FixedUpdate()
    {
        lPosJoystick.Horizontal.Equals(0);

        if (grounded == false && JumpVelocity !=0)
        {
            animator.SetBool("Jump", true);
        }
        //Enemy_head = Physics2D.OverlapCircle(foot.position, 0.1f, what_is_Enemy);
        grounded = Physics2D.OverlapCircle(foot.position, 0.1f, what_is_Ground);
        
        elementDetect = Physics2D.OverlapCircle(Element.position, 0.001f, what_is_Element);
        flying = Physics2D.OverlapCircle(foot.position, 0.9f, What_is_wind);

        /*PlayerghangeYRateBefore = Around.transform.position.y;
        PlayerghangeYRateafter = PlayerghangeYRateBefore - Around.transform.position.y;
        if (PlayerghangeYRateafter > 0.5 )//&& PlayerghangeYRateafter < 7)
        {
            rb2d.gravityScale -= GChangeRate;
            Debug.Log(PlayerghangeYRateBefore);
            Debug.Log(PlayerghangeYRateafter);
        }
        if(PlayerghangeYRateafter<-0.5 )//&& PlayerghangeYRateafter > -7)
        {
            rb2d.gravityScale += GChangeRate;
            Debug.Log(PlayerghangeYRateBefore);
            Debug.Log(PlayerghangeYRateafter);
        }*/
        //Debug.Log(PlayerghangeYRateBefore);
        //Debug.Log(PlayerghangeYRateafter);
        if (flying==true && releasedc == true)//other.gameObject.tag == "Player" &&
        {
            if (rb2d.gravityScale > -5.1f)
            {
                //GChangeRate -= 3f;
                rb2d.gravityScale = -5f;//GChangeRate;
            //GcunversionFromTop = 500;
            }
           // Debug.Log("collision is hapning");

        }
        if (flying == false && grounded == false && releasedc == true)//&& rb2d.gravityScale < 1)
        {

            rb2d.gravityScale = 3;
            /*if (rb2d.gravityScale < 0.5f)
            {
                //GcunversionFromTop -= 2;
                rb2d.gravityScale = 0.5f;//-GChangeRate;
                GcunversionFromTop -= 2;


            }
            if (rb2d.gravityScale >= 0.5)
            {
                rb2d.gravityScale = 0.5f;
            }*/
            


        }

        if (releasedl == true || lPosJoystick.Horizontal < 0 || Input.GetKey(KeyCode.A))
        {
            //   transform.position += new Vector3(-1, 0, 0) 

          //  Debug.Log(lPosJoystick.Horizontal);
            if (GetComponent<SpriteRenderer>().flipX == false)
            {
                nitrogenflip.GetComponent<Transform>().RotateAround(Around.transform.position, Vector3.up, 180);
                nitrogenCollisionFlip.GetComponent<Transform>().RotateAround(Around.transform.position, Vector3.up, 180);
                CreateDust();
            }
            GetComponent<SpriteRenderer>().flipX = true;
            
            
            // animator.SetFloat("Speed",Mathf.Abs(lPosJoystick.Horizontal));
            if (Mathf.Abs(lPosJoystick.Horizontal) > minAnimationspeed || Input.GetKey(KeyCode.A))
            {
                animator.speed = Mathf.Abs(lPosJoystick.Horizontal);
            }
            

            rb2d.velocity = new Vector2(lPosJoystick.Horizontal * MovementSpeed, rb2d.velocity.y);// Vector2.left  * MovementSpeedMultiplier * MovementSpeed;
            //rb2d.velocity = new Vector2(-1 * MovementSpeed, rb2d.velocity.y);



        }
       

        if (releasedr == true || lPosJoystick.Horizontal > 0 || Input.GetKey(KeyCode.D))
        {
            //Debug.Log(lPosJoystick.Horizontal);
            if (GetComponent<SpriteRenderer>().flipX == true)
            {
                nitrogenflip.GetComponent<Transform>().RotateAround(Around.transform.position, Vector3.up, 180);
                CreateDust();
            }
            GetComponent<SpriteRenderer>().flipX = false;
            
            //transform.position += new Vector3(1, 0, 0) * Time.deltaTime * MovementSpeed;
            if (Mathf.Abs(lPosJoystick.Horizontal) > minAnimationspeed || Input.GetKey(KeyCode.D))
            {
                animator.speed = Mathf.Abs(lPosJoystick.Horizontal);
            }
            rb2d.velocity = new Vector2(lPosJoystick.Horizontal * MovementSpeed, rb2d.velocity.y);//rb2d.velocity = Vector2.right  * MovementSpeedMultiplier * MovementSpeed;
            //rb2d.velocity = new Vector2(1 * MovementSpeed, rb2d.velocity.y);
            

        }
        if (((Input.GetKey(KeyCode.Space) || releaseda == true) && (grounded) && elementSet == true))
        {

            aud.PlayOneShot(sounds[0], 1);

        }

        if (((Input.GetKey(KeyCode.Space) || releaseda == true) && (grounded) && elementSet == true) || (JumpVelocity != maxJumpVelocityVal))
        {
            
            JumpVelocity -= increasingJumpVelovity;
            rb2d.velocity = new Vector2(rb2d.velocity.x, JumpVelocity); // Vector2.up * JumpVelocity;
            releaseda = false;
            Debug.Log("You have clicked the button!");
            if (JumpVelocity <= 0)
            {
                animator.SetBool("Jump", false);
                JumpVelocity = maxJumpVelocityVal;
            }
            /*
            //transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * MovementSpeed;
            //rb2d.AddForce(Vector2.up * JumpVelocity, ForceMode2D.Impulse);
            rb2d.velocity = Vector2.up  * (JumpVelocity-10);
            
            //JumpVelocity -= increasingJumpVelovity;
           // rb2d.velocity = new Vector2(rb2d.velocity.x, JumpVelocity); // Vector2.up * JumpVelocity;
            releaseda = false;
           // Debug.Log("You have clicked the button!");
            if (JumpVelocity <= 0)
            {
                animator.SetBool("Jump", false);
             //   JumpVelocity = maxJumpVelocityVal;
            }
            */
        }
       
        // This is where i am coding nitrogen





    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CoinRUtation>())
        {
            Destroy(collision.gameObject);
            aud.PlayOneShot(sounds[1], 1);
            Debug.Log("this is coin");
            
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetInt("hyd", 0);
            SetInt("nitrogen", 0);
            SetInt("Helium", 0);



        }




        if (grounded == true)
        {
            if (rb2d.gravityScale < 5)
            {
                rb2d.gravityScale +=0.5f;
            }
            
            animator.SetFloat("Speed", Mathf.Abs(lPosJoystick.Horizontal));
            animator.SetBool("Jump", false);
        }

        if (rb2d.position.y < minYDeathTrigger)
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
        if (!animator.GetBool("Jump"))
        {
            animator.SetBool("jumpDown", true);
        }
        if(grounded==true)
        {
            animator.SetBool("jumpDown", false);
        }
        if (elementDetect == true )
        {
            aud.PlayOneShot(sounds[2], 0.6f);
            cutscene = false;

            if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                SetInt("hyd", 1);

                KeyA.SetActive(true);
                elementSet = true;
            }
            if (SceneManager.GetActiveScene().buildIndex == 6)
            {
                SetInt("nitrogen", 1);

                KeyB.SetActive(true);
                elementSet1 = true;
            }
            if (SceneManager.GetActiveScene().buildIndex == 16)
            {
                SetInt("Helium", 1);

                KeyC.SetActive(true);
                elementSet2 = true;
            }

            Debug.Log("yes it is");
        }
        
        if (cutscene == false)
        {
            
            canv.SetActive(true);
            MovementSpeed = 14;

        }
        else
        {
            Reset();
            canv.SetActive(false);
            MovementSpeed = 0;
        }
        if ( cutscene==true)//Input.GetMouseButton(0) == false ||
        {
            Debug.Log("mous off");
            MovementSpeed = 0;
            temp = minAnimationspeed;
            minAnimationspeed = 0;
        }
        else
        {
            MovementSpeed = 14;
            minAnimationspeed = temp;
        }










    }
}