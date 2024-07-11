using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caratela : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 45f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the rotation for this frame
        float rotationAmount = rotationSpeed * Time.deltaTime;

        // Rotate the object around the y-axis
        transform.Rotate(0, 0, rotationAmount);
    }
}
