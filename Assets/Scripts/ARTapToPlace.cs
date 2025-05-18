using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class ARTapToPlace : MonoBehaviour
{
    public GameObject modelPrefab;
    private GameObject spawnedObject;

    public ARRaycastManager raycastManager;
    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Update()
    {
        if (Input.touchCount == 0 || spawnedObject != null)
            return;

        Touch touch = Input.GetTouch(0);
        if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;
            spawnedObject = Instantiate(modelPrefab, hitPose.position, hitPose.rotation);
        }
    }
}
