using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using UnityEngine.Video;

public class VirtualButton_Play : MonoBehaviour
{
    public Renderer playPauseRenderer;
    public Material playButtonMat;
    public Material pauseButtonMat;

    private VirtualButtonBehaviour[] virtualButtonBehaviours;
    private VideoPlayer videoplayer;

#pragma warning disable IDE0090 // Use 'new(...)'
    private readonly Color red = new Color(1, 0, 0, 0.75f);
    private readonly Color green = new Color(0, 1, 0, 0.75f);
#pragma warning restore IDE0090 // Use 'new(...)'

    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        //Renderer buttonRenderer = vb.GetComponentInChildren<Renderer>();
        Debug.Log($"<color=green> {vb.VirtualButtonName} pressed</color>");
        if (vb.VirtualButtonName == "PlayPause")
        {
            if (videoplayer.isPlaying)
            {
                videoplayer.Pause();
                playPauseRenderer.material = playButtonMat;
                //playerObj.SetActive(false);
            }
            else
            {
                //videoPlayerObj.SetActive(true);
                videoplayer.Play();
                //buttonRenderer.material = pauseButtonMat;
            }
            //playPauseRenderer.material.color = red;
        }

        if (vb.VirtualButtonName == "Restart")
        {
            bool wasPlaying = videoplayer.isPlaying;
            videoplayer.Stop();
            if (wasPlaying)
                videoplayer.Play();
            //restartRenderer.material.color = red;
            var timedObjects = GetComponentsInChildren<TimedObject>();

            foreach (var timedObj in timedObjects)
            {
                timedObj.Restart();
            }
        }
        vb.GetComponentInChildren<Renderer>().material.color = red;
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        Debug.Log($"<color=yellow> {vb.VirtualButtonName} released</color>");
        vb.GetComponentInChildren<Renderer>().material.color = green;
    }

    // Start is called before the first frame update
    void Start()
    {
        virtualButtonBehaviours = GetComponentsInChildren<VirtualButtonBehaviour>();
        videoplayer = GetComponentInChildren<VideoPlayer>();

        foreach (var vb in virtualButtonBehaviours)
        {
            vb.RegisterOnButtonPressed(OnButtonPressed);
            vb.RegisterOnButtonReleased(OnButtonReleased);

            Debug.Log($"<color=yellow> {vb.VirtualButtonName} on {gameObject.name} initialized</color> ");
        }

        playButtonMat.color = green;
        pauseButtonMat.color = green;
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (videoplayer.isPaused)
    //    {
    //        buttonRenderer.material = playButtonMat;
    //    }
    //}

    public void OnTargetLost()
    {
        playPauseRenderer.material = playButtonMat;
    }
}
