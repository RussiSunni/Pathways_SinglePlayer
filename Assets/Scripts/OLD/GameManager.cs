using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static  List<GameObject> _toggles = new List<GameObject>();
    void Start()
    {
        foreach (GameObject toggle in GameObject.FindGameObjectsWithTag("Toggle"))
        {
            _toggles.Add(toggle);
        }
        Debug.Log(_toggles.Count);
    } 
}
