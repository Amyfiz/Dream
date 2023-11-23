using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PicturePuzzle : MonoBehaviour
{
    private bool isMoving;
    private Vector2 mousePos;
    private float startPosX;
    private float startPosY;

    public GameObject form;

    private bool isFinished;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isMoving = true;
            mousePos = Input.mousePosition;

            startPosX = mousePos.x - transform.localPosition.x;
            startPosY = mousePos.y - transform.localPosition.y;
        }
    }

    private void OnMouseUp()
    {
        isMoving = false;

        if (Mathf.Abs(transform.localPosition.x - form.transform.localPosition.x) <= 5f &&
            Mathf.Abs(transform.localPosition.y - form.transform.localPosition.y) <= 5f)
        {
            transform.position = new Vector2(form.transform.position.x, form.transform.position.y);
            isFinished = true;
        }
    }

    private void Update()
    {
        if (isMoving && !isFinished)
        {
            mousePos = Input.mousePosition;
            gameObject.transform.localPosition = new Vector2(mousePos.x - startPosX, mousePos.y - startPosY);
        }
    }
}
