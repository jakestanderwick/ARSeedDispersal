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
    public GameObject step1, step2, step3, step4, step5, step6;
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
            //mapSprite.transform.position = new Vector3 (0f, -440f, 3f);
            mapSpriteDown.gameObject.SetActive(false);
            mapSpriteUp.gameObject.SetActive(true);
            //step1.gameObject.SetActive(true);
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
            // step1.gameObject.SetActive(false);
            // step2.gameObject.SetActive(false);
            // step3.gameObject.SetActive(false);
            // step4.gameObject.SetActive(false);
            // step5.gameObject.SetActive(false);
            // step6.gameObject.SetActive(false);
            // float fx = mapSprite.transform.position.x + 10;
            // float fy = mapSprite.transform.position.y + 10;
            // float fz = mapSprite.transform.position.z + 10;
            // mapSprite.transform.position = new Vector3(fx, fy, fz);
            //mapSprite.transform.rotation = new Quaternion(0f,180f,0f,0f);
            mapDown = true;
        }
    }
}
