using UnityEngine;
using System.Collections;

public class CameraLock : MonoBehaviour {

    public GameObject player;


    private Vector3 offset;

    // Use this for initialization
    void Start () 
    {
        offset = transform.position - player.transform.position;
    }
    
    void LateUpdate () 
    {
        transform.position = player.transform.position + offset;
    }
}