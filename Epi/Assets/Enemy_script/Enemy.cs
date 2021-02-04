using UnityEngine;

[RequireComponent(typeof(CharacterStat))]
public class Enemy : Interactable {

	CharacterStat stats;
    public Transform explosion;

	void Start ()
	{
		stats = GetComponent<CharacterStat>();
		stats.OnHealthReachedZero += Die;
	}
	public override void Interact()
	{
		print ("Interact");
		CharacterCombat combatManager = Player.instance.playerCombatManager;
		combatManager.Attack(stats);
	}

	void Die() {
        if(explosion) {
            GameObject exploder = ((Transform)Instantiate(explosion, this.transform.position, this.transform.rotation)).gameObject;
            Destroy(exploder, 2.0f);
        }
		Destroy (gameObject);
	}

}
