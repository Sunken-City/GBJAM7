using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldPlayerController : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInput();
    }

    void FixedUpdate()
    {
        UpdateAnimation();
    }

    void UpdateAnimation()
    {
        float xAxis = Input.GetAxis("Horizontal");
        float yAxis = Input.GetAxis("Vertical");

        if(xAxis != 0 || yAxis != 0)
        {
            animator.SetBool("walking", true);

            if (xAxis == 0 && yAxis > 0)
            {
                //Player is facing up
                animator.SetFloat("x", 0f);
                animator.SetFloat("y", 1f);
            }
            else if (xAxis == 0 && yAxis < 0)
            {
                //Player is facing down
                animator.SetFloat("x", 0f);
                animator.SetFloat("y", -1f);
            }
            else if (xAxis > 0 && yAxis == 0)
            {
                //Player is facing right
                animator.SetFloat("x", 1f);
                animator.SetFloat("y", 0f);
            }
            else
            {
                //Player is facing left
                animator.SetFloat("x", -1f);
                animator.SetFloat("y", 0f);
            }
        }
        else
        {
            animator.SetBool("walking", false);
        }
    }

    void UpdateInput() 
    {
        if(OverworldController.instance.freezeInput)
        {
            return;
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-0.01f, 0, 0);
        }
        if(Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(0.01f, 0, 0);
        }
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0.01f, 0);
        }
        if(Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, -0.01f, 0);
        }
    }
}
