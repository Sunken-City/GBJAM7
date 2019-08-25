using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldPlayerController : MonoBehaviour
{
    private Animator animator;
    public static Vector2 playerRespawnLocation;
    private static bool usePlayerRespawnLocation = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        if(usePlayerRespawnLocation)
        {
            transform.position = playerRespawnLocation;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInput();
    }

    void UpdateInput() 
    {
        bool isWalking = false;
        if(OverworldController.instance.freezeInput)
        {
            animator.SetBool("walking", false);
            return;
        }
        if(Input.GetKey(KeyCode.A))
        {
            isWalking = true;
            transform.position += new Vector3(-0.01f, 0, 0);
            animator.SetFloat("x", -1f);
            animator.SetFloat("y", 0f);
        }
        else if(Input.GetKey(KeyCode.D))
        {
            isWalking = true;
            transform.position += new Vector3(0.01f, 0, 0);
            animator.SetFloat("x", 1f);
            animator.SetFloat("y", 0f);
        }
        if(Input.GetKey(KeyCode.W))
        {
            isWalking = true;
            transform.position += new Vector3(0, 0.01f, 0);
            animator.SetFloat("x", 0f);
            animator.SetFloat("y", 1f);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            isWalking = true;
            transform.position += new Vector3(0, -0.01f, 0);
            animator.SetFloat("x", 0f);
            animator.SetFloat("y", -1f);
        }
        if(isWalking)
        {
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }

        if(Input.GetKeyUp(KeyCode.U))
        {
            usePlayerRespawnLocation = true;
            SceneManager.LoadScene("Overworld");
        }
    }
}
