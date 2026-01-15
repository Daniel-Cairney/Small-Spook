using System;
using UnityEngine;
using UnityEngine.Events;

public class SpiritDelete : MonoBehaviour
{
    public static event Action SpiritCollected; 
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("IK KILL MEZELF LUL");
            gameObject.SetActive(false);

            SpiritCollected?.Invoke();
            Debug.Log("SpiritCollected Invoked");
        }
    }
}
