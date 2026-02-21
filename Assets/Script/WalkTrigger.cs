using UnityEngine;
using System.Collections;

public class WalkTrigger : MonoBehaviour
{
    public int triggerIndex;
    public TutorialBehaviour behaviour;

    [Header("Visuals")]
    public Renderer platformRenderer;
    public Material inactiveMat;
    public Material correctMat;
    public Material wrongMat;

    private bool completed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (completed) return;
        if (!other.CompareTag("Player")) return;

        int expectedIndex = behaviour.GetNextWalkIndex();

        if (triggerIndex == expectedIndex)
        {
            completed = true;

            if (platformRenderer != null && correctMat != null)
                platformRenderer.material = correctMat;

            behaviour.CompleteWalkTrigger(triggerIndex);
        }
        else
        {
            if (platformRenderer != null && wrongMat != null)
                StartCoroutine(FlashWrong());
        }
    }

    IEnumerator FlashWrong()
    {
        platformRenderer.material = wrongMat;
        yield return new WaitForSeconds(0.5f);
        platformRenderer.material = inactiveMat;
    }
}