using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> backGrounds = new List<GameObject>();
    void Start()
    {
        int rand = Random.Range(0, backGrounds.Count);
        GameObject randomObject = backGrounds[rand];
        randomObject.SetActive(true);
    }
}
