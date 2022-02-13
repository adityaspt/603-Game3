using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }


    private void FixedUpdate()
    {
        float movementHorizontal = Input.GetAxis("HorizontalArrow");
        float movementVertical = Input.GetAxis("VerticalArrow");

        Vector3 movement = new Vector3(movementHorizontal, 0.0f, movementVertical);

        rb.AddForce(movement * speed);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
