using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapMovement : PlacementController
{
    bool mapDown = true;
    public bool[] setOn = new bool[5];
    bool test = false;
    public Button mapSpriteUp;
    public Button mapSpriteDown;

    void Start()
    {
        mapSpriteUp.gameObject.SetActive(false);
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
                if(Physics.Raycast(ray, out hitObject))
                {
                    if(hitObject.transform.name.Contains("Check1"))
                    {
                        mapSpriteDown.gameObject.SetActive(false);
                        mapSpriteUp.gameObject.SetActive(true);
                    }
                    onTouchHold = true;
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
                    hitObject.transform.position = touch.position;
                }
            }
        }
    }

    public void MapController()
    {
        if(mapDown == true)
        {
            mapSpriteDown.gameObject.SetActive(false);
            mapSpriteUp.gameObject.SetActive(true);
            if(test == true)
            {
                step1.gameObject.SetActive(true);
            }
            mapDown = false;
        }
        else if(mapDown == false)
        {
            mapSpriteDown.gameObject.SetActive(true);
            mapSpriteUp.gameObject.SetActive(false);
            mapDown = true;
        }
    }
}
