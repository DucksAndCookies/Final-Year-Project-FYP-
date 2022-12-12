using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneTech : MonoBehaviour
{
    private int which_scene;
    private bool next;

    public LayerMask what_is_Player;
    public Rigidbody2D player;
    public Transform here;
    public Animator transition;
    public float transitionTime = 1f;

    private void Awake()
    {
        player = transform.GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        which_scene = SceneManager.GetActiveScene().buildIndex + 1;
        
    }
    
    private void SpecialLev()
    {
        //next = Physics2D.OverlapCircle(here.position, 2.1f, what_is_Player);
        if (next == true )
        {
           /* SetInt("hyd", 0);
            SetInt("nitrogen", 0);
            SetInt("Helium", 0);*/
            if (PlayerPrefs.GetInt("nitrogen")==0 && PlayerPrefs.GetInt("Helium") == 0)
            {

                if (here.transform.position.y > 2)
                {
                    StartCoroutine(fade(which_scene+10));
                    //SceneManager.LoadScene(which_scene + 10);
                }
                else
                {
                    StartCoroutine(fade(which_scene));
                    //SceneManager.LoadScene(which_scene);
                }

            }
            if (PlayerPrefs.GetInt("nitrogen") == 1 && PlayerPrefs.GetInt("Helium") == 0)
            {

                StartCoroutine(fade(16));
                //SceneManager.LoadScene(16);
                

            }
            if (PlayerPrefs.GetInt("nitrogen") == 0 && PlayerPrefs.GetInt("Helium") == 1)
            {

                StartCoroutine(fade(6));
                //SceneManager.LoadScene(6);


            }
            if (PlayerPrefs.GetInt("nitrogen") == 1 && PlayerPrefs.GetInt("Helium") == 1)
            {

                StartCoroutine(fade(21));
                //SceneManager.LoadScene(26);


            }



        }
        
    }

    // Update is called once per frame
    void Update()
    {
        next = Physics2D.OverlapCircle(here.position, 2.1f, what_is_Player);
        if (((which_scene - 1) == 5 || (which_scene - 1) == 20 || (which_scene - 1) == 15) && (which_scene-1!=0) && next==true)
        {

            SpecialLev();
        }
        else
        {

        
        
        if (next == true)
            {

                StartCoroutine(fade(which_scene));
            //SceneManager.LoadScene(which_scene);
            }
        }
    }
    IEnumerator fade(int id)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(id);
    }
}
