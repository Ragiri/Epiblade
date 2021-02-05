using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStat {
    
    public Transform explosion;
    public override void Die() {
        base.Die();
        if(explosion) {
            GameObject exploder = ((Transform)Instantiate(explosion, this.transform.position, this.transform.rotation)).gameObject;
            Destroy(exploder, 2.0f);
        }
        Destroy(gameObject);
    }
}
