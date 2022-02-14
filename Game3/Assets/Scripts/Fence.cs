using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    Vector3 startPosition;

    [SerializeField]
    Vector3 endPosition;

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
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, endPosition, moveSpeed * Time.deltaTime);
        if (transform.localPosition == endPosition)
        {
            isStarted = false;
        }
    }

    public void StartFenceMove(object sender, EventArgs e)
    {
        isStarted = true;
    }
}
