using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ArrowsCooler : MonoBehaviour
{
    [System.Serializable]
    public struct ArrowInfo { public GameObject arrowObject; public float start; public float end; }

    public TextMesh timestampMesh;
    public ArrowInfo[] arrowInfos;

    private VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        //timestampMesh = GetComponentInChildren<TextMesh>();
        //GameObject.FindGameObjectWithTag("timestamp");
    }

    // Update is called once per frame
    void Update()
    {
        double time = videoPlayer.time;

        if (timestampMesh != null)
        {
            timestampMesh.text = $"{Mathf.FloorToInt((float)(time / 60)):00}:{time % 60:00}";
        }

        foreach (ArrowInfo info in arrowInfos)
        {
            if (info.arrowObject != null)
            {
                var arrowObj = info.arrowObject;
                var start = info.start;
                var end = info.end;
                if (arrowObj.activeSelf)
                {
                    if (time > end)
                    {
                        arrowObj.SetActive(false);
                        Debug.Log("make invisible");
                    }
                }
                else
                {
                    if (time > start && time < end)
                    {
                        arrowObj.SetActive(true);
                        Debug.Log("make visible");
                    }
                }
            }
        }
    }
}