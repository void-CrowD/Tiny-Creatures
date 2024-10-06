using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BornPointController : MonoBehaviour
{
    public GameObject humanPrefab;
    // Start is called before the first frame update
    void Start()
    {
        BornHuman();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BornHuman()
    {
        GameObject human = Instantiate(humanPrefab, transform.position, Quaternion.identity);
    }
}
