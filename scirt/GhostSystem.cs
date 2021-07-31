using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSystem : MonoBehaviour
{
    public float damage = 1; //เลือดลด
    public float damageTime = 1;
    public GameObject palyer;
    public bool enbleDisappear = false;
    public float timeHealth = 3.0f; //เพิ่มเลือดผล.
    IEnumerator damagePlayer = null; //ลด
    IEnumerator healthPlayer = null; //เพิ่ม
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag=="Player")
        {
            enbleDisappear = true;
            other.gameObject.transform.Find("Main Camera").GetComponent<GlitchEffect>().enabled = true;
            if(healthPlayer!=null) //อย่าพึ่ง
            StopCoroutine(healthPlayer);
            damagePlayer = other.GetComponent<HealthSystem>().RemoveHealth(damage,damageTime); //ลดเลือด
            GetComponent<AudioSource>().Play();
            StartCoroutine(damagePlayer);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.tag=="Player")
        {
            other.gameObject.transform.Find("Main Camera").GetComponent<GlitchEffect>().enabled = false;
            StopCoroutine(damagePlayer);
            healthPlayer = other.gameObject.GetComponent<HealthSystem>().StartHealth(other.gameObject.GetComponent<HealthSystem>().health, timeHealth);
            StartCoroutine(healthPlayer);

        }
    }
}
