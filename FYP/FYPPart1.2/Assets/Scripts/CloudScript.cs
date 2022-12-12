using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    private float _speed ;
    private float _endPosX;

    private void Start()
    {
        
       // SpriteRenderer.Color = new Color(1f, 1f, 1f, .5f);
    }

    public void StartFloating(float speed,float endPosX)
    {
        _speed = speed;
        _endPosX = endPosX;
    }

    // Update is called once per frame
    void Update()
    {
       
       
        //spriteRenderer.color = new Color(1f, 1f, 1f, .5f);
        transform.Translate(Vector2.right * Time.deltaTime * _speed);
        if (transform.position.x > _endPosX)
        {
            Destroy(gameObject);
        }
    }
}
