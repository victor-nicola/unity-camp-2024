using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField] private string m_HorizontalAxis;
  [SerializeField] private string m_VerticalAxis;
  [SerializeField] private float m_MovementSpeed;
  [SerializeField] private float m_RotationSpeed;

  private Rigidbody m_Rigidbody;
  private Vector3 m_Movement;

  void Awake()
  {
    m_Rigidbody = GetComponent<Rigidbody>();
  }

  void Update()
  {
    m_Movement = new Vector3(Input.GetAxis(m_HorizontalAxis), 0, Input.GetAxis(m_VerticalAxis));
    m_Movement = Quaternion.Euler(0, -90, 0) * m_Movement;

    if (m_Movement.magnitude > 1)
      m_Movement = m_Movement.normalized;

    if (!Mathf.Approximately(m_Movement.magnitude, 0))
      transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(m_Movement), m_RotationSpeed * Time.deltaTime);
  }

  private void FixedUpdate()
  {
    m_Rigidbody.velocity = m_Movement * m_MovementSpeed;
  }
}