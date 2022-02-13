using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField]
    private KeyCode jumpKey;

    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private float jumpPower;

    [SerializeField]
    private bool isGrounded;

    [SerializeField]
    private Transform groundChecker;

    [SerializeField]
    private float checkGroundRadius;

    [SerializeField]
    private LayerMask groundLayer;

    private Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * Time.deltaTime * moveSpeed);

        isGrounded = CheckIfGrounded();

        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            rb.AddForce(new Vector3(0,1,0) * jumpPower, ForceMode.Impulse);
            isGrounded = false;
        }

    }


    bool CheckIfGrounded()
    {
        // Collider[] collider = Physics.OverlapSphere(groundChecker.position, checkGroundRadius, groundLayer);
        isGrounded = Physics.CheckSphere(groundChecker.position, checkGroundRadius, groundLayer);
        return isGrounded;
    }

}
