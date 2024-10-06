using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DisposableOrganButton : MonoBehaviour
{
    public List<TrapDoor> boundObjectList = new List<TrapDoor>();
    public float depth = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
    }
    public void Sink()
    {
        foreach (TrapDoor trapDoor in boundObjectList)
        {
            trapDoor.Move();
        }
        transform.position = new Vector2(transform.position.x, transform.position.y - depth);
    }
    public virtual void Rise()
    {
        
    }
}
