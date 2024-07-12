using System.Threading;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.AI;

public class FollowTarget : MonoBehaviour
{
  public Transform player1, player2;
  [SerializeField] private AudioSource walkingSound;
  [SerializeField] private AudioSource easterEggSound;
  [SerializeField] private float cooldown;
  public Transform m_TargetToFollow;

  [SerializeField] private float distDiffToChange = 20f;

  private NavMeshAgent m_NavAgent;
  private bool gameFroze;

  private float timer;
  void Awake()
  {
    // At the start the game is frozen
    GetComponent<NavMeshAgent>().speed = 0;
    gameFroze = true;
  }

  public void unFreeze(float speed) {
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
    GetComponent<NavMeshAgent>().speed = speed;
    gameFroze = false;
    timer = 0;

    // At the start the game is frozen
    GetComponent<NavMeshAgent>().speed = 0;
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

    if (!gameFroze)
    {
      Debug.Log("following: " + m_TargetToFollow.gameObject.name);
      SetGoal(m_TargetToFollow);
      if (Vector3.Distance(m_TargetToFollow.position, transform.position) <= 1f)
      {
        Debug.Log("p1 dist: " + Vector3.Distance(m_TargetToFollow.position, transform.position));
        Debug.Log("p2 dist: " + Vector3.Distance(player2.position, transform.position));
        m_TargetToFollow = player1;
        if (player2 != null && player2.gameObject.activeSelf && Vector3.Distance(m_TargetToFollow.position, transform.position) > Vector3.Distance(player2.position, transform.position))
        {
          m_TargetToFollow = player2;
        }
      }
      if (Vector3.Distance(m_TargetToFollow.position, transform.position) - Vector3.Distance(player1.position, transform.position) > distDiffToChange)
      {
        m_TargetToFollow = player1;
      }
      if (Vector3.Distance(m_TargetToFollow.position, transform.position) - Vector3.Distance(player2.position, transform.position) > distDiffToChange)
      {
        m_TargetToFollow = player2;
      }
    }
  }
}
