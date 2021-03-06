using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Video;

public class VirtualButton_Play : MonoBehaviour
{
    public GameObject playerObj;

    public VideoPlayer videoplayer;

    public Renderer buttonRenderer;

    private VirtualButtonBehaviour[] virtualButtonBehaviours;

    private readonly Color red = new Color(1, 0 , 0, 0.5f);
    private readonly Color green = new Color(0, 1, 0, 0.5f);

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        buttonRenderer.material.color = red;
        Debug.Log($"<color=green> {vb.VirtualButtonName} pressed</color>");
        if (playerObj.activeSelf)
        {
            videoplayer.Pause();
            playerObj.SetActive(false);
        }
        else
        {
            playerObj.SetActive(true);
            videoplayer.Play();
        }
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

        foreach (var vb in virtualButtonBehaviours)
        {
            vb.RegisterOnButtonPressed(OnButtonPressed);
            vb.RegisterOnButtonReleased(OnButtonReleased);
            //vb.OnTrackerUpdated(true);
            //vb.UpdateAreaRectangle();
            //vb.UpdatePose();
            //vb.UpdateSensitivity();

            Debug.Log($"<color=yellow> {vb.VirtualButtonName} ready and {vb.Pressed}</color> ");
        }

        buttonRenderer.material.color = green;

        playerObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
