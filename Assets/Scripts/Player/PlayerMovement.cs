using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

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
  [SerializeField] private Animator m_Animator;
  private Vector3 m_Movement;
  // private bool m_JumpRequested;
  // private bool m_IsGrounded;

  private bool m_IsWalking;

  [SerializeField] private AudioSource walkingSound;

  void Awake()
  {
    m_Rigidbody = GetComponent<Rigidbody>();
    m_Rigidbody = gameObject.GetComponent<Rigidbody>();
    // m_IsGrounded = false;
  }

  void Update()
  {
   //  if (Input.GetButtonDown(m_JumpAxis) && m_IsGrounded)
  //   {
  //     m_JumpRequested = true;
  //   }

    // float horizontal = Input.GetAxis(m_HorizontalAxis);
    // float vertical = Input.GetAxis(m_VerticalAxis);
    // m_Movement = new Vector3(horizontal, 0, vertical);

    // if ((horizontal != 0 || vertical != 0) && !walkingSound.isPlaying)
    // {
    //   walkingSound.Play();
    // }
    // if (horizontal == 0 && vertical == 0)
    // {
    //   walkingSound.Stop();
    // }
    //m_Movement = new Vector3(Input.GetAxis(m_HorizontalAxis), 0, Input.GetAxis(m_VerticalAxis));

    if (m_Movement.magnitude > 1)
      m_Movement = m_Movement.normalized;

    bool newiswalking = !Mathf.Approximately(m_Movement.magnitude, 0);
    if (newiswalking && !m_IsWalking) {
      m_IsWalking = true;
      m_Animator.SetBool("iswalking", true);
    } else if (!newiswalking && m_IsWalking) {
      m_IsWalking = false;
      m_Animator.SetBool("iswalking", false);
    }

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

  public void OnMove(CallbackContext context) {
      var move = context.ReadValue<Vector2>();
      m_Movement = new Vector3(move.x, 0, move.y);
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