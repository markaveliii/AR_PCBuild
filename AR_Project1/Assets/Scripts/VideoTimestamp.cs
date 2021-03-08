using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoTimestamp : MonoBehaviour
{
    private TextMesh textMesh;
    private VideoPlayer videoPlayer;
    private int prevTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMesh>();
        videoPlayer = GetComponentInParent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        double time = videoPlayer.time;
        if (time != prevTime)
        {
            textMesh.text = $"{Mathf.FloorToInt((float)(time / 60)):00}:{time % 60:00}";
            prevTime = Mathf.FloorToInt((float)time);
        }
    }
}
