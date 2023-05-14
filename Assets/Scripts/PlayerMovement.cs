using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Camera _mainCamera;
    public Vector3 TargetPosition;
    public float Speed;

    void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //get target clock position
        if (Input.GetMouseButtonDown(0))
        {
            TargetPosition = GetMouseClickPosition();
            Debug.Log(TargetPosition);


        }

        MoveToTarget();
        RotateToTarget();

        //get player position
        //move player from current pos to target pos
    }


    private Vector3 GetMouseClickPosition()
    {
        var mousePosition = Input.mousePosition;
        var worldMousePosition = _mainCamera.ScreenToWorldPoint(mousePosition);
        var transformedPosition = new Vector3(worldMousePosition.x, worldMousePosition.y, 0);
        return transformedPosition;
    }

    private void MoveToTarget()
    {
        if (transform.position != TargetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, TargetPosition, Speed * Time.deltaTime);
        }
    }

    private void RotateToTarget()
    {
        var diff = TargetPosition - transform.position;
        transform.up = diff;
    }
}
