using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class MultipleImageTracker : MonoBehaviour
{
    public GameObject obj1;   // "myqr" 이미지 위에 표시할 오브젝트
    public GameObject obj2;   // "namecard" 이미지 위에 표시할 오브젝트
    public TextMeshProUGUI debugText;

    ARTrackedImageManager imageManager;
    readonly Dictionary<TrackableId, GameObject> spawned = new Dictionary<TrackableId, GameObject>();

    void Awake()
    {
        imageManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        imageManager.trackablesChanged.AddListener(OnTrackablesChanged);
    }

    void OnDisable()
    {
        imageManager.trackablesChanged.RemoveListener(OnTrackablesChanged);
    }

    void OnTrackablesChanged(ARTrackablesChangedEventArgs<ARTrackedImage> args)
    {
        foreach (var image in args.added)
            UpdateImage(image);

        foreach (var image in args.updated)
            UpdateImage(image);

        foreach (var removed in args.removed)
        {
            if (spawned.TryGetValue(removed.Key, out var go) && go != null)
                Destroy(go);
            spawned.Remove(removed.Key);
        }
    }

    void UpdateImage(ARTrackedImage image)
    {
        string imageName = image.referenceImage.name;
        bool tracking = image.trackingState == TrackingState.Tracking;

        if (debugText != null && tracking)
            debugText.text = $"Tracked : {imageName}";

        // 이미지마다 오브젝트를 한 번만 생성하고, 이후에는 위치만 갱신한다.
        if (!spawned.TryGetValue(image.trackableId, out var go) || go == null)
        {
            GameObject prefab = imageName == "myqr" ? obj1 : imageName == "namecard" ? obj2 : null;
            if (prefab == null) return;
            go = Instantiate(prefab, image.transform.position, image.transform.rotation);
            spawned[image.trackableId] = go;
        }

        go.SetActive(tracking);
        if (tracking)
            go.transform.SetPositionAndRotation(image.transform.position, image.transform.rotation);
    }
}
