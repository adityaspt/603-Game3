using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LaserButton : MonoBehaviour
{
   [SerializeField]
    MovingPlatform movingPlatformObj;

    [SerializeField]
    LiftingPlatform liftingPlatformObj;

    public event EventHandler<EventTriggerSet.eventTrigger> onPressed;

    public event EventHandler<EventTriggerSet.eventTrigger> onReleased;

    [SerializeField]
    bool isControllingMovingPlatform = false, isControllingLiftingPlatform = false;


    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnEnable()
    {
        if (isControllingMovingPlatform)
        {
            onPressed += movingPlatformObj.onStartMove;
            onReleased += movingPlatformObj.Release;
        }
        else if (isControllingLiftingPlatform)
        {
            onPressed += liftingPlatformObj.onPressed;
            onReleased += liftingPlatformObj.onReleased;
        }
        else
        {
            Debug.LogWarning("Set the booleans correct in the inspector");
        }
    }

    private void OnDisable()
    {
        if (isControllingMovingPlatform)
        {
            onPressed -= movingPlatformObj.onStartMove;
            onReleased -= movingPlatformObj.Release;
        }
        else if (isControllingLiftingPlatform)
        {
            onPressed -= liftingPlatformObj.onPressed;
            onReleased -= liftingPlatformObj.onReleased;
        }
        else
        {
            Debug.LogWarning("Set the booleans correct in the inspector");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        onPressed?.Invoke(this, new EventTriggerSet.eventTrigger { typeOfEventTrigger = EventTriggerSet.typeOfTrigger.laser });
    }

    private void OnTriggerStay(Collider other)
    {
        onPressed?.Invoke(this, new EventTriggerSet.eventTrigger { typeOfEventTrigger = EventTriggerSet.typeOfTrigger.laser });
    }

    private void OnTriggerExit(Collider other)
    {
        onReleased?.Invoke(this, new EventTriggerSet.eventTrigger { typeOfEventTrigger = EventTriggerSet.typeOfTrigger.laser });
    }



}
