using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerStats : CharacterStat {

	public SuperAttack superAttack;
	public CapacityHeal HealPv;
	public DefanceUp DefUp;

/*	void Start () {
		EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
	}

	void OnEquipmentChanged(Equipment newItem, Equipment oldItem) {
		if (newItem != null) {
			armor.AddModifier (newItem.armorModifier);
			damage.AddModifier (newItem.damageModifier);
		} if (oldItem != null) {
			armor.AddModifier (oldItem.armorModifier);
			damage.AddModifier (oldItem.damageModifier);
		}
	}*/
	
    public override void Die() {
		base.Die();
		PlayerManager.instance.KillPlayer();
	}
}
