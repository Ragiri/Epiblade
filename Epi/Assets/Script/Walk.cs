using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Walk : MonoBehaviour
{
    public Animator animator;
    
    public bool isGrounded;

    void Start() {
    }

    void Update() {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow)) {
            animator.SetBool("walk", true);
        } else {
            animator.SetBool("walk", false);
        }
                
        if (Input.GetMouseButtonDown(0)) {
            animator.SetTrigger("attack");
        }
        
        if (Input.GetButtonDown("Jump") && isGrounded) {
            animator.SetTrigger("jump");
        }
        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.UpArrow)) {
            animator.SetBool("idle", true);
        } else {
            animator.SetBool("idle", false);
        }
    }
}
