using System.Collections; 
using System.Collections.Generic; 
using UnityEngine;
using UnityEngine.InputSystem;
public class Left_TeleporterBehavior : MonoBehaviour
{
    private bool canTeleport = false;
    private bool pointerVisible = false;
    private Vector3 destinationPoint;
    public float maxDistance;
    public LineRenderer lineRenderer;
    public GameObject player;
    public string floorTag="Floor";
    public Material red;
    public Material blue;

    private void Start()
    {
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
    private void Teleport()
    {
        if (player)
        {
            player.transform.position = destinationPoint;
        }
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

                if (hit.collider.gameObject.CompareTag(floorTag))
                {
                    lineRenderer.material = blue;
                    canTeleport = true;
                    destinationPoint = hit.point;
                }
                else
                {
                    lineRenderer.material = red;
                    canTeleport = false;
                }

            }
            else
            {
                lineRenderer.SetPosition(1, transform.position + transform.forward * maxDistance);
            }
        }
    }
}


