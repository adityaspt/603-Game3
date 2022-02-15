using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    [SerializeField]
    Vector3 startPosition;

    [SerializeField]
    Vector3 endPosition;

    [SerializeField]
    Vector3 updatedStart;

    [SerializeField]
    bool isAtOriginalPos = true;

    [SerializeField]
    Vector3 targetPosition;

    [SerializeField]
    bool isMovingTowardsOriginalPos = false;

    [SerializeField]
    bool isAtTargetPosition = false;

    [SerializeField]
    bool startMoving;

    [SerializeField]
    float moveSpeed;

    [Header("Checks for what kind of switches or button has triggered")]
    [SerializeField]
    bool isSwitch = false, isLaser = false;
    [SerializeField]
    bool isReleased = false;

    // Update is called once per frame
    void Update()
    {
        if (startMoving)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, moveSpeed * Time.deltaTime);
        }

        if (transform.localPosition == targetPosition)
        {

            if (isReleased)
            {
                startMoving = false;
                isReleased = false;
            }

            if (transform.localPosition == startPosition)
            {
                isMovingTowardsOriginalPos = false;
                targetPosition = endPosition;
            }
            else if (transform.localPosition == endPosition)
            {
                isMovingTowardsOriginalPos = true;
                targetPosition = startPosition;
            }

            updatedStart = transform.localPosition;
        }

        #region oldcode
        //if (transform.localPosition == targetPosition)
        //{
        //    startMoving = false;

        //    if (transform.localPosition == startPosition)
        //    {
        //        isMovingTowardsOriginalPos = false;
        //    }
        //    else if (transform.localPosition == endPosition)
        //    {
        //        isMovingTowardsOriginalPos = true;
        //    }

        //    updatedStart = transform.localPosition;
        //}
        //else
        //{
        //    print("else condition");
        //}
        #endregion
    }


    public void onStartMove(object sender, EventTriggerSet.eventTrigger e)
    {
        if (e.typeOfEventTrigger == EventTriggerSet.typeOfTrigger.laser)
        {
            isLaser = true;
        }
        else
        {
            isSwitch = true;
        }
        print("Type of event pressed " + e.typeOfEventTrigger);

        if (!isMovingTowardsOriginalPos)
        {

            targetPosition = endPosition;
            updatedStart = startPosition;
        }
        else
        {

            targetPosition = startPosition;
            updatedStart = endPosition;
        }
        startMoving = true;

     
    }
  
    public void Release(object sender, EventTriggerSet.eventTrigger e)
    {
        print("Type of event released " + e.typeOfEventTrigger);
        if (e.typeOfEventTrigger == EventTriggerSet.typeOfTrigger.laser)
        {
            isLaser = false;
        }
        else
        {
            isSwitch = false;
        }
        if (transform.localPosition != startPosition || transform.localPosition != endPosition)
        {
        
            targetPosition = updatedStart;
            startMoving = true;
            if (!isSwitch && !isLaser)
                isReleased = true;
        }
        else
        {
            if(!isSwitch && !isLaser)
            startMoving = false;
           
        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.parent = transform;
    }



    public void OnCollisionExit(Collision collision)
    {
        collision.gameObject.transform.parent = null;
    }
}
