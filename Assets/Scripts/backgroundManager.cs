using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundManager : MonoBehaviour
{
    public List<GameObject> backGrounds = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, backGrounds.Count);
        GameObject randomObject = backGrounds[rand];
        randomObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
