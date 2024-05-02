using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject goincoinPrefab;

    public void DropItems()
    {
        Instantiate(goincoinPrefab, transform.position, Quaternion.identity);
    }
}
