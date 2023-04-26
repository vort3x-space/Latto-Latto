using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;


public class Counter : MonoBehaviour
{
    private float timer2;
    private float timer;
    private int a = 0;
    public PhysicsMaterial2D b1;
    public PhysicsMaterial2D b2;
    public PhysicsMaterial2D b3;
    public GameObject FireworksAll;
    public GameObject spark1;
    public GameObject spark2;
    private bool closespark;


    private void OnCollisionEnter2D(Collision2D col)
    {
        GameManager.Instance.collisionCount += 1f;
        if (GameManager.Instance.stage != 5)
        {
            GameManager.Instance.points += 5f;
        }
        else
        {
            GameManager.Instance.points += 4f;
        }

        if (GameManager.Instance.gamestart == false)
        {
            GameManager.Instance.gamestart = true;
        }

        Taptic.Light();
        Explode();
        ChangeMaterial();
        ComboCounter();
    }

    void ComboCounter()
    {
        a++;
        if (a > 9)
        {
            spark1.gameObject.SetActive(true);
            spark2.gameObject.SetActive(true);
            GameManager.Instance.ComboObject.SetActive(true);
            closespark = false;
        }

        if (timer2 > 1f)
        {
            GameManager.Instance.ComboObject.SetActive(false);
            closespark = true;
            a = 0;
        }

        timer2 = 0f;
    }

    //assigned in the editor
    private void Update()
    {
        timer2 += Time.deltaTime;
        timer += Time.deltaTime;
        GameManager.Instance.Text.text = GameManager.Instance.collisionCount.ToString();
        GameManager.Instance.ComboText.text = a.ToString() + "X";
        if (timer > 1f)
        {
            if (GameManager.Instance.points > 1f)
            {
                if (GameManager.Instance.stage == 1)
                {
                    GameManager.Instance.points -= 1.5f;
                }
                else if (GameManager.Instance.stage == 2)
                {
                    GameManager.Instance.points -= 3f;
                }
                else
                {
                    GameManager.Instance.points -= 5.5f;
                }
            }

            timer = 0f;
        }

        if (closespark)
        {
            spark1.gameObject.SetActive(false);
            spark2.gameObject.SetActive(false);
        }
    }


    public void ChangeMaterial()
    {
        var collider = GetComponent<Collider2D>();
        if (GameManager.Instance.Sun)
        {
            if (transform.position.y > GameManager.Instance.Sun.transform.position.y)
            {
                if (collider.GetComponent<Rigidbody2D>().velocity.magnitude < 8f)
                {
                    collider.sharedMaterial = b1;
                    collider.GetComponent<Rigidbody2D>().AddForce(new Vector2(-8, 0), ForceMode2D.Impulse);
                    transform.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(8, 0), ForceMode2D.Impulse);
                }
                else
                {
                    collider.sharedMaterial = b3;
                }
            }
            else
            {
                collider.sharedMaterial = b2;
            }
        }
    }

    void Explode()
    {
        GameObject firework = Instantiate(FireworksAll, transform.position, Quaternion.identity);
        firework.GetComponent<ParticleSystem>().Play();
    }
}