using UnityEngine;

public class CharacterStat : MonoBehaviour
{  
    public int maxHealth = 150;
    public int currentHealth {get; private set;}
    public heath_bar health_bar;
    public Transform explosion;

    public Stat damage;
    public Stat armor;

    void Awake() {
        currentHealth = maxHealth;
    }

    void Start() {
        health_bar.SetMaxHealth(maxHealth);
    }
    public void TakeDamage(int damage) {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;
        if (currentHealth <= 0) {
            Die();
        }
    }

    private void Die(){
        if(explosion) {
            GameObject exploder = ((Transform)Instantiate(explosion, this.transform.position, this.transform.rotation)).gameObject;
            Destroy(exploder, 2.0f);
        }
        PlayerManager.instance.KillPlayer();

    }
}
