using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    public NavMeshAgent agent;
    private Transform target;
    private bool playerSpawned = false;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        StartCoroutine(FindPlayer());
    }
    void Update()
    {
        if (playerSpawned && target != null)
        {
            agent.SetDestination(GetTargetPostion(target.position));
        }
    }

    private Vector3 GetTargetPostion(Vector3 targetPosition)
    {
        var pos1 = targetPosition;
        var pos2 = targetPosition;
        var pos3 = target.position;
        var pos4 = target.position;
        pos1.y -= 5f;
        pos2.y += 5f;
        pos3.x -= 5f;
        pos4.x += 5f;
        Vector3[] positions =
        {
          pos1,pos2,pos3,pos4
        };
        return positions[Random.Range(0, positions.Length)];
    }

    private IEnumerator FindPlayer()
    {
        while (!playerSpawned)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player != null)
            {
                target = player.transform; 
                playerSpawned = true; 
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}
