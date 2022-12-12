using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class tutman : MonoBehaviour
{
    public GameObject Player;
    public GameObject x;
    public int tut1=0;
    public LayerMask tutor;
    public int val;
    public GameObject jumpT;
    public GameObject jumpBoard;
    private bool jumtutor = false;
    public void sett1()
    {
        tut1 = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    

    // Update is called once per frame
    void Update()
    {
        jumtutor = Physics2D.OverlapCircle(Player.transform.position, 0.4f, tutor);
        if (jumtutor == true)
        {
            tut1 = 0;
            jumpT.SetActive(true);
        }
        else
        {
            jumpT.SetActive(false);
        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            val = PlayerPrefs.GetInt("hyd");
        }
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            val = PlayerPrefs.GetInt("nitrogen");
        }
        if (SceneManager.GetActiveScene().buildIndex == 16)
        {
            val = PlayerPrefs.GetInt("Helium");
        }
        if (val == 1 && tut1==0)
        {
            PlayerPrefs.SetInt("t1", 1);
            x.SetActive(true);
        }
        if (tut1 == 1)
        {
            x.SetActive(false);
        }
        
    }
}
