using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceVisibilityController : MonoBehaviour
{
    public GameObject obj;
    void OnTriggerEnter(Collider other)
    {
        obj.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        obj.SetActive(false);
    }
}