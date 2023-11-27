using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseScript : MonoBehaviour
{
    private Collider2D clldr;
    [SerializeField] GameObject vasePieces;

    private void Awake()
    {
        clldr = gameObject.GetComponent<Collider2D>();
    }

    private void Update()
    {  
        if (clldr.IsTouching(GameObject.Find("Player")?.GetComponent<Collider2D>()) && Input.GetKey(KeyCode.F))
        {
            Debug.Log("Первая проверка");
            vasePieces.SetActive(true);
        }
    }
}
