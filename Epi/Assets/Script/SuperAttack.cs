using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Super Attack", menuName = "Capacity/SuperAttack")]
public class SuperAttack : Capacity {

    public int power = 0;
    public Animator animator;
    CharacterStat targetStat;

    public override void Use() {
        base.Use();
        if (lvl > 0) {
            CharacterCombat playerCombat = PlayerManager.instance.player.GetComponent<CharacterCombat>();
            playerCombat.Attack(targetStat, power);
            animator = PlayerManager.instance.player.GetComponent<Animator>();
            animator.SetTrigger("superAttack");
        }
    }
    public void GetStat(CharacterStat Stat) {
        targetStat = Stat;
    }
    public override void LvlUp() {
        base.LvlUp();
        if (lvlup) {
            power += 3;
            lvlup = false;
        }
    }

}
