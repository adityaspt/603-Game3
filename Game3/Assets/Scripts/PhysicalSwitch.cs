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
    public event EventHandler<EventTriggerSet.eventTrigger> onPressed;
    public event EventHandler<EventTriggerSet.eventTrigger> onReleased;

    public GameManager gameManager;

    //controlled object

    [SerializeField]
    bool isControllingMovingPlatform = false, isControllingGate = false;

    [SerializeField]
    MovingPlatform[] movingPlatforms;

    [SerializeField]
    Fence movingFence;

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
        if (isControllingMovingPlatform)
        {
            for(int i = 0; i < movingPlatforms.Length; i++)
            {
                onPressed += movingPlatforms[i].onStartMove;
           
                onReleased += movingPlatforms[i].Release;
            }
            
        }
        else if (isControllingGate)
        {
            onPressed += movingFence.StartFenceMove;
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
            for (int i = 0; i < movingPlatforms.Length; i++)
            {
                onPressed -= movingPlatforms[i].onStartMove;
                onReleased -= movingPlatforms[i].Release;
            }

        }
        else if (isControllingGate)
        {
            onPressed -= movingFence.StartFenceMove;
        }
        else
        {
            Debug.LogWarning("Set the booleans correct in the inspector");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //buttonTopRigid.AddForce(buttonTop.transform.up * force * Time.deltaTime);
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
        {
            Pressed();
        }
        if (!isPressed && prevPressedState != isPressed)
        {
            Released();
        }
    }



    void Pressed()
    {
        prevPressedState = isPressed;
        onPressed?.Invoke(this, new EventTriggerSet.eventTrigger { typeOfEventTrigger = EventTriggerSet.typeOfTrigger.switchButton });
        if (gameManager != null)
        {
            gameManager.AutoSaveCheckpoint();
        }
    }

    void Released()
    {
        prevPressedState = isPressed;
        onReleased?.Invoke(this, new EventTriggerSet.eventTrigger { typeOfEventTrigger = EventTriggerSet.typeOfTrigger.switchButton });
    }
}
