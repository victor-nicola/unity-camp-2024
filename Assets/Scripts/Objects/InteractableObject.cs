using UnityEngine;

public class InteractableObject : MonoBehaviour
{
	public void Select()
	{
		Debug.Log($"Object highlighted for interaction: {name}", this);
	}
	
	public void Deselect() 
	{
		Debug.Log($"Stopped highlighting object for interaction: {name}", this);
	}

	public virtual bool CanInteractWith(PlayerInteraction playerInteraction) 
	{
		return true;
	}
}