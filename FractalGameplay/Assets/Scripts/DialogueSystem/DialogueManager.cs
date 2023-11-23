using System.Collections;
using System.Collections.Generic;
using DialogueSystem;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DialogueManager : MonoBehaviour
{
    //[SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI dialogueText;
    
    private PlayerController playerController;
    public Animator animator;
    public Queue<string> SentenceQueue;
    public DialogueEntity currentDialogueEntity;
    private static DialogueManager instance;

    public static DialogueManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        instance = this;
        playerController = GetComponent<PlayerController>();
    }

    void Start()
    {
        SentenceQueue = new Queue<string>();
    }

    public void StartDialogue(DialogueEntity dialogueEntity)
    {
        currentDialogueEntity = dialogueEntity;
        
        animator.SetBool(AnimatorConstants.IsOpen, true);
        //nameText.text = currentDialogueEntity.name;

        SentenceQueue.Clear();

        foreach (string sentence in currentDialogueEntity.sentences)
        {
            SentenceQueue.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (SentenceQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = SentenceQueue.Dequeue();
        
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (var letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(currentDialogueEntity.timeout);
        }
    }

    public void EndDialogue()
    {
        /*if (currentDialogueEntity.dialogueNumber == 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }*/
        
        currentDialogueEntity = null;
        animator.SetBool(AnimatorConstants.IsOpen, false);
        StopAllCoroutines();
        animator.SetBool(AnimatorConstants.IsOpen, false);
        
    }
}
