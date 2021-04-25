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
    public GameObject MovementTest;
    public Transform goToTarget, target, target1, target2, target3, target4, target5, target6;
    
    public GameObject step1, step2, step3, step4, step5, step6;
    public float speed;
    public bool bogBool;

    

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
        if(!TryGetTouchPosition(out Vector2 touchPosition))
            return;

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
                    // if(hitObject.transform.name.Contains("StartButton"))
                    // {
                    //     target.position = target1.position;
                    // }
                    if(hitObject.transform.name.Contains("Check1Button"))
                    {
                        target.position = target2.position;
                        step1.gameObject.SetActive(true);
                    }
                    if(hitObject.transform.name.Contains("Check2Button"))
                    {
                        target.position = target3.position;
                        step2.gameObject.SetActive(true);
                    }
                    if(hitObject.transform.name.Contains("Check3Button"))
                    {
                        target.position = target4.position;
                        step3.gameObject.SetActive(true);
                    }
                    if(hitObject.transform.name.Contains("Check4Button"))
                    {
                        target.position = target5.position;
                        step4.gameObject.SetActive(true);
                    }
                    if(hitObject.transform.name.Contains("Check5Button"))
                    {
                        target.position = target6.position;
                        step5.gameObject.SetActive(true);
                    }
                    if(hitObject.transform.name.Contains("Check6Button"))
                    {
                        target.position = goToTarget.position;
                        step6.gameObject.SetActive(true);
                    }
                }
            }
            if(touch.phase == TouchPhase.Moved)
            {
                touchPosition = touch.position;
            }
            if(touch.phase == TouchPhase.Ended)
            {
                onTouchHold = false;
            }
            if(onTouchHold)
            {
                if(hitObject.collider != null)
                {
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
        // if(bogBool == true)
        // {
        //     float step = speed * Time.deltaTime;
        //     transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        // }
    }

    IEnumerator MoveFunction(Vector3 newPosition)
    {
        float timeSinceStarted = 0f;
        while (MovementTest.transform.position != newPosition)
        {
            timeSinceStarted += Time.deltaTime;
            MovementTest.transform.position = Vector3.Lerp(MovementTest.transform.position, newPosition, timeSinceStarted);

            // If the object has arrived, stop the coroutine
            if (MovementTest.transform.position == newPosition)
            {
                yield break;
            }

            // Otherwise, continue next frame
            yield return null;
        }
    }
//     IEnumerator MoveTowards(Transform objectToMove, Vector3 toPosition, float duration)
// {
//     float counter = 0;

//     while (counter < duration)
//     {
//         counter += Time.deltaTime;
//         Vector3 currentPos = objectToMove.position;

//         float time = Vector3.Distance(currentPos, toPosition) / (duration - counter) * Time.deltaTime;

//         objectToMove.position = Vector3.MoveTowards(currentPos, toPosition, time);

//         Debug.Log(counter + " / " + duration);
//         yield return null;
//     }
// }

    
}

