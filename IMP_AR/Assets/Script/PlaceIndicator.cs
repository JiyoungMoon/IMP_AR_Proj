using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEditor.XR.ARSubsystems;
using UnityEngine.XR.ARSubsystems;

public class PlaceIndicator : MonoBehaviour
{
    private ARRaycastManager raycastManager;
    private GameObject crosshair;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Start()
    {
        raycastManager = FindObjectOfType<ARRaycastManager>();
        crosshair = transform.GetChild(0).gameObject;
        crosshair.SetActive(false);
    }

    void Update()
    {
        var ray = new Vector2(Screen.width / 2, Screen.height / 2);

        if(raycastManager.Raycast(ray, hits, TrackableType.Planes) )
        {
            Pose hitPose = hits[0].pose;

            transform.position = hitPose.position;
            transform.rotation = hitPose.rotation;

            if(!crosshair.activeInHierarchy)
            {
                crosshair.SetActive(true);
            }
        }
    }

    public bool isActive()
    {
        return (crosshair != null) && (crosshair.activeInHierarchy);
    }
}
