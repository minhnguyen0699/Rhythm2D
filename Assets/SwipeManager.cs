using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    private bool tap, swipeLeft, swipeRight, swipeUp, swipeDown, hasReleased, isHolding;
    private bool isDraging = false;
    private Vector2 touchStart, touchEnd, swipeDelta;
    float holdTime = 0;
    public void Update()
    {

        tap = swipeLeft = swipeRight = swipeUp = swipeDown = hasReleased 
            = isHolding = false;
        
        
        #region Standalone Inputs
        if (Input.GetMouseButtonDown(0))
        {
            tap = true;
            isDraging = true;
            hasReleased = false;
            touchStart = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            
            holdTime += Time.deltaTime;
            if (holdTime>0.2 && !hasReleased) { isHolding = true; }
            
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isDraging = false;
            hasReleased = true;
            touchEnd = Input.mousePosition;
            holdTime = 0;
            Reset();
        } 
        #endregion

        #region Mobile Input
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began) {
                isDraging = true;
                tap = true;
                hasReleased = false;
                touchStart = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled) {
                isDraging = false;
                hasReleased = true;
                Reset();
            }
        }
        #endregion

        // Calculate the distance
        swipeDelta = Vector2.zero;
        if (isDraging)
        {
            if (Input.touches.Length > 0)
                swipeDelta = Input.touches[0].position - touchStart;
            else if (Input.GetMouseButton(0))
                swipeDelta = (Vector2)Input.mousePosition - touchStart;
        }

        //Did we cross the distance?
        if (swipeDelta.magnitude > 125)
        {
            //Which direction?
            float x = swipeDelta.x;
            float y = swipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y)) {
                //Left or right
                if (x < 0)
                    swipeLeft = true;
                else
                    swipeRight = true;
            }
            else {
                // Up or down
                if (y < 0)
                    swipeDown = true;
                else
                    swipeUp = true;
            }
            Reset();
        }
    }

    void Reset()
    {
        touchStart = swipeDelta = Vector2.zero;
        isDraging = false;
        isHolding = false;
    }

    public bool Tap { get { return tap; } }
    public bool HasReleased { get { return hasReleased; } }
    public bool SwipeLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }
    public bool Dragging { get { return isDraging; } }

    public bool Hold { get { return isHolding; } }
}
