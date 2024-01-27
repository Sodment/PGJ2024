using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtyPlayerMovement : MonoBehaviour
{
    Rigidbody rigidbody;
    float speed;

    public List<GameObject> FreeSideRoadObjects = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        speed = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = Vector3.forward * speed;
    }
}
