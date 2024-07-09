using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogSphere : MonoBehaviour
{
    public float exclusionRadius = 10f;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(exclusionRadius, exclusionRadius, exclusionRadius);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
