using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    [SerializeField]
    private float speed;

    private Rigidbody rb;

    [SerializeField]
    private float jumpPower;

    [SerializeField]
    private bool isGrounded;

    [SerializeField]
    private KeyCode jumpKey;

    [SerializeField]
    private LayerMask groundLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }


    private void Update()
    {
        //float movementHorizontal = Input.GetAxis("HorizontalArrow");
        //float movementVertical = Input.GetAxis("VerticalArrow");

        //Debug.Log(movementHorizontal + " " + movementVertical);

        //Vector3 movement = new Vector3(movementHorizontal, 0.0f, movementVertical);

        //rb.AddForce(movement * speed);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.right * -speed);
            rb.AddForce(Vector3.forward * speed);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Rotate(Vector3.right * speed);
            rb.AddForce(Vector3.forward * -speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.forward * -speed);
            rb.AddForce(Vector3.right * -speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.forward * speed);
            rb.AddForce(Vector3.right * speed);
        }

        //isGrounded = CheckIfGrounded();

        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            print("sphere jump");
            rb.AddForce(new Vector3(0, 1, 0) * jumpPower, ForceMode.Impulse);
            isGrounded = false;
        }
        //else if (Input.GetKeyDown(jumpKey) && !isGrounded)
        //{
        //    print("sphere cant jump");
        //}

    }
    //bool CheckIfGrounded()
    //{
    //	// Collider[] collider = Physics.OverlapSphere(groundChecker.position, checkGroundRadius, groundLayer);
    //	isGrounded = Physics.CheckSphere(groundChecker.position, checkGroundRadius, groundLayer);
    //	return isGrounded;
    //}


    private void OnCollisionEnter(Collision collision)
    {
        if ((groundLayer & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if ((groundLayer & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            isGrounded = false;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if ((groundLayer & 1 << collision.gameObject.layer) == 1 << collision.gameObject.layer)
        {
            isGrounded = true;
        }

    }
}
