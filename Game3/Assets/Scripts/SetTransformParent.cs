using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SetTransformParent : MonoBehaviour
{
    [SerializeField]
    MovingPlatform parent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.transform.parent = parent.transform;
    }



    public void OnCollisionExit(Collision collision)
    {
        collision.gameObject.transform.parent = null;
    }
}
