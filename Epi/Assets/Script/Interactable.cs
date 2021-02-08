using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    //public float attackDamage;
    bool isFocus = false;
    Transform player;
    bool hasInteract = false;
    public float Speed = 0.19f;
    public float Cooldown = 0f;
    public Transform interactionTransform;

    void Start() {
        player = PlayerManager.instance.player.transform;
        //Debug.Log(player.position);
    }
    public virtual void Interact() {
        Debug.Log("Interacting with" + transform.name);
    }
    void Update() {
            float distance = 999;
            if (interactionTransform != null)
                distance = Vector3.Distance(player.position, interactionTransform.position);
            //print("Distance to other: " + distance);
            if (distance <= radius) {
                Interact();
                hasInteract = true;
            }
            Cooldown -= Time.deltaTime;
    }
    public void OnFocused(Transform playerTransform) {
        isFocus = true;
        player = playerTransform;
        hasInteract = false;
    }
    public void onDefocused() {
        isFocus = false;
        player = null;
    }
    void OnDrawGizmosSelected() {
        if (interactionTransform == null)
            interactionTransform = transform;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
}
