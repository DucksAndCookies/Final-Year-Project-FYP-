using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public GameObject Whichenemy;
    public Transform[] creationLoacations;
    public ParticleSystem creationParticals;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        if ((GameObject.Find("Enemy(Clone)") != null))
        {
            
            Debug.Log("get one there");
            //Destroy(creationParticals);
        }
         else {
            int i = Random.Range(0, 2);
            Instantiate(creationParticals, creationLoacations[i].position, creationLoacations[i].rotation);
            Instantiate(Whichenemy, creationLoacations[i].position, creationLoacations[i].rotation);
            Debug.Log(i);
         }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
