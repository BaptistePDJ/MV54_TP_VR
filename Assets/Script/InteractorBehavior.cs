using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class InteractorBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnGrabAction(InputAction.CallbackContext context)
    {
        GameObject nearestGrabbable = GetNearestGrabbable();
        if (nearestGrabbable)
        {
            if (context.started)
            {
                nearestGrabbable.GetComponent<GrabbableBehavior>().TryGrab(gameObject);
            }
            if (context.canceled)
            {
                nearestGrabbable.GetComponent<GrabbableBehavior>().TryRelease(gameObject);
            }
        }
    }

    Dictionary<string, GameObject> overlappingGameObjects = new Dictionary<string, GameObject>();
    private void OnTriggerEnter(Collider other)
    {
        overlappingGameObjects.Add(other.gameObject.name, other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        overlappingGameObjects.Remove(other.gameObject.name);
    }
    private GameObject GetNearestGrabbable()
    {
        GameObject nearestGrabbable = null;
        float minDistance = Mathf.Infinity;

        foreach (KeyValuePair<string, GameObject> kvp in overlappingGameObjects)
        {
            if (kvp.Value.GetComponent<GrabbableBehavior>())
            {
                float distance = Vector3.Distance(transform.position, kvp.Value.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestGrabbable = kvp.Value;
                }
            }
        }
        return nearestGrabbable;
    }

}
