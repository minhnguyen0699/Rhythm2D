using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane1Controller : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isEntered = false;
    public bool isCatched = false;
    private List<GameObject> notes;
    public SwipeManager swipeManager;
    void Start()
    {
        notes = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

      
    }

    /* private void OnTriggerEnter2D(Collider2D collision)
     {*/

    /* if (collision.gameObject.CompareTag("Pinotes"))
     {

             Destroy(collision.gameObject);
     }
     if (collision.gameObject.CompareTag("CoarsePinotes"))
     {
         isEntered = true;
         collision.gameObject.GetComponent<Forward>().enabled = false;
     }
     if (collision.gameObject.CompareTag("CoarseTail"))
     {
        if((collision.gameObject.transform.position.y - transform.position.y) > 0.5f)
         {
             Destroy(collision.gameObject);
         }
     }*/

    /*  if (collision.transform.position.z - transform.position.z <= 0.4f)
      {
          Debug.Log("Perfect");
      }
      else if (collision.transform.position.z - transform.position.z <= 1.2f && collision.transform.position.z - transform.position.z > 0.4f)
      {
          Debug.Log("Good");
      }
      else Debug.Log("Missed");*/

    /*}*/


    private void OnTriggerEnter2D(Collider2D collision)
    {
        notes.Add(collision.gameObject);
        isEntered = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isCatched)
        {

            if (collision.gameObject.CompareTag("Pinotes"))
            {
                collision.gameObject.SetActive(false);
                Destroy(collision.gameObject, 1);
            }
            if (collision.gameObject.CompareTag("CoarsePinotes"))
            {

                collision.gameObject.GetComponent<Forward>().enabled = false;
            }
            if (collision.gameObject.CompareTag("CoarseTail"))
            {
                /*if ((collision.gameObject.transform.position.y - transform.position.y) < 0.5f)
                {*/
                Destroy(collision.gameObject);
                /*}*/
            }


            isCatched = false;
        }
    }
    public void CheckDistance()
    {
        if (notes.Count == 0)
        {
            Debug.Log("missed");
        }
        else
        {
            if ((notes[0].transform.position.y - transform.position.y) < 3)
            {
                Debug.Log("good");
                notes.Remove(notes[0]);
                isEntered = false;
                isCatched = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (notes.Count != 0)
        {
            notes.Remove(notes[0]);
            isEntered = false;
        }
    }

    public void CheckInput()
    {
        if (swipeManager.Tap)
        {
            Debug.Log("script 1 tap");
        }
    }
}
