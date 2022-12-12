using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EpowerUp : MonoBehaviour
{
    public GameObject target;
    public GameObject self;
    public LayerMask what_is_player;


    public float compressSpeed = 0.1f;
    public float step=0.1f;
    public bool dir=false;
    public float DestryRangY=0.3f;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1 && PlayerPrefs.GetInt("hyd") == 1)
        {
            Debug.Log("this is helium1");
            self.SetActive(false);
        }
        if (SceneManager.GetActiveScene().buildIndex == 6 && PlayerPrefs.GetInt("nitrogen") == 1)
        {
            Debug.Log("this is helium2");
            self.SetActive(false);
        }
        if (SceneManager.GetActiveScene().buildIndex == 16 && PlayerPrefs.GetInt("Helium") == 1)
        {
            Debug.Log("this is helium");
            self.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Player")
        {
            target.GetComponent<Movement>().cutscene = true;
            dir = true;
        }
    }
    private void FixedUpdate()
    {
        if (dir == true)
        {
            self.transform.position = Vector2.MoveTowards(self.transform.position, target.transform.position, step);

            //transform.Translate(Vector3.Normalize(target.transform.position - transform.position) * step);
            self.transform.localScale = new Vector2(self.transform.localScale.x-compressSpeed, self.transform.localScale.y-compressSpeed);
        }
        if (Physics2D.OverlapCircle(self.transform.position, 0.1f, what_is_player))//self.transform.localScale.y < DestryRangY)
        {
            self.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update()
    {
        

    }
}
