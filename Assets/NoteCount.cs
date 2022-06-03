using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteCount : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isEntered = false;
    public bool isCatched = false;
    private List<GameObject> notes;
    private List<GameObject> longNotes;
    public SwipeManager swipeManager;
    bool isCounting;
    bool isItPerfect;
    public int score;
    string text;
    void Start()
    {
        notes = new List<GameObject>();
        longNotes = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        /*Debug.Log(longNotes.Count);*/
        
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Pinotes"))
            { 
            notes.Add(collision.gameObject); 
        } else if (collision.gameObject.CompareTag("CoarsePinotes")) 
            { 
            longNotes.Add(collision.gameObject);
        }
        
        isEntered = true;
        isCounting = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isCatched)
        {

            if (collision.gameObject.CompareTag("Pinotes"))
            {
                collision.gameObject.SetActive(false);
                Destroy(collision.gameObject,1);
            }
            if (collision.gameObject.CompareTag("CoarsePinotes"))
            {
               
                collision.gameObject.GetComponent<Forward>().speed = 0;
            }
            if (collision.gameObject.CompareTag("CoarseTail"))
            {
                    Destroy(collision.gameObject);
            }
               
            
            isCatched = false;
        }
    }
    public void CheckDistanceTap()
    {
        if(notes.Count == 0)
        {
            SetText("Missed");
        } else
        {
           if((notes[0].transform.position.y-transform.position.y) < 3 && (notes[0].transform.position.y - transform.position.y) > -3)
            {
                if ((notes[0].transform.position.y - transform.position.y) < 0.5 && (notes[0].transform.position.y - transform.position.y) > -0.5)
                {
                    SetText("Perfect");
                    notes.Remove(notes[0]);
                    isEntered = false;
                    isCatched = true;
                    SetScore(500);
                } else {
                    SetText("Good");
                    notes.Remove(notes[0]);
                    isEntered = false;
                isCatched = true;
                    SetScore(500);
                }
            }
            
        }
    }

    public void CheckDistanceHold()
    {
        

        if (longNotes.Count == 0)
        {
            SetText("Missed");
            SetScore(0);
        }
        else if (isCounting)
         
                {
            
            if ((longNotes[0].transform.position.y - transform.position.y) < 3 && (longNotes[0].transform.position.y - transform.position.y) > -3)
            {
                bool isLongPressPerfect = longNotes[0].GetComponent<CoarseNote>().isLongPressPerfect;

                if ((longNotes[0].transform.position.y - transform.position.y) < 0.5 && (longNotes[0].transform.position.y - transform.position.y) > -0.5 && isLongPressPerfect)
                {
                    isItPerfect = true;
                    
                    SetText("Perfect");
                    longNotes[0].GetComponent<CoarseNote>().isLongPressPerfect = false;
                    isEntered = false;
                    isCatched = true;
                    SetScore(500);
                }
                else
                {
                    SetText("Good");
                    isItPerfect = false;
                    isEntered = false;
                    isCatched = true;
                    SetScore(250);
                } 
               
                
            }
            
        }
        
        isCounting = false;
    }
    public void CheckDistanceSwipe()
    {

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(notes.Count != 0) 
        {
            notes.Remove(notes[0]);
            isEntered = false;
        }
    }

    public void SetScore(int setScore)
    {
        score = setScore;
    }
    public int GetScore()
    {
        return score;
    }
    public void SetText(string setText)
    {
        text = setText;
    }

    /// <summary>
    /// i dont know wtf i just did
    /// </summary>
    /// <returns>text</returns>S
    public string GetText()
    {
        return text;
    }

}
