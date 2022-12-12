using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BGYMov : MonoBehaviour
{
    public Transform Player;
    public Transform BG;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex > 5)
        {
            BG.position = new Vector2(BG.position.x, Player.position.y);
        }
        
    }
}
