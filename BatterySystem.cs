using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battery : MonoBehaviour
{
    public float battery = 100f;
    public float batteryMax = 100f;
    public GameObject flashLight; 
    public float removeBattery = 0.5f; //ค่าแบตที่ลด
    public float secondRemove = 2f; //เวลา
    public Slider batterySlider;
    public GameObject PickUpPanel;
    void Start()
    {
        battery = batteryMax;
        batterySlider.GetComponent<Slider>().maxValue = batteryMax;
        batterySlider.GetComponent<Slider>().value = battery;
        StartCoroutine(RemoveBattery(removeBattery,secondRemove));
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift)) //วิ่งไปเลยย
        {
            this.GetComponent<Animation>().CrossFade("Run",1);
        }
        else
        {
            this.GetComponent<Animation>().CrossFade("Idle",1);
        }
        batterySlider.GetComponent<Slider>().value = battery; //อัพเดทตลอดว่าลดเท่าไร
        if (battery/batteryMax * 100 <= 50) //เหลือ50%
        {
            flashLight.transform.Find("Spotlight").GetComponent<Light>().intensity=2.8f; //ปรับความสว่าง
        }
        if (battery/batteryMax * 100 <= 25) //เหลือ25%
        {
            flashLight.transform.Find("Spotlight").GetComponent<Light>().intensity=2.5f; //ปรับความสว่าง
        }
        if (battery/batteryMax * 100 <= 10) 
        {
            flashLight.transform.Find("Spotlight").GetComponent<Light>().intensity=1.0f;
        }
        if (battery/batteryMax * 100 <= 0) 
        {
            flashLight.transform.Find("Spotlight").GetComponent<Light>().intensity=0.0f;
        }
    }
    public IEnumerator RemoveBattery(float value,float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            if (battery>0)
            {
                battery -= value;
            }
        }
    }
}
