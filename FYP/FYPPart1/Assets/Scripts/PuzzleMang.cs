using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMang : MonoBehaviour
{
    public GameObject Puzzle;
    public GameObject FirePuzzle;
    public LayerMask what_is_enemy;
    public bool PuzzleSwichFire;
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
            Puzzle.SetActive(false);
        }
        
        
    }
}
 