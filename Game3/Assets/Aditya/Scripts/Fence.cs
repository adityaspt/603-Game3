using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fence : MonoBehaviour
{

    [SerializeField]
    float moveSpeed;

    [SerializeField]
    Vector3 startPosition;
    [SerializeField]
    Vector3 endPosition;

    [SerializeField]
    Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPosition, moveSpeed * Time.deltaTime);
    }
}
