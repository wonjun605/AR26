using System.Runtime.CompilerServices;
using UnityEngine;

public class PlaceSphare : MonoBehaviour
{
    public GameObject spherePrefab;
    public Camera arCamera;
    public Transform parentTransform;
 
    // Update is called once per frame
    void Update()
    {
        int touchCount = Input.touchCount;
        if (touchCount < 1) return;

        Touch touch = Input.GetTouch(0);
        Vector3 touchPosition = arCamera.ScreenToWorldPoint(
            new Vector3(Input.GetTouch(0).position.x,
                        Input.GetTouch(0).position.y,
                        0.5f));

        if(touch.phase == TouchPhase.Began)
        {
            GameObject go = Instantiate(spherePrefab, touchPosition, transform.rotation);
            go.transform.parent = parentTransform;
            go.transform.position = touchPosition;
        }
    }
}
