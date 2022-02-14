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
		//float movementHorizontal = Input.GetAxis("HorizontalArrow");
		//float movementVertical = Input.GetAxis("VerticalArrow");

		//Debug.Log(movementHorizontal + " " + movementVertical);

		//Vector3 movement = new Vector3(movementHorizontal, 0.0f, movementVertical);

		//rb.AddForce(movement * speed);

		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.Rotate(Vector3.right * speed);
			rb.AddForce(Vector3.forward * speed);
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.Rotate(Vector3.right * -speed);
			rb.AddForce(Vector3.forward * -speed);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Rotate(Vector3.forward * speed);
			rb.AddForce(Vector3.right * -speed);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Rotate(Vector3.forward * -speed);
			rb.AddForce(Vector3.right * speed);
		}
	}

}
