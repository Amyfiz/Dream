using DialogueSystem;
using UnityEngine;

public class DialogueAnimator : MonoBehaviour
{
    public Animator startAnimation;
    public DialogueEntity dialogueEntity;

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