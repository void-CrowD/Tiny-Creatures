using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDetection : MonoBehaviour
{
    public HumanController humanController;
    private Rigidbody2D rb2D;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Ground" && humanController.state == HumanState.Walk)
        {
            Debug.Log("TurnBack");
            humanController.state = HumanState.Walk;
            humanController.TurnBack();
        }
    }
}
