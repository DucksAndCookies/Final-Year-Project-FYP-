using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManue : MonoBehaviour
{
    public GameObject can;
    public GameObject[] butens;
    public Camera Camera1;
    public Camera Camera2;
    public Camera Camera3;
    public void SetInt(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }

    public int Getint(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }
    public void Startgame()
    {
        Camera2.enabled = false;
        Camera3.enabled = false;
        Camera1.enabled = true;
        //SceneManager.LoadScene(1);
    }
    public void StartStory()
    {
        butens[0].SetActive(false);
        butens[1].SetActive(false);
        butens[2].SetActive(false);
        SetInt("hyd", 0);
        SetInt("nitrogen", 0);
        SetInt("Helium", 0);
        SetInt("SaveScene", 0);
        can.SetActive(false);
        Camera1.enabled = false;
        Camera2.enabled = false;
        Camera3.enabled = true;
        //SceneManager.LoadScene(1);
    }
    public void continueLev()
    {
        SceneManager.LoadScene(Getint("SaveScene"));
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
