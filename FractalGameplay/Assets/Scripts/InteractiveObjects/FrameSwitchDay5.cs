using UnityEngine;

public class FrameSwitchDay5 : MonoBehaviour
{
    public GameObject activeFrame;
    public GameObject nonActiveFrame1;
    public GameObject nonActiveFrame2;
    public GameObject nonActiveFrame3;
    private Player player;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Player>())
        {
            activeFrame.SetActive(true);
            nonActiveFrame1.SetActive(false);
            nonActiveFrame2.SetActive(false);
            nonActiveFrame3.SetActive(false);
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.GetComponent<Player>())
        {
            activeFrame.SetActive(false);
        }
    }
}
