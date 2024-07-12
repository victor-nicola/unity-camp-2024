using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class home : MonoBehaviour
{
    // The tag to check for
    [SerializeField] private string playerTag = "Player";

    // This function is called when another collider enters the trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the entering collider has the specified tag
        if (other.CompareTag(playerTag))
        {
            Debug.Log("Player has entered the trigger area.");
            // Add your custom logic here
            HandScript hand = other.GetComponentInChildren<HandScript>();
            hand.emptyHand();
        }
    }
}
