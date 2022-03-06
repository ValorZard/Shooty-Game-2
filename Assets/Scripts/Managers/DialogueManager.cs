using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Srayan Jana - main coder

public class DialogueManager : MonoBehaviour
{
    //public string jsonString;
    public GameObject textMesh;
    // Start is called before the first frame update
    void Start()
    {
        //jsonString = "";
        //textMesh = GameObject.Find("Text").GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPressed()
    {
        //Debug.Log("AHHHHHH");
        textMesh.GetComponent<Text>().text = "pog";
    }
}
