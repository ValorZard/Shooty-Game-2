/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Private variables
        // Approximate time for the camera to refocus
        [SerializeField] private float m_DampTime = 0.2f;
        // Space between the top/bottom most target and the screen edge
        [SerializeField] private float m_ScreenEdgeBuffer = 1.5f;
        // The smallest orthographic size the camera can be
        [SerializeField] private float m_MinSize = 5f;
        // All the targets the camera needs to encompass
        [SerializeField] private Transform[] m_Targets = new Transform[0];
        // Used for referencing the camera
        private Camera m_Camera;
        // Reference speed for the smooth damping of the orthographic size
        private float m_ZoomSpeed;
        // Reference velocity for the smooth damping of the position
        private Vector3 m_MoveVelocity;
        // The position the camera is moving towards
        private Vector3 m_DesiredPosition;
        // Limit to how far away the player can scope
        [SerializeField] private float m_ScopeLimit = 5;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the camera
        m_Camera = GetComponentInChildren<Camera>();
    }

    private void FixedUpdate()
    {
        // Only run if the targets exist
        if(m_Targets.Length != 0)
        {
            // Move the camera towards a desired position
            Move();

            // Change the size of the camera based
            Zoom();
        }
        // Otherwise, find the targets
        else
        {
            List<GameObject> list = GetComponent<FindEntities>().GetPlayers();
            m_Targets = new Transform[list.Count];
            for(int z = 0; z < list.Count; z++)
                m_Targets[z] = list[z].transform;
        }
    }

    private void Move()
    {
        // Find the average position of the targets
        FindAveragePosition();

/* Removed scoping
        // Only run if there's a limit
        if(m_ScopeLimit != 0)
        {
            // If there are any targets scoping ahead, assign the desired position to the mouse cursor
            if(Input.GetAxisRaw("Fire1") < 0 || Input.GetAxisRaw("Fire2") < 0 || Input.GetAxisRaw("Fire2XBOX") < 0)
            {
                // Mouse position
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                // Impose limits on how far the player can scope
                if(Mathf.Abs(Mathf.Abs(mousePos.x) - Mathf.Abs(m_DesiredPosition.x)) > Mathf.Abs(m_ScopeLimit)
                    || Mathf.Abs(mousePos.x) > Mathf.Abs(m_ScopeLimit))
                {
                    if((mousePos.x > 0 && m_DesiredPosition.x > 0 && mousePos.x > m_DesiredPosition.x)
                        || (mousePos.x > 0 && m_DesiredPosition.x < 0)
                        || (mousePos.x < 0 && m_DesiredPosition.x < 0 && mousePos.x > m_DesiredPosition.x))
                    {
                        mousePos.x = m_ScopeLimit;
                    }
                    else if((mousePos.x < 0 && m_DesiredPosition.x < 0 && mousePos.x < m_DesiredPosition.x)
                        || (mousePos.x < 0 && m_DesiredPosition.x > 0)
                        || (mousePos.x > 0 && m_DesiredPosition.x > 0 && mousePos.x < m_DesiredPosition.x))
                    {
                        mousePos.x = -m_ScopeLimit;
                    }
                }
                else if(mousePos.x > m_DesiredPosition.x)
                {
                    mousePos.x = m_ScopeLimit;
                }
                else
                {
                    mousePos.x = -m_ScopeLimit;
                }
                
                if(Mathf.Abs(Mathf.Abs(mousePos.y) - Mathf.Abs(m_DesiredPosition.y)) > Mathf.Abs(m_ScopeLimit)
                    || Mathf.Abs(mousePos.y) > Mathf.Abs(m_ScopeLimit))
                {
                    if((mousePos.y > 0 && m_DesiredPosition.y > 0 && mousePos.y > m_DesiredPosition.y)
                        || (mousePos.y > 0 && m_DesiredPosition.y < 0)
                        || (mousePos.y < 0 && m_DesiredPosition.y < 0 && mousePos.y > m_DesiredPosition.y))
                    {
                        mousePos.y = m_ScopeLimit;
                    }
                    else if((mousePos.y < 0 && m_DesiredPosition.y < 0 && mousePos.y < m_DesiredPosition.y)
                        || (mousePos.y < 0 && m_DesiredPosition.y > 0)
                        || (mousePos.y > 0 && m_DesiredPosition.y > 0 && mousePos.y < m_DesiredPosition.y))
                    {
                        mousePos.y = -m_ScopeLimit;
                    }
                }
                else if(mousePos.y > m_DesiredPosition.y)
                {
                    mousePos.y = m_ScopeLimit;
                }
                else
                {
                    mousePos.y = -m_ScopeLimit;
                }

                // Assign the limited position
                m_DesiredPosition += new Vector3(mousePos.x, mousePos.y, 0);
            }
        }
*/

        // Smoothly transition to that position
        m_Camera.transform.position = Vector3.SmoothDamp(m_Camera.transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
    }

    private void FindAveragePosition()
    {
        Vector3 averagePos = new Vector3();
        int numTargets = 0;

        // Go through all the targets and add their positions together
        for(int i = 0; i < m_Targets.Length; i++)
        {
            // If the target isn't active, go on to the next one
            if(!m_Targets[i].gameObject.activeSelf)
                continue;
            
            // Add to the average and increment the number of targets in the average
            averagePos += m_Targets[i].position;
            numTargets++;
        }

        // If there are targets, divide the sum of the positions by the number of them to find the average
        if(numTargets > 0)
            averagePos /= numTargets;
        
        // Keep the same z value
        averagePos.z = m_Camera.transform.position.z;

        // The desired position is the average position
        m_DesiredPosition = averagePos;
    }

    private void Zoom()
    {
        // Find the required size based on the desired position and smoothly transition to that size
        float requiredSize = FindRequiredSize();
        m_Camera.orthographicSize = Mathf.SmoothDamp(m_Camera.orthographicSize,requiredSize, ref m_ZoomSpeed, m_DampTime);
    }
    
    private float FindRequiredSize()
    {
        // Find the position the camera rig is moving towards in its local space
        Vector3 desiredLocalPos = m_Camera.transform.InverseTransformPoint(m_DesiredPosition);

        // Start the camera's size calculation at zero
        float size = 0f;

        // Go through all the targets...
        for(int i = 0; i < m_Targets.Length; i++)
        {
            // ... and if they aren't active, continue on to the next target
            if(!m_Targets[i].gameObject.activeSelf)
                continue;
            
            // Otherwise, find the position of the target in the camera's local space
            Vector3 targetLocalPos = m_Camera.transform.InverseTransformPoint(m_Targets[i].position);

            // Find the position of the target from the desired position of the camera's local space
            Vector3 desiredPosToTarget = targetLocalPos - desiredLocalPos;

            // Choose the largest out of the current size and the distance of the player "up" or "down" from the camera
            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.y));

            // Choose the largest out of the current size and the calculated size based on the player being to the left or right of the camera
            size = Mathf.Max(size, Mathf.Abs(desiredPosToTarget.x) / m_Camera.aspect);
        }

        // Add the edge buffer to the size
        size += m_ScreenEdgeBuffer;

        // Make sure the camera's size isn't below the minimum
        size = Mathf.Max(size, m_MinSize);

        return size;
    }

    public void SetStartPositionAndSize()
    {
        // Find the desired position
        FindAveragePosition();

        // Set the camera's position to the desired position without damping
        m_Camera.transform.position = m_DesiredPosition;
        
        // Find and set the required size of the camera
        m_Camera.orthographicSize = FindRequiredSize();
    }

    public void SetTargets(Transform[] targets) { m_Targets = targets; }
}
