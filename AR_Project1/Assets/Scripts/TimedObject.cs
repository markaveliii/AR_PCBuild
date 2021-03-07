using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class TimedObject : MonoBehaviour
{
    [System.Serializable]
    public struct Endpoint {
    public double start;
    public double end;
    }

    public Endpoint[] endpoints;

    private int index;
    private Renderer rend;
    private VideoPlayer videoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        index = endpoints.Length - 1;
        rend = GetComponent<Renderer>();
        videoPlayer = GetComponentInParent<VideoPlayer>();

        Debug.Log("do inactive objects run script?");
        rend.enabled = false;
        gameObject.layer = 8;
    }

    // Update is called once per frame
    void Update()
    {
        if (index >= 0)
        {
            var time = videoPlayer.time;
            var endpoint = endpoints[index];
            if (time >= endpoint.start)
            {
                if (time >= endpoint.end)
                {
                    rend.enabled = false;
                    gameObject.layer = 8;
                    --index;
                }
                else
                {
                    rend.enabled = true;
                    gameObject.layer = 0;
                }
            }

        }
    }
}
