using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radomWalk : MonoBehaviour
{
    public float speed;
    public float WaitTime;
    public float startWaitTime;

    public Transform moveSpot;
    public float minX;
    public float manX;
    public float minY;
    public float manY;
    void Start()
    {
        WaitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX, manX), Random.Range(minY ,manY));
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed *Time.deltaTime);
        if(Vector2.Distance(transform.position, moveSpot.position) < 0.2f)
        {
            moveSpot.position = new Vector2(Random.Range(minX ,manX), Random.Range(minY ,manY));
            WaitTime =startWaitTime;
        }
        else
        {
            WaitTime -= Time.deltaTime;
        }
    }
}
