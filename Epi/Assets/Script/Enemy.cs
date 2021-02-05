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
        if (playerCombat != null) {
            playerCombat.Attack(myStat);
        }
    }
}
