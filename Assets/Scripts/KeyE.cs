using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyE : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        // Keep the child object's rotation fixed at Quaternion.identity (no rotation)
        transform.rotation = Quaternion.identity;
    }
}
