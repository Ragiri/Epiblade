using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnnemyController : MonoBehaviour
{
    public float LookRadius = 10f;
    public float damage;
    Transform target;
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;
    NavMeshAgent agent;
    CharacterCombat combat;

    void Start()
    {
        // GameObject.FindGameObjectWithTag
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<CharacterCombat>();
    }

    void Update() {
        float distance = Vector3.Distance(target.position, transform.position);
        attackCooldown -= Time.deltaTime;
        if (distance <= LookRadius) {
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance) {
                PlayerAttack targetStat = target.GetComponent<PlayerAttack>();
                if (targetStat != null) {
                    if (attackCooldown <= 0f) {
                        targetStat.Attack(damage);
                        attackCooldown = 1f / attackSpeed;
                    }
                }
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
        Gizmos.DrawWireSphere(transform.position, LookRadius);
    }
}
