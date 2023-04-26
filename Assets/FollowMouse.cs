using System;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        transform.position = mousePosition;

        if (Input.GetMouseButtonUp(0))
        {
            transform.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else if (Input.GetMouseButtonDown(0))
        {
            transform.gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}