using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemReceiver : MonoBehaviour
{
    public GameObject itemToReceive;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<Inventory>().inventory.Contains(itemToReceive))
            {
                other.GetComponent<Inventory>().RemoveObjectFromInventory(itemToReceive);
                gameObject.SetActive(false);
            }
        }
    }
}
