using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPointController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Human")
        {
            // 发送有人通过通知并销毁人物
            Debug.Log("EndPointController: Human passed");
            Destroy(other.gameObject);
        }
    }
}
