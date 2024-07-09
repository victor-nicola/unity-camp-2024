using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
	[SerializeField] private Vector3 m_BoxCastSize;
	[SerializeField] private float m_CastLength;
	
	private InteractableObject m_CurrentInteractableObject;
	
	void Update() 
	{
		InteractableObject interactableObject = null;
		
		if (Physics.BoxCast(transform.position, m_BoxCastSize / 2, transform.forward, out RaycastHit raycastHit, transform.rotation, m_CastLength))
		{
			interactableObject = raycastHit.collider.GetComponent<InteractableObject>();
			if (interactableObject != null && !interactableObject.CanInteractWith(this))
				interactableObject = null;
		}
		
		if (interactableObject != m_CurrentInteractableObject) 
		{
			if (m_CurrentInteractableObject != null) 
				m_CurrentInteractableObject.Deselect();
			
			m_CurrentInteractableObject = interactableObject;
			
			if (m_CurrentInteractableObject != null)
				m_CurrentInteractableObject.Select();
		}
	}
}