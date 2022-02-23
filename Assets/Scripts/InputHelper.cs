using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

public class InputHelper : MonoBehaviour
{
    public bool VerboseLogging;
    public Vector2 MoveDelta = new Vector2();
    public Vector2 LookDelta;

    private void Awake()
    {
        if (VerboseLogging)
            Logger.Level = Logger.DebugLevel.Verbose;
        HideCursor();
#if !ENABLE_INPUT_SYSTEM
        Debug.LogError("The unity input system package is not installed!");
#endif
    }

#if ENABLE_INPUT_SYSTEM
    public void OnMove(InputAction.CallbackContext value)
    {
        MoveDelta = value.ReadValue<Vector2>();
        if (MoveDelta == null)
            Logger.LogWarning("Help.");
    }
#endif

    public void HideCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
}
