using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckValue : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TMP_InputField userInputField;
    public GameObject blockCollider;

    

    public void Check()
    {
        if (userInputField.text == "67312")
        {
            text.text = "дкъ яйювхбюмхъ тюикю ббедхре оюпнкэ: бепмн";
            blockCollider.GetComponent<Collider2D>().enabled = false;
        }
        else
        {
            text.text = "дкъ яйювхбюмхъ тюикю ббедхре оюпнкэ: мебепмн";
        }
        
    }
}
