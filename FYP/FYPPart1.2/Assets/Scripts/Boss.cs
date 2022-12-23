using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Animator Astate;
    public Transform bosstransf;
    public Collider2D boss;
    public Collider2D BArm;
    public Collider2D FArm;
    public float MovmentSpeed;
    public Transform point1;
    public Transform point2;
    public Transform point3;
    public Transform point4;
    public Transform point5;
    public Transform[] points;
    public Transform[] spawningPoints;
    public GameObject[] bloodPart;
    public GameObject[] windPart;
    public int renD;
    public bool AttackingF;
    public Rigidbody2D Craw;
    public float speed;
    private GameObject cr;
    public int i=0;
    public int j=0;
    
    // Start is called before the first frame update
    void Start()
    {
        windPart[0].SetActive(false);
        windPart[1].SetActive(false);
        windPart[2].SetActive(false);
        windPart[3].SetActive(false);
        Rigidbody2D po = Instantiate(Craw, spawningPoints[i].position, spawningPoints[i].rotation);
        po.velocity = transform.right * speed;

        renD = 1;// Random.Range(1, 200);
    }
    private void FixedUpdate()
    {
        GameObject enemy = GameObject.Find("Enemy(Clone)");
        if ((GameObject.Find("Enemy(Clone)") != null))
        {

            if (enemy.GetComponent<enemyMovement>().freeze == true && enemy.GetComponent<enemyMovement>().boosTouch ==true)
            {
                bloodPart[j].SetActive(true);
                j += 1;
                Destroy(enemy);

            }
            //Destroy(creationParticals);
        }
        if (j < 3)
        {

            if (points[4].position.x - bosstransf.position.x > 0)
            {
                if (GetComponent<SpriteRenderer>().flipX == false)
                {
                    BArm.GetComponent<Transform>().RotateAround(bosstransf.position, Vector3.up, 180);
                    FArm.GetComponent<Transform>().RotateAround(bosstransf.position, Vector3.up, 180);
                }
                GetComponent<SpriteRenderer>().flipX = true;


            }
            else
            {
                if (GetComponent<SpriteRenderer>().flipX == true)
                {
                    BArm.GetComponent<Transform>().RotateAround(bosstransf.position, Vector3.up, 180);
                    FArm.GetComponent<Transform>().RotateAround(bosstransf.position, Vector3.up, 180);
                }
                GetComponent<SpriteRenderer>().flipX = false;

            }


            //Debug.Log(points[4].position.x - bosstransf.position.x);
            if (renD >= 1 && renD <= 5)
            {
                Astate.SetBool("Attack", false);
                bosstransf.position = Vector2.MoveTowards(bosstransf.position, points[0].position, MovmentSpeed);
            }
            if (renD >= 6 && renD <= 10)
            {
                Astate.SetBool("Attack", false);
                bosstransf.position = Vector2.MoveTowards(bosstransf.position, points[1].position, MovmentSpeed);
            }
            if (renD >= 11 && renD <= 15)
            {
                Astate.SetBool("Attack", false);
                bosstransf.position = Vector2.MoveTowards(bosstransf.position, points[2].position, MovmentSpeed);
            }
            if (renD >= 16 && renD <= 20)
            {
                Astate.SetBool("Attack", false);
                bosstransf.position = Vector2.MoveTowards(bosstransf.position, points[3].position, MovmentSpeed);
            }
            if (renD >= 21 && renD <= 25)
            {
                Astate.SetBool("Attack", false);
                bosstransf.position = Vector2.MoveTowards(bosstransf.position, points[4].position, MovmentSpeed);
            }
            if (renD >= 26 && renD <= 35)
            {

                AttackingF = true;
                Astate.SetBool("Attack", true);
                Rigidbody2D po = Instantiate(Craw, spawningPoints[i].position, spawningPoints[i].rotation);
                po.velocity = transform.right * speed;
                i++;
                //spawningPoints[i].position;
            }
            else
            {
                AttackingF = false;
                Astate.SetBool("Attack", false);
            }
            if (i >= 22)
            {
                i = 0;

                renD = Random.Range(1, 200);
            }
            /*if (GameObject.Find("Craw_0") == null)
            {
                //AttackingF = false;
                Debug.Log("get one");
            }
            else
            {

                Debug.Log("not there");
            }*/


            //bosstransf.position = Vector2.MoveTowards(bosstransf.position, point2.position, MovmentSpeed);
            //bosstransf.position = Vector2.MoveTowards(bosstransf.position, point3.position, MovmentSpeed);
            //bosstransf.position = Vector2.MoveTowards(bosstransf.position, point4.position, MovmentSpeed);
            //bosstransf.position = Vector2.MoveTowards(bosstransf.position, point5.position, MovmentSpeed);
            //boss.isTrigger = false;
            if ((AttackingF == false) && (bosstransf.position == points[0].position || bosstransf.position == points[1].position || bosstransf.position == points[2].position || bosstransf.position == points[3].position || bosstransf.position == points[4].position))
            {
                renD = Random.Range(1, 2000);

            }
        }
        else
        {
            Astate.SetBool("Attack", true);
            bosstransf.position = Vector2.MoveTowards(bosstransf.position, points[4].position, MovmentSpeed);
            if (bosstransf.position == points[4].position)
            {
                i += 1;
                if (i > 200)
                {
                    windPart[0].SetActive(true);
                    windPart[1].SetActive(true);
                    windPart[2].SetActive(true);
                    windPart[3].SetActive(true);
                    Destroy(gameObject);
                }
            }
        }
        //Debug.Log(AttackingF);
        //Debug.Log(bosstransf.position);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
