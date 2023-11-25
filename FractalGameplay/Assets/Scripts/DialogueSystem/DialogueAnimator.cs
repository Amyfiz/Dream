using System;
using DialogueSystem;
using UnityEngine;

public class DialogueAnimator : MonoBehaviour
{
    [SerializeField] public Animator startAnimation;
    public DialogueEntity dialogueEntity;

    private void Awake()
    {
        startAnimation = GameObject.Find("DialogueBox")?.GetComponent<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Activate();
        if (dialogueEntity.destroyWhenActivated) 
        {
            Destroy(gameObject);
        }
    }

    public void Activate()
    {
        startAnimation.SetBool(AnimatorConstants.IsOpen, true);
        DialogueManager.Instance.StartDialogue(dialogueEntity);
    }
}