/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerCenter : MonoBehaviour
{
    // Private variables
        // The targets the camera has to focus on
        private Transform[] m_Targets = new Transform[0];
        // Reference to the camera
        private Camera m_Camera;

    // Start is called before the first frame update
    void Start()
    {
        // Grab the camera
        m_Camera = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Only run if the targets exist
        if(m_Targets.Length != 0)
        {
            // Move the cmaera towards a desired position
            Move();

            // Change the size of the camera
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
        // Average of the targets' positions
        Vector3 averagePos = new Vector3();
        int numTargets = 0;

        // Go through the targets
        foreach(Transform target in m_Targets)
        {
            // Only run if the target is active
            if(target.gameObject.activeSelf)
            {
                // Get the target's position
                averagePos += target.position;
                numTargets++;
            }
        }

        // Only run if there are targets
        if(numTargets > 0)
            averagePos /= numTargets;
        
        // Keep the same z value
        averagePos.z = m_Camera.transform.position.z;

        // Set the camera's position
        m_Camera.transform.position = averagePos;
    }

    private void Zoom()
    {}

    public void SetTargets(Transform[] targets) { m_Targets = targets; }
}
