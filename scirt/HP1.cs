using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP1 : MonoBehaviour
{
    public float health;
    public float maxHealth;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy (this.gameObject);
            transform.position = new Vector3 (0, 2, 0);
            transform.rotation = Quaternion.Euler (0 , 0, 0);
            health = 100.0f;
        }
    }
    void FixedUpdate ()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }else if (health < maxHealth)
        {
            health += 0.0001f;
        }
    }
}
