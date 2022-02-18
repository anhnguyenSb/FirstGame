using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int cherries = 0;
    public Text CherriesCount;
    public AudioSource CollectedItems;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cherry"))
        {
            CollectedItems.Play();
            Debug.Log("Cherry");
            Destroy(other.gameObject);
            cherries++;
            CherriesCount.text = "Cherries: " + cherries.ToString();
        }
    }
}
