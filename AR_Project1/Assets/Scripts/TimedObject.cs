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

    private int remaining;
    private Renderer rend;
    private VideoPlayer videoPlayer;
    private bool disabled = true;

    // Start is called before the first frame update
    void Start()
    {
        remaining = endpoints.Length;
        rend = GetComponent<Renderer>();
        videoPlayer = GetComponentInParent<VideoPlayer>();

        Debug.Log("do inactive objects run script?");
        rend.enabled = false;
        gameObject.layer = 8;
    }

    // Update is called once per frame
    void Update()
    {
        if (remaining > 0)
        {
            var time = videoPlayer.time;
            var endpoint = endpoints[endpoints.Length - remaining];
            if (time >= endpoint.start)
            {
                if (time >= endpoint.end)
                {
                    rend.enabled = false;
                    gameObject.layer = 8;
                    disabled = true;
                    --remaining;
                }
                else if (disabled)
                {
                    rend.enabled = true;
                    gameObject.layer = 0;
                    disabled = false;
                }
            }
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
