using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterStat))]
public class Enemy : Interactable {
    PlayerManager playerManager;
    CharacterStat myStat;

    //void Start() {
        //playerManager = PlayerManager.instance;
        //myStat = GetComponent<CharacterStat>();
    //}
    public override void Interact() {
        base.Interact();
        playerManager = PlayerManager.instance;
        myStat = GetComponent<CharacterStat>();
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        //Weapon myWeapon = playerManager.player.Hand.GetComponent<Weapon>();
        if (playerCombat != null && Input.GetMouseButtonUp(0)) {
            playerCombat.Attack(myStat);
        }
    }
}
