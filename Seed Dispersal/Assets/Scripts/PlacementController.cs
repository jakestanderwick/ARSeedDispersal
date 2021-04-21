using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]

public class PlacementController : MonoBehaviour
{
    [SerializeField]
    private GameObject placedPrefab;

    [SerializeField]
    private GameObject instructions;

    [SerializeField]
    private Camera arCamera;

    [SerializeField]
    private ARRaycastManager aRRaycastManager;
    private bool onTouchHold = false;
    public bool onMapTouch = false;
    bool mapLowered = true;
    public GameObject SeedSearchPlane;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    public GameObject PlacedPrefab
    {
        get{
            return placedPrefab;
        }
        set{
            placedPrefab = value;
        }
    }

    private ARRaycastManager arRaycastManager;

    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }

    void Update()
    {
        
        if(!TryGetTouchPosition(out Vector2 touchPosition))
            return;
        
        // if(arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        // {
        //     var hitPose = hits[0].pose;

        //     Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
        // }


        if(Input.touchCount > 0)
        {
            Debug.Log(Input.touchCount);
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;

            if(touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touchPosition);
                RaycastHit hitObject;
                if(Physics.Raycast(ray, out hitObject))
                {
                    if(hitObject.transform.name.Contains("SeedSearchMap"))
                    {
                        //onTouchHold = true;
                        //onMapTouch = true;
                        ManageMap();
                        Debug.Log("Made it to map switching");
                    }
                }
            }
            if(touch.phase == TouchPhase.Ended)
            {
                onTouchHold = false;
            }
            // if(onTouchHold)
            // {
            //     //placedObject.transform.position = hitPose.position;
            //     //same with
            // }
        }

    }

    public virtual void OnTouch()
    {

    }

    void ManageMap()
    {
        //if(onMapTouch == true)
        //{
            if(mapLowered == true)
            {
                BringUpMap();
            }
            if(mapLowered == false)
            {
                LowerMap();
            }
            onMapTouch = false;
        //}
        
    }
    void BringUpMap()
    {
        SeedSearchPlane.transform.position = new Vector3(0f, -0.78f, 3.83f);
        SeedSearchPlane.transform.rotation = new Quaternion(75.829f, 181.165f, 0f, 0f);
        mapLowered = false;
    }

    void LowerMap()
    {
        SeedSearchPlane.transform.position = new Vector3(-0.043f, -1.836f, 2.207f);
        SeedSearchPlane.transform.rotation = new Quaternion(24.304f, 181.165f, 0f, 0f);
        mapLowered = true;
    }

    
}

