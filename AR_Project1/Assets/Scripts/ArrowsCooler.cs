using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ArrowsCooler : MonoBehaviour
{

    TextMesh textMesh;

    private VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        textMesh = GetComponentInChildren<TextMesh>();
    }

    // Update is called once per frame
    void Update()
    {
        if (videoPlayer.time > 10)
            Debug.Log("10 second mark");

        if (textMesh == null) return;

        double time = videoPlayer.time;
        textMesh.text = $"{Mathf.FloorToInt((float)(time / 60)):00}:{time % 60:00}";
    }
}