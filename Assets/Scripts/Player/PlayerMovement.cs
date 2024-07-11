using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField] private string m_HorizontalAxis;
  [SerializeField] private string m_VerticalAxis;
  [SerializeField] private string m_JumpAxis;
  [SerializeField] private float m_MovementSpeed;
  // [SerializeField] private float m_JumpSpeed;
  [SerializeField] private float m_RotationSpeed;
	// [SerializeField] private LayerMask m_InteractionLayer;

  private Rigidbody m_Rigidbody;
  private Vector3 m_Movement;
  // private bool m_JumpRequested;
  // private bool m_IsGrounded;

  void Awake()
  {
    m_Rigidbody = GetComponent<Rigidbody>();
    // m_IsGrounded = false;
  }

  void Update()
  {
  //   if (Input.GetButtonDown(m_JumpAxis) && m_IsGrounded)
  //   {
  //     m_JumpRequested = true;
  //   }

    m_Movement = new Vector3(Input.GetAxis(m_HorizontalAxis), 0, Input.GetAxis(m_VerticalAxis));

    if (m_Movement.magnitude > 1)
      m_Movement = m_Movement.normalized;

    if (!Mathf.Approximately(m_Movement.magnitude, 0))
      transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(m_Movement), m_RotationSpeed * Time.deltaTime);
  }

  private void FixedUpdate()
  {
    // if (m_JumpRequested) {
    //   m_Rigidbody.AddForce(new Vector3(0, m_JumpSpeed, 0), ForceMode.Impulse);
    //   m_JumpRequested = false;
    // }
     m_Rigidbody.velocity = new Vector3(m_Movement.x * m_MovementSpeed, m_Rigidbody.velocity.y, m_Movement.z * m_MovementSpeed);
  }

  // void OnCollisionEnter(Collision collision)
  // {
  //   if (1 << collision.collider.gameObject.layer == m_InteractionLayer.value)
  //   {
  //     m_IsGrounded = true;
  //     Debug.Log("it's grounded");
  //   }
  // }

  // void OnCollisionExit(Collision collision)
  // {
  //   if (1 << collision.collider.gameObject.layer == m_InteractionLayer.value)
  //   {
  //     m_IsGrounded = false;
  //     Debug.Log("it's not grounded");
  //   }
  // }
}