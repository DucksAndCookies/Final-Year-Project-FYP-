using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManue : MonoBehaviour
{
    public GameObject can;
    public Camera Camera1;
    public Camera Camera2;
    public Camera Camera3;
    public void Startgame()
    {
        Camera2.enabled = false;
        Camera3.enabled = false;
        Camera1.enabled = true;
        //SceneManager.LoadScene(1);
    }
    public void StartStory()
    {
        can.SetActive(false);
        Camera1.enabled = false;
        Camera2.enabled = false;
        Camera3.enabled = true;
        //SceneManager.LoadScene(1);
    }
    // Start is called before the first frame update
    void Start()
    {
        Camera3.enabled = false;
        Camera1.enabled = false;
        Camera2.enabled = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera3.enabled==true && Input.GetMouseButtonDown(0))
        {

            Startgame();
        }
    }
}
