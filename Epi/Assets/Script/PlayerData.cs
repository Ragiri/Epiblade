using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {

    public int lvl;
    public int health;
    public int mana;
    public int atk;
    public int def;
    public int exp;
    public int maxHealth;
    public int maxMana;
    List<Item> items;
    public float[] position;

    public PlayerData(CharacterStat player) {
        lvl = player.level.GetValue();
        health = player.currentHealth;
        mana = player.mana;
        maxHealth = player.maxHealth;
        maxMana = player.maxMana;
        atk = player.damage.GetValue();
        def = player.armor.GetValue();
        exp = player.exp.GetValue();

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }

}
