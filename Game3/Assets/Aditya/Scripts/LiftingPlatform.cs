using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftingPlatform : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;

    [SerializeField]
    Vector3 startPosition;

    [SerializeField]
    Vector3 endPosition;

    [SerializeField]
    Vector3 targetPosition;

    [SerializeField]
    bool isStarted = false;


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (isStarted)
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, moveSpeed * Time.deltaTime);
        if (transform.localPosition == targetPosition)
        {
            isStarted = false;
        }
        
    }

    public void onPressed(object sender, EventTriggerSet.eventTrigger e)
    {
        isStarted = true;
        targetPosition = endPosition;
    }

    public void onReleased(object sender, EventTriggerSet.eventTrigger e)
    {
        isStarted = true;
        targetPosition = startPosition;
    }

}
