using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class PhysicalSwitch : MonoBehaviour
{


    public Rigidbody buttonTopRigid;
    public Transform buttonTop;
    public Transform buttonLowerLimit;
    public Transform buttonUpperLimit;
    public float threshHold;
    public float force = 10;
    private float upperLowerDiff;
    public bool isPressed;
    private bool prevPressedState;
    public Collider[] CollidersToIgnore;
    public event EventHandler onPressed;
    public event EventHandler onReleased;

    //controlled object

    [SerializeField]
    bool isControllingMovingPlatform=false, isControllingGate=false;

    [SerializeField]
    MovingPlatform movingPlatform;

    // Start is called before the first frame update
    void Start()
    {
        Collider localCollider = GetComponent<Collider>();
        if (localCollider != null)
        {
            Physics.IgnoreCollision(localCollider, buttonTop.GetComponentInChildren<Collider>());

            foreach (Collider singleCollider in CollidersToIgnore)
            {
                Physics.IgnoreCollision(localCollider, singleCollider);
                Physics.IgnoreCollision(buttonTop.GetComponentInChildren<Collider>(), singleCollider);
            }
        }

        if (transform.eulerAngles != Vector3.zero)
        {
            Vector3 savedAngle = transform.eulerAngles;
            transform.eulerAngles = Vector3.zero;
            upperLowerDiff = buttonUpperLimit.position.y - buttonLowerLimit.position.y;
            transform.eulerAngles = savedAngle;
        }
        else
            upperLowerDiff = buttonUpperLimit.position.y - buttonLowerLimit.position.y;
    }


    private void OnEnable()
    {
        onPressed += movingPlatform.onStartMove;
        onReleased += movingPlatform.Release;
    }

    private void OnDisable()
    {
        onPressed -= movingPlatform.onStartMove;
        onReleased -= movingPlatform.Release;
    }

    // Update is called once per frame
    void Update()
    {
        buttonTopRigid.AddForce(buttonTop.transform.up * force * Time.deltaTime);
        buttonTop.transform.localPosition = new Vector3(0, buttonTop.transform.localPosition.y, 0);
        buttonTop.transform.localEulerAngles = new Vector3(0, 0, 0);
        if (buttonTop.localPosition.y >= 0)
            buttonTop.transform.position = new Vector3(buttonUpperLimit.position.x, buttonUpperLimit.position.y, buttonUpperLimit.position.z);
        else
            buttonTopRigid.AddForce(buttonTop.transform.up * force * Time.deltaTime);

        if (buttonTop.localPosition.y <= buttonLowerLimit.localPosition.y)
            buttonTop.transform.position = new Vector3(buttonLowerLimit.position.x, buttonLowerLimit.position.y, buttonLowerLimit.position.z);


        if (Vector3.Distance(buttonTop.position, buttonLowerLimit.position) < upperLowerDiff * threshHold)
            isPressed = true;
        else
            isPressed = false;

        if (isPressed && prevPressedState != isPressed)
            Pressed();
        if (!isPressed && prevPressedState != isPressed)
            Released();
    }

    

    void Pressed()
    {
        prevPressedState = isPressed;
        onPressed?.Invoke(this, EventArgs.Empty);
    }

    void Released()
    {
        prevPressedState = isPressed;
        onReleased?.Invoke(this, EventArgs.Empty);
    }
}
