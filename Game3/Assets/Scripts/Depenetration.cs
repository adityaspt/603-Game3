using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Depenetration : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionStay(Collision other)
    {
        Vector3 direction;
        float distance;
        bool bOverlap = Physics.ComputePenetration(
            other.collider, other.gameObject.transform.position, other.gameObject.transform.rotation,
            this.GetComponent<Collider>(), this.transform.position, this.transform.rotation, 
            out direction, out distance
            );
        if(bOverlap) other.gameObject.transform.Translate(direction * distance);
    }
}
