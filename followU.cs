using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followU : MonoBehaviour
{

    public Transform player;
    void Update()
    {
        transform.LookAt (player);
        transform.Translate(Vector3.forward * 2 * Time.deltaTime);
    }
}
