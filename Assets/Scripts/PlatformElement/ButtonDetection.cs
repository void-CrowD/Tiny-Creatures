using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDetection : MonoBehaviour
{
    List<GameObject> weightOnIt;
    public DisposableOrganButton boundButton;
    private GameObject buttonImage;
    // Start is called before the first frame update
    void Start()
    {
        weightOnIt = new List<GameObject>();
        if(boundButton == null)
        {
            Debug.LogError("ButtonDetection: boundButton is not set");
            BoxCollider2D collider = GetComponent<BoxCollider2D>();
            collider.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Human" || other.gameObject.tag == "Propellable")
        {
            weightOnIt.Add(other.gameObject);
            boundButton.Sink();
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Human" || other.gameObject.tag == "Propellable")
        {
            weightOnIt.Remove(other.gameObject);
            if(weightOnIt.Count == 0)
            {
                boundButton.Rise();
            }
        }
    }
}
