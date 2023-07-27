using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    CharacterController controller;
    private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Attributes AttributesScript = GetComponentInChildren<Attributes>();
        moveSpeed = AttributesScript.GetMoveSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * moveSpeed * Time.deltaTime);
    }
}
