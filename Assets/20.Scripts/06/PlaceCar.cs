using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceCar : MonoBehaviour
{
    public GameObject marker;
    [SerializeField] ARRaycastManager arRayManager;
    [SerializeField] GameObject carPrefab;
    GameObject placedCar;
    readonly List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        if (arRayManager == null) arRayManager = GetComponent<ARRaycastManager>();
        if (arRayManager == null) arRayManager = FindAnyObjectByType<ARRaycastManager>();
        if (marker != null) marker.SetActive(false);
    }

    void Update()
    {
        if (arRayManager == null || marker == null) return;

        var screenCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        bool foundPlane = arRayManager.Raycast(screenCenter, hits, TrackableType.PlaneWithinPolygon);
        if (foundPlane)
        {
            var pose = hits[0].pose;
            marker.transform.SetPositionAndRotation(pose.position, pose.rotation);
        }
        marker.SetActive(foundPlane);

        var touchscreen = Touchscreen.current;
        if (!foundPlane || touchscreen == null ||
            !touchscreen.primaryTouch.press.wasPressedThisFrame) return;

        var placement = hits[0].pose;
        if (placedCar == null)
            placedCar = carPrefab != null ? Instantiate(carPrefab) : CreateDemoCar();

        placedCar.transform.SetPositionAndRotation(placement.position, placement.rotation);
    }

    static GameObject CreateDemoCar()
    {
        var car = new GameObject("AR Car");
        AddPart(car.transform, "Body", PrimitiveType.Cube,
            new Vector3(0, 0.055f, 0), new Vector3(0.12f, 0.05f, 0.22f));
        AddPart(car.transform, "Cabin", PrimitiveType.Cube,
            new Vector3(0, 0.10f, -0.02f), new Vector3(0.09f, 0.05f, 0.11f));

        foreach (float x in new[] { -0.063f, 0.063f })
        foreach (float z in new[] { -0.07f, 0.07f })
        {
            var wheel = AddPart(car.transform, "Wheel", PrimitiveType.Cylinder,
                new Vector3(x, 0.025f, z), new Vector3(0.05f, 0.012f, 0.05f));
            wheel.localRotation = Quaternion.Euler(0, 0, 90);
        }

        return car;
    }

    static Transform AddPart(Transform parent, string name, PrimitiveType shape,
        Vector3 position, Vector3 scale)
    {
        var part = GameObject.CreatePrimitive(shape);
        part.name = name;
        part.transform.SetParent(parent, false);
        part.transform.localPosition = position;
        part.transform.localScale = scale;
        return part.transform;
    }
}
