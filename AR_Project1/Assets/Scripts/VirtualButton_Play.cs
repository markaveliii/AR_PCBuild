using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class VirtualButton_Play : MonoBehaviour, IVirtualButtonEventHandler
{

    public GameObject buttonObj;
    public GameObject playerObj;


    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("<color=green>pressed</color>");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log("<color=yellow>released</color>");
    }

    // Start is called before the first frame update
    void Start()
    {
        buttonObj = GameObject.Find("PlayButton");
        buttonObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        //buttonObject.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(OnButtonPressed);
        //buttonObject.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(OnButtonReleased);
        Debug.Log("<color=green>button ready</color>");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
