using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.InputSystem;
public class TeleporterBehavior : MonoBehaviour
{
    private bool canTeleport = false;
    private bool pointerVisible = false;
    private Vector3 destinationPoint;
    public float maxDistance;
    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        HidePointer();
    }
    void HidePointer()
    {
        if (lineRenderer)
        {
            lineRenderer.enabled = false;
        }
        pointerVisible = false;
    }
    void ShowPointer()
    {
        if (lineRenderer)
        {
            lineRenderer.enabled = true;
        }
        pointerVisible = true;
    }
    void Teleport()
    {

    }
    public void OnTeleportAction(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ShowPointer();

        }
        if (context.canceled)
        {
            if (canTeleport)
            {
                Teleport();
            }
            HidePointer();
        }
    }
    private void FixedUpdate()
    {
        if (pointerVisible)
        {
            lineRenderer.SetPosition(0, transform.position);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance))
            {
                lineRenderer.SetPosition(1, transform.position + transform.forward * hit.distance);
            }
            else
            {
                lineRenderer.SetPosition(1, transform.position + transform.forward * maxDistance);
            }
        }
    }
}


