using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Camera cam;
    public Interactable focus;
    //public GameObject Hand;
    //public Weapon myWeapon;
    //Animator handAnimation;
    //public float MaxHealth;
    //public float Health;
    //public float attackSpeed = 1f;
    //private float attackCooldown = 0f;
    //public heath_bar health_bar;

    //move
    public CharacterController controller;
    public Transform thing;
    public float s = 6f;
    public float turnSmoothTime = 0.1f;
    public float turnSmoothVelocity;

    public bool isGrounded;
    private Vector3 playerVelocity;
    private float jumpHeight = 2.0f;
    private float gravityValue = -9.81f;

    void Start()
    {
        //handAnimation = Hand.GetComponent<Animator>();
        //myWeapon = Hand.GetComponentInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update() {
        //move
        isGrounded = controller.isGrounded;
        if (isGrounded && playerVelocity.y < 0) {
            playerVelocity.y = -1f;
        }
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h , 0f, v).normalized;
       
        if (dir.magnitude >= 0.1f) {
           float targetA = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + thing.eulerAngles.y;
           float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetA, ref turnSmoothVelocity, turnSmoothTime);
           transform.rotation = Quaternion.Euler(0f, angle, 0f);
           Vector3 movedir = Quaternion.Euler(0f, targetA, 0f) * Vector3.forward;
           controller.Move(movedir.normalized * s * Time.deltaTime);
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
        
        //attackCooldown -= Time.deltaTime;
        /*if (Input.GetMouseButtonUp(0)) {
            doAttack();
        }*/
    }
    public void SavePlayer() {
        SaveSystem.SavePlayer(PlayerManager.instance.player.GetComponent<CharacterStat>());
        Debug.Log("Save");
    }

/*
    public void Attack(float dam) {
        if (attackCooldown <= 0f) {
            Health -= dam - def;
            health_bar.SetHealth(Health);
            attackCooldown = 1f / attackSpeed;
            if (Health <= 0) {
               print("he died");
                PlayerManager.instance.KillPlayer();
            }
        }
    }
    private void doAttack() {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction * myWeapon.attackRange, Color.magenta);
        if (Physics.Raycast(ray, out hit, myWeapon.attackRange)) {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.tag == "Ennemy") {
                ennemyHealth eHealth = hit.collider.GetComponent<ennemyHealth>();
                eHealth.TakeDammage(myWeapon.attackDamage + atk);
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                SetFocus(interactable);
            } else {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null) {
                    SetFocus(interactable);
                }
            }
        }
    }
*/
    void SetFocus(Interactable newFocus) {
        focus = newFocus;
        newFocus.OnFocused(transform);
    }
}
