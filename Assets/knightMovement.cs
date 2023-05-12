using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class knightMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator knightAnimator;
    enum directions 
    { 
        Left = 1,
        Right = -1
    };
    void Start()
    {
        knightAnimator = GetComponent<Animator>();
        transform.localScale = new Vector3((float)directions.Right, 1, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            knightAnimator.SetTrigger("attackOneTrig");
        }else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            knightAnimator.SetTrigger("attackTwoTrig");
        }
        if (Input.GetKey("left"))
        {
            knightAnimator.SetBool("walkBool", true);
            transform.localScale = new Vector3((float)directions.Left, 1, 1);
            transform.Translate(Vector3.left * Time.deltaTime);
        }else if (Input.GetKey("right"))
        {
            knightAnimator.SetBool("walkBool", true);
            transform.localScale = new Vector3((float)directions.Right, 1, 1);
            transform.Translate(Vector3.right * Time.deltaTime);
        }
        else
        {
            knightAnimator.SetBool("walkBool", false);
        }
    }
}
