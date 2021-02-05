using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData {

    public int lvl;
    public float health;
    public int mana;
    public int atk;
    public int def;
    public int exp;
    public float[] position;

    public PlayerData(PlayerAttack player) {
        lvl = player.level;
        //health = player.Health;
        mana = player.mana;
        atk = player.atk;
        def = player.def;
        exp = player.exp;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }

}
