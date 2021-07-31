using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickB : MonoBehaviour
{
    public GameObject player;
    public float changValue; //ค่าแบตที่เพิ่ม
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag=="Player")
        {
            other.gameObject.GetComponent<BatterySystem>().PickUpPanel.SetActive(true); //อยู่ใกล้ขึ้น
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.transform.tag=="Player")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
               other.gameObject.GetComponent<BatterySystem>().PickUpPanel.SetActive(false);
               this.gameObject.SetActive(false);
               AddBattery(player,changValue);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.tag=="Player")
        {
            other.gameObject.GetComponent<BatterySystem>().PickUpPanel.SetActive(false); //อยู่ไกลหาย
        }
    }
    void AddBattery(GameObject player,float value)
    {
        if (player.GetComponent<BatterySystem>().battery < player.GetComponent<BatterySystem>().batteryMax)
        {
            player.GetComponent<BatterySystem>().battery+= value;
        }
    }

    
}
