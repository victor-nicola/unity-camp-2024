using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInteraction : MonoBehaviour
{
	[Header("Raycast Settings")]
	[SerializeField] private Vector3 m_BoxCastSize;
	[SerializeField] private float m_CastLength;
	[SerializeField] private int m_CastBufferSize;
	[SerializeField] private LayerMask m_InteractionLayer;
	
	[Header("Input Settings")]
	[SerializeField] private string m_InteractInput;
	
  [Header("Object Refs")]
  [SerializeField] private HandScript hand;

	[Header("Warning")]
	public Warning warning;

	private InteractableObject m_CurrentInteractableObject;
	private RaycastHit[] m_CastBuffer;
	
	void Awake() 
	{
		m_CastBuffer = new RaycastHit[m_CastBufferSize];
	}
	
  public void ActOnObject(GameObject interactedObject) {
		Debug.Log("acted for: " + interactedObject.tag);
    if (interactedObject.tag == "Rock")
    {
      hand.rockNumber ++;
    }
    else if (interactedObject.tag == "Laptop")
    {
      //hand.laptopNumber ++;
			hand.equipItem((int)QuestTypes.laptop);
			Debug.Log(hand.objInHand);
    }
    else if (interactedObject.tag == "Bottle")
    {
      //hand.bottleNumber ++;
			hand.equipItem((int)QuestTypes.laptop);
			Debug.Log(hand.objInHand);
    }
		else if (interactedObject.tag == "Cartela")
		{
			hand.equipCard();
		}
  }

	void Update() 
	{
		InteractableObject interactableObject = null;
		
		int castCounter = Physics.BoxCastNonAlloc(transform.position, m_BoxCastSize / 2, transform.forward, m_CastBuffer, transform.rotation, m_CastLength, m_InteractionLayer.value);
		
		if (castCounter > 0)
		{
			while (castCounter > 0 && interactableObject == null) 
			{
				--castCounter;
				interactableObject = m_CastBuffer[castCounter].collider.GetComponent<InteractableObject>();
				if (interactableObject != null && !interactableObject.CanInteractWith(this))
					interactableObject = null;
			}
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
	public void OnStartInteract(CallbackContext context) {
		if (context.phase == UnityEngine.InputSystem.InputActionPhase.Performed && m_CurrentInteractableObject != null) {
			Debug.Log("E pressed");
			switch (m_CurrentInteractableObject.tag) 
			{
				case "Door":
					if (hand.hasCard)
						m_CurrentInteractableObject.StartInteract(this);
					else
						warning.ShowWarning("Ai nevoie de cartela!");
					break;

				case "Cartela":
					m_CurrentInteractableObject.StartInteract(this);
					break;

				case "Rock":
					m_CurrentInteractableObject.StartInteract(this);
					break;

				default:
					if (!hand.isFull())
						m_CurrentInteractableObject.StartInteract(this);
					else 
					{
						Debug.Log("Hand is full!");
						warning.ShowWarning("Deja ai ceva in mana!");
					}
					break;
			}
		}
	}

	public void OnStopInteract(CallbackContext context) {
		if (context.phase == UnityEngine.InputSystem.InputActionPhase.Performed && m_CurrentInteractableObject != null) {
			m_CurrentInteractableObject.StopInteract();
		}
	}

  // void OnDrawGizmos()
  // {
  //   Gizmos.DrawCube(transform.position, m_BoxCastSize / 2);
  // }
}