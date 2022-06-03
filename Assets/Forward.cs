using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forward : MonoBehaviour
{
    
    public float speed=10f;
    CoarseNote coarseNote;
    
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("CoarsePinotes"))
        {
            coarseNote = GetComponent<CoarseNote>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -1 * speed * Time.deltaTime,0);
      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
