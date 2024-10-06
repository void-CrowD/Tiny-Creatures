using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor : MonoBehaviour
{
    public GameObject endPoint;
    public GameObject startPoint;
    public float moveSpeed = 0.5f;
    bool ifMoved = false;
    void Start()
    {
    }
    public void Move()
    {
        StartCoroutine(MoveTrapDoor());
    }

    IEnumerator MoveTrapDoor()
    {
        Vector3 moveVector = endPoint.transform.position - startPoint.transform.position;
        if (ifMoved)
        {
            moveVector *= -1;
        }
        Vector3 position = transform.position;
        Vector3 targetPosition = position + moveVector;
        while(Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            yield return null;
        }
        yield return ifMoved = !ifMoved;
    }
}
