using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Camera cam;
    public Interactable focus;
    public GameObject Hand;
    public Weapon myWeapon;
    Animator handAnimation;
    public float MaxHealth;
    public float Health;
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;
    public heath_bar health_bar;

    void Start()
    {
        handAnimation = Hand.GetComponent<Animator>();
        myWeapon = Hand.GetComponentInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update() {
        attackCooldown -= Time.deltaTime;
        if (Input.GetMouseButtonUp(0))
            doAttack();       
    }

    public void Attack(float dam) {
        if (attackCooldown <= 0f) {
            Health -= dam;
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
                eHealth.TakeDammage(myWeapon.attackDamage);
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

    void SetFocus(Interactable newFocus) {
        focus = newFocus;
        newFocus.OnFocused(transform);
    }
}
