﻿using System.Collections;
using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    public GameObject player;

    [Tooltip("Time for camera to scale")]
    public float scaleTime = 2.0f;

    void Start()
    {
        if (player == null)
        {
            Debug.LogError("Player has not been assigned");
        }
    }

    void Update()
    {
        // debug control
        if (Input.GetKeyDown(KeyCode.L)) // when player levels up
        {
            StartCoroutine(ScaleCam(scaleTime));
        }
    }

    private IEnumerator ScaleCam(float timeToMove)
    {
        var currentPos = transform.position;
        var t = Time.deltaTime / timeToMove;
        while (t < 1)
        {
            t += Time.deltaTime / scaleTime;
            transform.position = Vector3.Slerp(currentPos, new Vector3(0, currentPos.y + 5, currentPos.z - 10), t);
            yield return null;
        }

        Debug.Log("cam pos is now " + transform.position);
    }
}