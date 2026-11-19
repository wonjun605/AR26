using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class DrawLines : MonoBehaviour
{
    public LineSettings lineSettings;
    public Camera arCam;

    Dictionary<int, ARLine> lines = new Dictionary<int, ARLine>();

    ARPlaneManager arPlaneManager;
    bool initialized = false;
    bool canDraw = false;
    bool isStarting = false;
    int lineCount = -1;

    void Awake()
    {
        arPlaneManager = GetComponent<ARPlaneManager>();
        arPlaneManager.planesChanged += PlaneChanged;
    }

    void PlaneChanged(ARPlanesChangedEventArgs args)
    {
        if(!initialized)
        {
            initialized = true;
        }
    }

    public void AllowDraw(bool isAllow)
    {
        if(!initialized) return;
        canDraw = isAllow;
        if(canDraw) isStarting = true;
    
    }
    // Update is called once per frame
    void Update()
    {
        DrawLine();
    }

    void DrawLine()
    {
        if(!canDraw) return;
        Vector3 drawPosition = arCam.ScreenToWorldPoint(
            new Vector3(Screen.width/2, Screen.height/2, 0.2f);

            if(isStarting)
        {
            ARLine line = new ARLine(lineSettings);
            lineCount++;
            lines.Add(lineCount, line);
            line.AddNewLineRenderer(transform, drawPosition);
        }
        else
        {
            lines[lineCount].AddPoint(drawPosition);
        }
        )
    }
}   

