using UnityEngine;
using UnityEngine.AI;

public class MonsterChase : MonoBehaviour
{
    public Transform player;
    private Animator animator;
    private NavMeshAgent agent;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();

        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component is not found on " + gameObject.name);
            this.enabled = false; // Отключить скрипт, если NavMeshAgent отсутствует
            return;
        }
    }

    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < 10.0f && agent != null && agent.enabled)
        {
            agent.SetDestination(player.position);
            animator.SetBool("IsChasing", true);
        }
        else
        {
            animator.SetBool("IsChasing", false);
        }
    }
}
