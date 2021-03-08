using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Video;

public class VirtualButton_Play : MonoBehaviour
{
    public GameObject videoPlayerObj;
    public Renderer buttonRenderer;
    public Material playButtonMat;
    public Material pauseButtonMat;

    private VirtualButtonBehaviour[] virtualButtonBehaviours;
    private VideoPlayer videoplayer;

#pragma warning disable IDE0090 // Use 'new(...)'
    private readonly Color red = new Color(1, 0, 0, 0.5f);
    private readonly Color green = new Color(0, 1, 0, 0.5f);
#pragma warning restore IDE0090 // Use 'new(...)'

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log($"<color=green> {vb.VirtualButtonName} pressed</color>");
        if (videoplayer.isPlaying)
        {
            videoplayer.Pause();
            buttonRenderer.material = playButtonMat;
            //playerObj.SetActive(false);
        }
        else
        {
            videoPlayerObj.SetActive(true);
            videoplayer.Play();
            buttonRenderer.material = pauseButtonMat;
        }
        buttonRenderer.material.color = red;
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        buttonRenderer.material.color = green;
        Debug.Log($"<color=yellow> {vb.VirtualButtonName} released</color>");
    }

    // Start is called before the first frame update
    void Start()
    {
        virtualButtonBehaviours = GetComponentsInChildren<VirtualButtonBehaviour>();
        videoplayer = videoPlayerObj.GetComponent<VideoPlayer>();

        foreach (var vb in virtualButtonBehaviours)
        {
            vb.RegisterOnButtonPressed(OnButtonPressed);
            vb.RegisterOnButtonReleased(OnButtonReleased);

            Debug.Log($"<color=yellow> {vb.VirtualButtonName} ready and {vb.Pressed}</color> ");
        }

        playButtonMat.color = green;
        pauseButtonMat.color = green;

    }

    // Update is called once per frame
    //void Update()
    //{
    //}
}
