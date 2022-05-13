using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighlightKeys : MonoBehaviour
{

    [SerializeField] private Image keyW;
    [SerializeField] private Image keyS;
    [SerializeField] private Image keyA;
    [SerializeField] private Image keyD;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            var tempColor = keyW.color;
            tempColor.a = 1f;
            keyW.color = tempColor;
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            var tempColor = keyW.color;
            tempColor.a = 0.5f;
            keyW.color = tempColor;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            var tempColor = keyA.color;
            tempColor.a = 1f;
            keyA.color = tempColor;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            var tempColor = keyA.color;
            tempColor.a = 0.5f;
            keyA.color = tempColor;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            var tempColor = keyS.color;
            tempColor.a = 1f;
            keyS.color = tempColor;
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            var tempColor = keyS.color;
            tempColor.a = 0.5f;
            keyS.color = tempColor;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            var tempColor = keyD.color;
            tempColor.a = 1f;
            keyD.color = tempColor;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            var tempColor = keyD.color;
            tempColor.a = 0.5f;
            keyD.color = tempColor;
        }
    }
}
