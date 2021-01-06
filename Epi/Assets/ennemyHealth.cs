using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ennemyHealth : MonoBehaviour
{
    public float Health;
    //public ParticleEffect prefabParticle;

    //private GameObject instantiatedParticle;

    public void TakeDammage(float dam) {
        Health -= dam;
        if (Health <= 0) {
            Die();
            print("he died");
        }
        //print("ennemy take dammage");
    }

    private void Die(){
        //instantiatedParticle = Instantiate(prefabParticle, transform.position, Quaternion.identity);

        //Destroy(instantiatedParticle, 5);
        Destroy(gameObject);

    }
}
