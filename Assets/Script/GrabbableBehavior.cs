using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class GrabbableBehavior : MonoBehaviour
{
    private Rigidbody rigidbody;
    private GameObject grabber;
    private bool wasKinematic;
    private bool isHeld = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        wasKinematic = rigidbody.isKinematic;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TryGrab(GameObject grabber)
    {
        rigidbody.isKinematic = true;
        transform.parent = grabber.transform;
        this.grabber = grabber;
        isHeld = true;
    }

    public void TryRelease(GameObject grabber)
    {
        if (grabber.Equals(this.grabber) && isHeld)
        {
            transform.parent = null;
            rigidbody.isKinematic = wasKinematic;
            isHeld = false;
        }
    }
}
