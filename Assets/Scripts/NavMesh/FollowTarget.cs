using UnityEngine;
using UnityEngine.AI;

public class FollowTarget : MonoBehaviour
{
  [SerializeField] private Transform player1, player2;
  public Transform m_TargetToFollow;

  private NavMeshAgent m_NavAgent;

  void Awake()
  {
    m_NavAgent = GetComponent<NavMeshAgent>();
    float distanceP1 = Vector3.Distance(player1.position, transform.position);
    float distanceP2 = Vector3.Distance(player2.position, transform.position);
    if (distanceP1 <= distanceP2)
    {
      SetGoal(player1);
    }
    else
    {
      SetGoal(player2);
    }
  }

  public void SetGoal(Transform goal)
  {
    m_TargetToFollow = goal;
    if (m_TargetToFollow != null)
    {
      m_NavAgent.SetDestination(m_TargetToFollow.position);
    }
  }

  void Update()
  {
    SetGoal(m_TargetToFollow);
    if (Vector3.Distance(m_TargetToFollow.position, transform.position) <= 1f)
    {
      m_TargetToFollow = player1;
      if (player2 != null && player2.gameObject.activeSelf && Vector3.Distance(m_TargetToFollow.position, transform.position) > Vector3.Distance(player2.position, transform.position))
      {
        m_TargetToFollow = player2;
      }
    }
  }
}
