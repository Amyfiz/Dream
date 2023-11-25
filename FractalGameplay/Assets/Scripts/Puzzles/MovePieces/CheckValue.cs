using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckValue : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TMP_InputField userInputField;
    public GameObject door;
    public void Check()
    {
        if (userInputField.text == "67312")
        {
            text.text = "дкъ яйювхбюмхъ тюикю ббедхре оюпнкэ: бепмн";
            door.GetComponent<Collider2D>().enabled = true;
        }
        else
        {
            text.text = "дкъ яйювхбюмхъ тюикю ббедхре оюпнкэ: мебепмн";
        }
        
    }
}
