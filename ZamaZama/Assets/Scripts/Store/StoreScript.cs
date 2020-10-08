using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreScript : MonoBehaviour
{
    [SerializeField]
    private GameObject storePanel;
    [SerializeField]
    private GameObject openstoreCollider;
        
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            storePanel.SetActive(true);
            openstoreCollider.SetActive(false);
        }
    }

   
}
