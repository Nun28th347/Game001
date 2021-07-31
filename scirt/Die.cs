using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Die : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPoint;

    void OnTriggerEnter(Collider other)
    {
        player.transform.position = respawnPoint.transform.position;
}
}