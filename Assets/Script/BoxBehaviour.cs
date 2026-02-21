using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class BoxDualLockBehaviour : MonoBehaviour
{
    [Header("Hinges")]
    public HingeJoint leftPanelHinge;
    public HingeJoint rightPanelHinge;

    [Header("Unlock Limits")]
    public float leftUnlockedMax = 90f;
    public float rightUnlockedMin = -90f;

    private XRSocketInteractor socket;
    private bool unlocked = false;

    void Awake()
    {
        socket = GetComponent<XRSocketInteractor>();
    }

    void OnEnable()
    {
        socket.selectEntered.AddListener(OnKeyInserted);
    }

    void OnDisable()
    {
        socket.selectEntered.RemoveListener(OnKeyInserted);
    }

    private void OnKeyInserted(SelectEnterEventArgs args)
    {
        if (unlocked) return;
        UnlockBox();
    }

    private void UnlockBox()
    {
        unlocked = true;

        JointLimits leftLimits = leftPanelHinge.limits;
        leftLimits.max = leftUnlockedMax;
        leftPanelHinge.useLimits = false; 
        leftPanelHinge.limits = leftLimits;
        leftPanelHinge.useLimits = true;

        JointLimits rightLimits = rightPanelHinge.limits;
        rightLimits.min = rightUnlockedMin;
        rightPanelHinge.useLimits = false; 
        rightPanelHinge.limits = rightLimits;
        rightPanelHinge.useLimits = true;

        Debug.Log("Dual-panel box unlocked!");
    }
}