using UnityEngine;
using System;

public class ProgressObject : InteractableObject
{
	[SerializeField] private float m_Duration;
	[SerializeField] private ProgressBar m_ProgressBar;
	
	private float m_Timer = 0;
	private bool m_IsProgressFinished = false;

  public float GetProgress()
  {
    return Mathf.Clamp01(m_Timer / m_Duration);
  }

  public override bool CanInteractWith(PlayerInteraction playerInteraction)
	{
		return !m_IsProgressFinished;
	}

  public override void StartInteract(PlayerInteraction playerInteraction)
  {
    base.StartInteract(playerInteraction);
    m_ProgressBar.gameObject.SetActive(true);
    m_ProgressBar.SetProgress(GetProgress());
  }

  public override void StopInteract() 
	{
    base.StopInteract();
    m_ProgressBar.gameObject.SetActive(false);
    m_ProgressBar.SetProgress(0);
    m_Timer = 0;
	  m_IsProgressFinished = false;
	}

  void Update() 
	{
		if (IsInteracting() && !m_IsProgressFinished) 
		{
			m_Timer += Time.deltaTime;
			m_ProgressBar.SetProgress(GetProgress());
			
			Debug.Log($"{name} progress updated: {GetProgress()}");
			
			if (m_Timer >= m_Duration)
			{
        m_PlayerInteraction.ActOnObject(gameObject);
				m_IsProgressFinished = true;
        m_ProgressBar.gameObject.SetActive(false);
        Deselect();
				Debug.Log($"{name} progress finished");
        Destroy(gameObject);
        // play pick-up sound
			}
		}
	}
}