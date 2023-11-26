using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private bool isDragged = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;

    private Collider2D collider;


    private void Awake()
    {
        gameObject.GetComponent<Collider2D>().isTrigger = true;
        collider = gameObject.GetComponent<Collider2D>();
    }


    private void OnMouseDown()
    {
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.localPosition;
    }

    private void OnMouseDrag()
    {
        if (isDragged)
        {
            transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
        }
    }

    private void Update()
    {
        if ((collider.IsTouching(GameObject.Find("ClothesBox1")?.GetComponent<Collider2D>()) || collider.IsTouching(GameObject.Find("ClothesBox2")?.GetComponent<Collider2D>())) && Input.GetMouseButtonUp(0))
        {
            Debug.Log("Ты гений");
            Destroy(gameObject);
        }
    }


}
