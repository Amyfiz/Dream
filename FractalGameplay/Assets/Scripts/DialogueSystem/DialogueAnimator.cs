using DialogueSystem;
using UnityEngine;
using UnityEngine.Serialization;

public class DialogueAnimator : MonoBehaviour
{
    public Animator startAnimation;

    [FormerlySerializedAs("dialogue")] public DialogueEntity dialogueEntity;

    public void OnTriggerEnter2D(Collider2D other)
    {
        startAnimation.SetBool(AnimatorConstants.IsOpen, true);
        DialogueManager.Instance.StartDialogue(dialogueEntity);
        
        if (dialogueEntity.destroyWhenActivated) 
        {
            Destroy(gameObject);
        }
    }
}