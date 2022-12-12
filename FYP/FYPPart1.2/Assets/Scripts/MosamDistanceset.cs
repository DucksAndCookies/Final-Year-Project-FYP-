using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MosamDistanceset : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector2(player.transform.position.x+30, player.transform.position.y);
    }
}
