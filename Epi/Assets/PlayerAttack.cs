using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Camera cam;
    public GameObject Hand;
    public Weapon myWeapon;
    Animator handAnimation;

    void Start()
    {
        handAnimation = Hand.GetComponent<Animator>();
        myWeapon = Hand.GetComponentInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonUp(0))
            doAttack();       
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
            }
        }
    }
}
