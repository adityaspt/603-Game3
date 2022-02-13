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


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (startMoving)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, moveSpeed * Time.deltaTime);
        }
        if (transform.localPosition == targetPosition)
        {
            startMoving = false;
            //if (!isMovingTowardsOriginalPos)
            //{
            //    isMovingTowardsOriginalPos = true;
            //}

            if (transform.localPosition == startPosition)
            {
                isMovingTowardsOriginalPos = false;
            }
            else if(transform.localPosition == endPosition)
            {
                isMovingTowardsOriginalPos = true;
            }


            //isAtTargetPosition = true;
            updatedStart = transform.localPosition;
        }
    }

    // 4.58,-3.8,12.19

    public void onStartMove(object sender, EventArgs e)
    {
        if (!isMovingTowardsOriginalPos)
        {
           // isMovingTowardsOriginalPos = false;
            targetPosition = endPosition;
            updatedStart = startPosition;
        }
        else
        {
            print("start in y");
           // isMovingTowardsOriginalPos = true;
            targetPosition = startPosition;
            updatedStart = endPosition;
        }
        startMoving = true;
        //isAtTargetPosition = false;
        print("pressed");
    }

    public void Release(object sender, EventArgs e)
    {
        if (transform.localPosition != startPosition || transform.localPosition != endPosition)
        {
            print("release");
            targetPosition = updatedStart;
            startMoving = true;
        }
        else
        {
            print("No release needed");
        }
       
    }
}
