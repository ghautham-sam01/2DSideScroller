using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class dKnightMove : MonoBehaviour
{
    public Animator knightAnimator;
    // Start is called before the first frame update
    public SpriteRenderer[] children;
    enum directions
    {
        Left = 1,
        Right = -1
    };
    bool dirLeft = true;
    void Start()
    {
        knightAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //InvokeRepeating(movement, 2f,2f);
        movement();
    }

    void movement()
    {
        if (transform.position.x <= 5.0f)
        {
            dirLeft = false;
        }

        if (transform.position.x >= 9.0f)
        {
            dirLeft = true;
        }
        if (dirLeft)
        {
            knightAnimator.SetBool("walkBool", true);
            transform.localScale = new Vector3((float)directions.Left, 1, 1);
            transform.Translate(Vector3.left * Time.deltaTime);

        }
        else
        {
            knightAnimator.SetBool("walkBool", true);
            transform.localScale = new Vector3((float)directions.Right, 1, 1);
            transform.Translate(Vector3.right * Time.deltaTime);

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hero" && (knightAnimator.GetCurrentAnimatorStateInfo(0)
            .IsName("Attack1") || knightAnimator.GetCurrentAnimatorStateInfo(0).IsName("Attack2")))
        {
            Vector3 pos = collision.transform.position;
            Destroy(gameObject);
            children = gameObject.GetComponentsInChildren<SpriteRenderer>();
            foreach (SpriteRenderer child in children)
            {
                if(!child.name.Equals("Shadow") && !child.name.Contains("Eyes") 
                    && !child.name.Equals("Body"))
                {
                    GameObject clone = Instantiate(child.gameObject, pos, Quaternion.Euler(0, 0, 0));
                    clone.AddComponent<Rigidbody2D>();
                    clone.AddComponent<BoxCollider2D>();
                    clone.transform.localScale = new Vector3(.4f, .4f, .4f);
                    Rigidbody2D rg = clone.GetComponent<Rigidbody2D>();
                    rg.AddForce(new Vector2(Random.Range(5, 10), Random.Range(5, 10)), ForceMode2D.Impulse);

                }
            }
        }
    }
}
