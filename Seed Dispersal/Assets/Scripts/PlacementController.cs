using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

[RequireComponent(typeof(ARRaycastManager))]

public class PlacementController : MonoBehaviour
{
    [SerializeField]
    private GameObject placedPrefab;

    [SerializeField]
    private GameObject instructions;

    [SerializeField]
    public Camera arCamera;

    [SerializeField]
    private ARRaycastManager aRRaycastManager;
    [SerializeField]
    public RaycastHit hitObject;
    public bool onTouchHold = false;
    public bool onMapTouch = false;
    bool mapLowered = true;
    public GameObject SeedSearchPlane;
    public GameObject debugDemo;
    public Button ButtonUp;
    //public GameObject s1, s2, s3, s4, s5, s6;
    private GameObject placedObject;
    

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

    void Start()
    {
        // setOn[0] = false;
        // setOn[1] = false;
        // setOn[2] = false;
        // setOn[3] = false;
        // setOn[4] = false;
        // setOn[5] = false;
    }
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
        //arCamera.transform.position = SeedSearchPlane.transform.position;
        if(!TryGetTouchPosition(out Vector2 touchPosition))
            return;
        
        // if(arRaycastManager.Raycast(touchPosition, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        // {
        //     var hitPose = hits[0].pose;

        //     Instantiate(placedPrefab, hitPose.position, hitPose.rotation);
        // }
        // float fx = arCamera.transform.position.x - 2;
        // float fy = arCamera.transform.position.y - 2;
        // float fz = arCamera.transform.position.z - 2;

        // SeedSearchPlane.transform.position = new Vector3(fx, fy, fz);

        if(Input.touchCount > 0)
        {
            Debug.Log(Input.touchCount);
            Touch touch = Input.GetTouch(0);
            touchPosition = touch.position;

            if(touch.phase == TouchPhase.Began)
            {
                Ray ray = arCamera.ScreenPointToRay(touchPosition);
                //RaycastHit hitObject;
                if(Physics.Raycast(ray, out hitObject))
                {
                    if(hitObject.transform.name.Contains("SeedSearchMap"))
                    {
                        //onTouchHold = true;
                        //onMapTouch = true;
                        //ManageMap();
                        //float fx = arCamera.transform.position.x - 2;
                        //float fy = arCamera.transform.position.y - 2;
                        //float fz = arCamera.transform.position.z - 2;
                        // if(mapLowered == true)
                        // {

                        //     SeedSearchPlane.transform.position = new Vector3(0f, -0.71f, 3.65f);
                        //     //SeedSearchPlane.transform.position = new Vector3(arCamera.transform.position.x, 1f, arCamera.transform.position.z);
                        //     SeedSearchPlane.transform.rotation = new Quaternion(75.881f, 181.165f, 0f, 0f);
                        //     mapLowered = false;
                        // }
                        // else if(mapLowered == false)
                        // {
                        //     SeedSearchPlane.transform.position = new Vector3(-0.043f, -1.836f, 2.207f);
                        //     //SeedSearchPlane.transform.position = new Vector3(arCamera.transform.position.x, 2f, arCamera.transform.position.z);
                        //     SeedSearchPlane.transform.rotation = new Quaternion(24.304f, 181.165f, 0f, 0f);
                        //     mapLowered = true;
                        // }
                        Debug.Log("Made it to map switching");
                    }
                    // if(hitObject.transform.name.Contains("Check1"))
                    // {
                    //     //s1.gameObject.SetActive(true);
                    //     setOn[0] = true;
                    // }
                    else{
                        onTouchHold = true;
                        //arCamera.transform.position = SeedSearchPlane.transform.position;
                        //onMapTouch = true;
                        //ManageMap();
                        //Debug.Log("Made it to map switching");
                    }
                    
                    
                }
                // if((Physics.Raycast(ray, out hitObject) && (hitObject.collider.tag == "Draggable"))
                // {
                //     toDrag
                // }
            }
            if(touch.phase == TouchPhase.Moved)
            {
                touchPosition = touch.position;
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
            if(onTouchHold)
            {
                
                if(hitObject.collider != null)
                {
                    //Vector3 pos = touchPosition;

                    ////hitObject.transform.position = touch.position;


                    //hitObject.transform.position = new Vector3(1f,1f,8f);
                    //Debug.Log(hitObject.ToString());
                    //hitObject.transform.position = Camera.main.ScreenToWorldPoint(touchPosition);

                    // for (int i = 0; i < Input.touchCount; i++)
                    // {
                    //     if (Input.GetTouch(i).phase == TouchPhase.Began)
                    //     {
                    //         //Vector3 p = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                    //         hitObject.transform.position = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                    //     }
                    // }
                }
            }
            if(arRaycastManager.Raycast(touchPosition, hits))
            {
                Pose hitPose = hits[0].pose;

                if(onTouchHold)
                {
                    placedObject.transform.position = hitPose.position;
                }
            }
        }

    }

    public virtual void OnTouch()
    {

    }

    // void ManageMap()
    // {
    //     //if(onMapTouch == true)
    //     //{
    //         if(mapLowered == true)
    //         {
    //             BringUpMap();
    //         }
    //         if(mapLowered == false)
    //         {
    //             LowerMap();
    //         }
    //         //onMapTouch = false;
    //     //}
        
    // }
    // void BringUpMap()
    // {
    //     SeedSearchPlane.transform.position = new Vector3(0f, 0.38f, 6.09f);
    //     SeedSearchPlane.transform.rotation = new Quaternion(70.352f, 181.165f, 0f, 0f);
    //     mapLowered = false;

    // }

    // void LowerMap()
    // {
    //     SeedSearchPlane.transform.position = new Vector3(-0.043f, -1.036f, 5.297f);
    //     SeedSearchPlane.transform.rotation = new Quaternion(24.304f, 181.165f, 0f, 0f);
    //     mapLowered = true;
    // }

    
}

