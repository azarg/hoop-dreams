using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("trigger exit");
        if (other.CompareTag("Bounds"))
        {
            Destroy(gameObject);
        }
    }
}
