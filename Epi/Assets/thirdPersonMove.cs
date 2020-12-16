using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thirdPersonMove : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public float s = 6f;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       float h = Input.GetAxisRaw("Horizontal");
       float v = Input.GetAxisRaw("Vertical");
       Vector3 dir = new Vector3(h , 0f, v).normalized;
       
       if (dir.magnitude >= 0.1f) {
           float targetA = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
           float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetA, ref turnSmoothVelocity, turnSmoothTime);
           transform.rotation = Quaternion.Euler(0f, angle, 0f);
           Vector3 movedir = Quaternion.Euler(0f, targetA, 0f) * Vector3.forward;
           controller.Move(movedir.normalized * s * Time.deltaTime);
       }
    }
}
