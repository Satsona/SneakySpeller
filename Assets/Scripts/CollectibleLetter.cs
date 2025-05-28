using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleLetter : MonoBehaviour
{
    public char letter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance != null)
            {
                GameManager.Instance.CollectLetter(letter);
            }
            else
            {
                Debug.LogError("GameManager.Instance is null!");
            }

            Destroy(gameObject);
        }
    }
}
