using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaceCar : MonoBehaviour
{
    public GameObject marker;

    ARRaycastManager arRayManager;
    void Start()
    {
        arRayManager = GetComponent<ARRaycastManager>();
        marker.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        DetectGround();
    }
    void DetectGround()
        {
            Vector2 screencenter = new Vector2(Screen.width, Screen.height / 2);

            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if(arRayManager.Raycast(screencenter, hits, TrackableType.Planes))
        {
            
        }
        
        }
}
