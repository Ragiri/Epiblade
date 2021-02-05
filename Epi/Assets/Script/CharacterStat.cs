using UnityEngine;

public class CharacterStat : MonoBehaviour {

	public int maxHealth = 150;
	public int currentHealth {get;protected set;}
    public heath_bar health_bar;
	public Stat damage;
	public Stat armor;

	//public event System.Action OnHealthReachedZero;

    void Update() {
    }

	public virtual void Awake() {
		currentHealth = maxHealth;
        health_bar.SetMaxHealth(maxHealth);
	}

    public void TakeDamage (int damage) {
        damage -= armor.GetValue();
		damage = Mathf.Clamp(damage, 0, int.MaxValue);
        currentHealth -= damage;
        health_bar.SetHealth(currentHealth);
        if (currentHealth <= 0) {
            Die();
		}
    }
    
    public virtual void Die() {

    }

/*
	public virtual void Start () {
        health_bar.SetMaxHealth(maxHealth.GetValue());
	}

	public void TakeDamage (int damage){
		damage -= armor.GetValue();
		damage = Mathf.Clamp(damage, 0, int.MaxValue);
		currentHealth -= damage;
		Debug.Log(transform.name + " takes " + damage + " damage.");
		if (currentHealth <= 0) {
			if (OnHealthReachedZero != null)
				OnHealthReachedZero ();
		}
	}
	public void Heal (int amount) {
		currentHealth += amount;
		currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth.GetValue());
	}*/



}