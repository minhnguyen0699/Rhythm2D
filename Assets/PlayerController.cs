using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject[] buttonCol;
    public GameObject[] mask;
    public SwipeManager swipeManager;
    private NoteCount noteCount;
    float laneWidth = 2.4f;
    NoteCount btn1, btn2, btn3;
    Collider col;
    Vector3 mousePos;
    public Camera mainCam;


    float leftLaneBounds = -3.6f;
    float midLaneBounds = -1.2f;
    float rightLaneBounds = 1.2f;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider>();
        noteCount = GetComponentInChildren<NoteCount>();
        
    }

    // Update is called once per frame
    void Update()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 5.57f;
        var mousePosWorld = mainCam.ScreenToWorldPoint(mousePos);
        Debug.Log(score);
        if(swipeManager.SwipeLeft || swipeManager.SwipeRight)
        {
            Debug.Log("Swipe");
        }
        if (swipeManager.Tap)
        {
            if ( mousePosWorld.x > leftLaneBounds && mousePosWorld.x < leftLaneBounds + laneWidth)
            {
                noteCount = buttonCol[0].GetComponent<NoteCount>();
                noteCount.CheckDistanceTap();
            } else if (mousePosWorld.x > midLaneBounds && mousePosWorld.x < midLaneBounds + laneWidth)
            {
                noteCount = buttonCol[1].GetComponent<NoteCount>();
                noteCount.CheckDistanceTap();
            } else if (mousePosWorld.x > rightLaneBounds && mousePosWorld.x < rightLaneBounds + laneWidth)
            {
                noteCount = buttonCol[2].GetComponent<NoteCount>();
                noteCount.CheckDistanceTap();
            }

        }
        if (Input.GetMouseButtonUp(0))
        {
            if (mousePosWorld.x > leftLaneBounds && mousePosWorld.x < leftLaneBounds + laneWidth)
            {
                noteCount = buttonCol[0].GetComponent<NoteCount>();
                score += noteCount.GetScore();
                Debug.Log(noteCount.GetText());
            }
            else if (mousePosWorld.x > midLaneBounds && mousePosWorld.x < midLaneBounds + laneWidth)
            {
                noteCount = buttonCol[1].GetComponent<NoteCount>();
                score += noteCount.GetScore();
                Debug.Log(noteCount.GetText());
            }
            else if (mousePosWorld.x > rightLaneBounds && mousePosWorld.x < rightLaneBounds + laneWidth)
            {
                noteCount = buttonCol[2].GetComponent<NoteCount>();
                score += noteCount.GetScore();
                Debug.Log(noteCount.GetText());
            }
        }

        if (swipeManager.Hold)
        {
            if (mousePosWorld.x > leftLaneBounds && mousePosWorld.x < leftLaneBounds + laneWidth)
            {
                noteCount = buttonCol[0].GetComponent<NoteCount>();
                noteCount.CheckDistanceHold();
                mask[0].SetActive(true);
            }
            else if (mousePosWorld.x > midLaneBounds && mousePosWorld.x < midLaneBounds + laneWidth)
            {
                noteCount = buttonCol[1].GetComponent<NoteCount>();
                noteCount.CheckDistanceHold();
                mask[1].SetActive(true);
            }
            else if (mousePosWorld.x > rightLaneBounds && mousePosWorld.x < rightLaneBounds + laneWidth)
            {
                noteCount = buttonCol[2].GetComponent<NoteCount>();
                noteCount.CheckDistanceHold();
                mask[2].SetActive(true);
            }
        } else
        {
            if (mousePosWorld.x > leftLaneBounds && mousePosWorld.x < leftLaneBounds + laneWidth)
            {
                mask[0].SetActive(false);
            }
            else if (mousePosWorld.x > midLaneBounds && mousePosWorld.x < midLaneBounds + laneWidth)
            {
                mask[1].SetActive(false);
            }
            else if (mousePosWorld.x > rightLaneBounds && mousePosWorld.x < rightLaneBounds + laneWidth)
            {
                mask[2].SetActive(false);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("A pressed");
            noteCount = buttonCol[0].GetComponent<NoteCount>();
            noteCount.CheckDistanceTap();
          mask[0].SetActive(true);
          
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            
            mask[0].SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            noteCount = buttonCol[1].GetComponent<NoteCount>();
            noteCount.CheckDistanceTap();
            mask[1].SetActive(true);

        }
        if (Input.GetKeyUp(KeyCode.S))
        {

            mask[1].SetActive(false);
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            noteCount = buttonCol[2].GetComponent<NoteCount>();
            noteCount.CheckDistanceTap();
            mask[2].SetActive(true);

        }
        if (Input.GetKeyUp(KeyCode.D))
        {

            mask[2].SetActive(false);
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
   
}
