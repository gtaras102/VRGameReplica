using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class TeleportToggle : MonoBehaviour
{
    [SerializeField] private InputActionReference teleportToggleBtn;

    public UnityEvent OnTeleportActivate;
    public UnityEvent OnTeleportCancel;

    private void OnEnable()
    {
        teleportToggleBtn.action.performed += ActivateTeleport;
        teleportToggleBtn.action.canceled += DeativateTeleport;
    }

    private void OnDisable()
    {
        teleportToggleBtn.action.performed -= ActivateTeleport;
        teleportToggleBtn.action.canceled -= DeativateTeleport;
    }

    private void DeativateTeleport(InputAction.CallbackContext context)
    {
        OnTeleportActivate.Invoke();
    }

    private void ActivateTeleport(InputAction.CallbackContext context)
    {
        Invoke("TurnOffTeleport", .1f);
    }

    private void TurnOffTeleport()
    {
        OnTeleportCancel.Invoke();
    }


}
