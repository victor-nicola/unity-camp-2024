using System.Threading;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.AI;

public class FollowTarget : MonoBehaviour
{
  [SerializeField] private Transform player1, player2;
  [SerializeField] private AudioSource walkingSound;
  [SerializeField] private AudioSource easterEggSound;
  [SerializeField] private float cooldown;
  public Transform m_TargetToFollow;

  private NavMeshAgent m_NavAgent;
  private float timer;
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
    timer = 0;
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
    bool isWalking = !Mathf.Approximately(m_NavAgent.velocity.magnitude, 0);

    timer += Time.deltaTime;
    if (isWalking && !walkingSound.isPlaying) {
      walkingSound.Play();
    } else if (!isWalking && walkingSound.isPlaying) {
      walkingSound.Stop();
    }

    if (timer >= cooldown)
    {
      easterEggSound.Play();
      timer = 0;
    }
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
