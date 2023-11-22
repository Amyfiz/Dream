using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue", order = 1)]
public class DialogueEntity: ScriptableObject
{
    public string name;
    public bool destroyWhenActivated;
    public bool isAbleToWalk;
    public float timeout;

    //minimum 3 lines, maximum - 10
    [TextArea(3, 10)]
    public string[] sentences;
}