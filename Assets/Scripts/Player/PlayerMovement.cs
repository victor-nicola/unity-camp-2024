using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private string m_HorizontalAxis;
	[SerializeField] private string m_VerticalAxis;
	
	[SerializeField] private float m_MovementSpeed;
  [SerializeField] private float m_RotationSpeed;

	private CharacterController m_CharacterController;
	
	void Awake() 
	{
		m_CharacterController = GetComponent<CharacterController>();
    // transform.rotation = Quaternion.Euler(0, 45, 0);
	}
	
	void Update()
	{
    float horizontal_movement = Input.GetAxis(m_HorizontalAxis);
    float vertical_movement = Input.GetAxis(m_VerticalAxis);
		Vector3 movement = new Vector3(horizontal_movement, 0, vertical_movement);
    movement = Quaternion.Euler(0, 45, 0) * movement;
		
		if (movement.magnitude > 1) 
			movement = movement.normalized;
		
    if (!Mathf.Approximately(movement.magnitude, 0))
		  transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(movement), m_RotationSpeed * Time.deltaTime);
    
		m_CharacterController.Move(movement * m_MovementSpeed * Time.deltaTime);
	}
}