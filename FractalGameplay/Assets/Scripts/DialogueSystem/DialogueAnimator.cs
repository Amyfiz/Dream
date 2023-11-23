using DialogueSystem;
using UnityEngine;
using UnityEngine.Serialization;

public class DialogueAnimator : MonoBehaviour
{
    public Animator startAnimation;
    public bool isActive;
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
        isActive = true;
        startAnimation.SetBool(AnimatorConstants.IsOpen, true);
        DialogueManager.Instance.StartDialogue(dialogueEntity);
    }
}