using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LaserButton : MonoBehaviour
{
    //[SerializeField]
    //bool startAction = false;

    //[SerializeField]
    //bool exitAction = false;

    [SerializeField]
    MovingPlatform movingPlatformObj;

    public event EventHandler onPressed;

    public event EventHandler onReleased;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnEnable()
    {
        onPressed += movingPlatformObj.onStartMove;
        onReleased += movingPlatformObj.Release;
    }

    private void OnDisable()
    {
        onPressed -= movingPlatformObj.onStartMove;
        onReleased -= movingPlatformObj.Release;
    }

    // Update is called once per frame
    void Update()
    {
     
    }


    private void OnTriggerEnter(Collider other)
    {
        onPressed?.Invoke(this, EventArgs.Empty);
    }
    private void OnTriggerExit(Collider other)
    {
        onReleased?.Invoke(this, EventArgs.Empty);
    }


  
}
