using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LoudTrigger : MonoBehaviour
{
  [SerializeField] private AudioSource sound;
  [HideInInspector] public bool thrown;
  [HideInInspector] public FollowTarget enemy;

  private void OnCollisionEnter(Collision collider)
  {
    if (collider.gameObject.tag == "Floor" && thrown)
    {
      enemy.SetGoal(transform);
      sound.Play();
    }
  }
}
