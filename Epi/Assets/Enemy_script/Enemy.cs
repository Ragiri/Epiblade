using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interactable {

    PlayerManager playerManager;
    
    void Start() {
        playerManager = PlayerManager.instance;
    }
    public override void Interact() {
        base.Interact();
        PlayerAttack playerAttack = playerManager.player.GetComponent<PlayerAttack>();
        if (playerAttack != null) {
            playerAttack.Attack(attackDamage);
        }
    }

}
