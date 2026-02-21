using UnityEngine;


public class CongratsBehaviour : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket1;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket2;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket3;

    public GameObject congratsUI;

    private bool isSolved = false;

    void Start()
    {
        if (congratsUI != null)
            congratsUI.SetActive(false);
    }

    void Update()
    {
        if (isSolved) return;

        if (IsSocketFilled(socket1) &&
            IsSocketFilled(socket2) &&
            IsSocketFilled(socket3))
        {
            PuzzleSolved();
        }
    }

    bool IsSocketFilled(UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor socket)
    {
        return socket != null && socket.hasSelection;
    }

    void PuzzleSolved()
    {
        isSolved = true;

        if (congratsUI != null)
            congratsUI.SetActive(true);

        Debug.Log("All sockets filled!");
    }
}