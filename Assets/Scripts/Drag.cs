using System;
using UnityEngine;

public class Drag : MonoBehaviour
{

    Vector2 dif=Vector2.zero;



    private void OnMouseDown()
    {
        dif = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        GameManager.Instance.ball.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GameManager.Instance.ball2.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        GameManager.Instance.tutorial.SetActive(false);

    }

    private void OnMouseUp()
    {
        GameManager.Instance.Failed();
    }

    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - dif;
    }
}