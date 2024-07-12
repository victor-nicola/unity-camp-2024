using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAgent : MonoBehaviour
{
  private Rigidbody m_Rigidbody;
  private float timer;
  [SerializeField] private float cooldown;
  void Start()
  {
    m_Rigidbody = gameObject.GetComponent<Rigidbody>();
    timer = 0;
  }

  void Update()
  {
    timer += Time.deltaTime;
    if (m_Rigidbody.velocity != Vector3.zero)
    {
      // play walking sound
    }
    if (timer >= cooldown)
    {
      // play du-te-n camera sound
      timer = 0;
    }
  }
}
