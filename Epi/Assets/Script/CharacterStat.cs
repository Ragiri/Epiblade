using UnityEngine;

public class CharacterStat : MonoBehaviour {

	public int maxHealth = 150;
	public int currentHealth {get;protected set;}
    public heath_bar health_bar;
	public Stat damage;
	public Stat armor;
    public Stat level;
    public Stat exp;
	public int maxMana = 20;
    public int  mana {get;protected set;}

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
		if (damage <= 0)
			damage = 1; 
        currentHealth -= damage;
        health_bar.SetHealth(currentHealth);
        if (currentHealth <= 0) {
            Die();
		}
    }
    
	public void LoadPlayer() {
        PlayerData data = SaveSystem.LoadData();
        level.baseValue = data.lvl;
        mana = data.mana;
		maxHealth = data.maxHealth;
		maxMana = data.maxMana;
        armor.baseValue = data.def;
        damage.baseValue = data.atk;
        exp.baseValue = data.exp;
        currentHealth = data.health;
		health_bar.SetHealth(currentHealth);
        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;
        Debug.Log("Load");
    }

	public void Heal(int heal, HealType type) {
		if (type == HealType.Pv) {
			currentHealth += heal;
			if (currentHealth >= maxHealth)
				currentHealth = maxHealth;
        	health_bar.SetHealth(currentHealth);
		}
		if (type == HealType.Mana) {
			mana += heal;
			if (mana >= maxMana)
				mana = maxMana;
		}
	}

	public void GainXP(int xp) {
		exp.baseValue += xp;
		GainLvl();
	}

	public void GainLvl() {
		if (exp.GetValue() >= 200 * level.GetValue()) {
			exp.baseValue -= 200 * level.GetValue();
			level.baseValue += 1;
			if (level.GetValue() % 2 == 0) {
				damage.baseValue += 3;
				armor.baseValue += 1;
				maxHealth += 5;
				currentHealth = maxHealth;
				maxMana += 1;
				mana = maxMana;
				health_bar.SetMaxHealth(maxHealth);
			} else {
				damage.baseValue += 1;
				armor.baseValue += 3;
				maxHealth += 5;
				currentHealth = maxHealth;
				maxMana += 1;
				mana = maxMana;
				health_bar.SetMaxHealth(maxHealth);
			}
		}

	}
    public virtual void Die() {

    }
}