using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    public int teleportIndex;
    public TutorialBehaviour behaviour;

    private bool completed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (completed) return;
        if (!other.CompareTag("Player")) return;

        int expected = behaviour.GetNextTeleportIndex();

        if (teleportIndex == expected)
        {
            completed = true;
            behaviour.CompleteTeleport(teleportIndex);
        }
    }
}