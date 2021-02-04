using UnityEngine;
using UnityEngine.AI;
using System.Collections;

[RequireComponent(typeof(CharacterCombat))]
public class EnemyController : MonoBehaviour {

	public float lookRadius = 10f;

	Transform target;
	NavMeshAgent agent;
	CharacterCombat combatManager;

	void Start() {
		target = Player.instance.transform;
		agent = GetComponent<NavMeshAgent>();
		combatManager = GetComponent<CharacterCombat>();
	}

	void Update () {
		float distance = Vector3.Distance(target.position, transform.position);

		if (distance <= lookRadius) {
			agent.SetDestination(target.position);
			if (distance <= agent.stoppingDistance) {
				combatManager.Attack(Player.instance.playerStats);
				FaceTarget();
			}
		}
	}

    void FaceTarget() {
        Vector3 dir = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
