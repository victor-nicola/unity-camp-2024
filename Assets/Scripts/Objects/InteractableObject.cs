using UnityEngine;

public class InteractableObject : MonoBehaviour
{
	protected PlayerInteraction m_PlayerInteraction;
  [SerializeField] protected AudioSource sound;
	
	public bool IsInteracting() 
	{
		return m_PlayerInteraction != null;
	}
	
	public void Select()
	{
		Debug.Log($"Object highlighted for interaction: {name}", this);
	}
	
	public void Deselect() 
	{
		StopInteract();
		Debug.Log($"Stopped highlighting object for interaction: {name}", this);
	}

	public virtual bool CanInteractWith(PlayerInteraction playerInteraction) 
	{
		return true;
	}
	
	public virtual void StartInteract(PlayerInteraction playerInteraction) 
	{
		if (m_PlayerInteraction != null) 
		{
			Debug.LogWarning($"{m_PlayerInteraction} is already interacting with object {name}", this);
			return;
		}
		m_PlayerInteraction = playerInteraction;
		Debug.Log($"{playerInteraction} started interaction with object: {name}", this);
    sound.Play();
	}
	
	public virtual void StopInteract() 
	{
		if (m_PlayerInteraction != null) 
		{
			Debug.Log($"{m_PlayerInteraction} stopped interaction with object: {name}", this);
			m_PlayerInteraction = null;
		}
    sound.Stop();
	}
}