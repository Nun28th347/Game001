using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class PageSystem : MonoBehaviour
{
    public int Collectionpage;
    public List<GameObject> pages=new List<GameObject>();
    public GameObject pickUpPanel;
    public GameObject finishPanel;
    public GameObject pageCounttxt;
 
    // Update is called once per frame
    void Update()
    {
        pageCounttxt.GetComponent<Text>().text="Pages"+ Collectionpage+"/8";
        if(Collectionpage>=8)
        {
            finishPanel.SetActive(true);
            this.gameObject.GetComponent<FirstPersonController>().enabled = false;
            Cursor.visible = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.transform.tag=="Page")
        {
            pickUpPanel.SetActive(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.transform.tag=="Page")
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
               pickUpPanel.SetActive(false); //ซ่อน
               pages.Add(other.gameObject); //เก็บลงลิส
               Collectionpage++;
               other.gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.transform.tag=="Page")
        {
            pickUpPanel.SetActive(false); //ไม่ได้ยืน แค่ผ่านมา
        }
    }
}
