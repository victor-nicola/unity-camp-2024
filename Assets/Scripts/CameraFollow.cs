using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  public Transform objectToFollow;
  [SerializeField] private Vector3 offset;

  void Start()
  {
    transform.position = objectToFollow.position + offset;
  }

  void Update()
  {
    transform.position = objectToFollow.position + offset;
  }
}
