using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ChestBehaviour : MonoBehaviour
{
    public HingeJoint drawerHinge;
    public float unlockedMinAngle = -90f;

    private XRSocketInteractor socket;

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
        UnlockDrawer();
    }

    private void UnlockDrawer()
    {
        JointLimits limits = drawerHinge.limits;
        limits.min = unlockedMinAngle; 
        drawerHinge.limits = limits;

        drawerHinge.useLimits = true;

        Debug.Log("Drawer unlocked!");
    }
}