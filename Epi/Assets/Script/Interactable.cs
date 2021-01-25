using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public float attackDamage;
    bool isFocus = false;
    Transform player;
    bool hasInteract = false;
    public Transform interactionTransform;

    void Start() {
        player = PlayerManager.instance.player.transform;
    }
    public virtual void Interact() {
        Debug.Log("Interacting with" + transform.name);
    }
    void Update() {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= radius) {
                Interact();
                hasInteract = true;
            }
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
