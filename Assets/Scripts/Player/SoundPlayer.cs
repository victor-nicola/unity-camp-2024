using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
  private Rigidbody m_Rigidbody;
  void Start()
  {
    m_Rigidbody = gameObject.GetComponent<Rigidbody>();
  }

  void Update()
  {
    if (m_Rigidbody.velocity != Vector3.zero)
    {
      // play walking sound
    }
  }
}
