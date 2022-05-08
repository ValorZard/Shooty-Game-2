/*
    Programmer: Manhattan Calabro
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerSimple : MonoBehaviour
{
    // Private variables
        // The target to follow
        [SerializeField] private Transform m_Target;
        // The camera
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
        // Simply follow the target around. Nothing fancy.
        m_Camera.transform.position = new Vector3(m_Target.position.x,
                                                  m_Target.position.y,
                                                  m_Camera.transform.position.z);
    }
}
