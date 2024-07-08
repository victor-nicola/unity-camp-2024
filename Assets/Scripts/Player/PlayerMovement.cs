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
	}
	
	void Update() 
	{
		Vector3 movement = new Vector3(Input.GetAxis(m_HorizontalAxis), 0, Input.GetAxis(m_VerticalAxis));
		
		if (movement.magnitude > 1) 
			movement = movement.normalized;
		
    if (!Mathf.Approximately(movement.magnitude, 0))
			transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(movement), m_RotationSpeed * Time.deltaTime);
    
		m_CharacterController.Move(movement * m_MovementSpeed * Time.deltaTime);
	}
}