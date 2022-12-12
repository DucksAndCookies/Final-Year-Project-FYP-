using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMang : MonoBehaviour
{
    public GameObject Puzzle;
    public GameObject FirePuzzle;
    public LayerMask what_is_enemy;
    public bool PuzzleSwichFire;
    private float z = -30f;
    // Start is called before the first frame update
    void Start()
    {
    
        
        
    }

    // Update is called once per frame
    void Update()
    {
        PuzzleSwichFire = Physics2D.OverlapCircle(Puzzle.transform.position, 2.5f, what_is_enemy);
        if (PuzzleSwichFire == true)
        {
            FirePuzzle.SetActive(false);
            Puzzle.transform.Rotate(0, 0, z);
            z = 0;
        }
        else
        {
            z = -30f;
        }
        
        
    }
}
 