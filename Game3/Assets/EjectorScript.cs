using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjectorScript : MonoBehaviour
{
	public Rigidbody triggerObject;

	private void OnTriggerEnter(Collider other)
	{

		if (other.tag == "SpherePlayer")
		{
			Debug.Log("Ejector Triggered by: " + other.name);
			triggerObject = other.attachedRigidbody;
			GetComponentInParent<Animator>().enabled = true;
			GetComponentInParent<Animator>().Play("EjectorAnim", -1, 0);
		}
		
	}

	private void OnTriggerExit(Collider other)
	{
		Debug.Log("Ejector Triggered by: " + other.name);
		//triggerObject = other.attachedRigidbody;
		GetComponentInParent<Animator>().Play("EjectorAnim", -1, 1);
	}

	public void AddForce()
	{
		if (transform.name != "EjectorTrigger")
		{
			transform.GetChild(0).gameObject.GetComponent<EjectorScript>().triggerObject.AddForce(Vector3.up * 6, ForceMode.Impulse);
			//triggerObject.AddForce(Vector3.up * 10000, ForceMode.Impulse);
		}
		
	}
}
