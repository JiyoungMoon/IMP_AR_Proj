using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceManager : MonoBehaviour
{
    [SerializeField] private PlaceIndicator placeIndicator;
    [SerializeField] private GameObject ObjectToPlace;

    void Start()
    {
    }

    public void ClickToPlace()
    {
        if (placeIndicator.isActive())
        {
            placeIndicator = FindObjectOfType<PlaceIndicator>();
            Vector3 rotation = placeIndicator.transform.rotation.eulerAngles;
            Instantiate(ObjectToPlace, placeIndicator.transform.position, new Quaternion(0f, rotation.y, 0f, 0f));

            GameManager._instance.ClickButtonPlace();
        }
    }
}
