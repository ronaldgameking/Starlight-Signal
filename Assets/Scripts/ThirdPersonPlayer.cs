using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityUtils;

[RequireComponent(typeof(Rigidbody))]
public class ThirdPersonPlayer : MonoBehaviour
{
    public enum ControlAxis
    {
        None = 0,
        X = 1,
        Y = 2,
        Z = 4
    }

    public const float InputThreshold = 0.1f;
    public float Speed = 120f;
	public InputHelper Helper;
    public float TurnTime = 0.1f;
    [Tooltip("Change this if your model rotation gets messed up")]
    public bool OverrideRotationOffset;
    [DrawIf(nameof(OverrideRotationOffset), true, ComparisonType.Equals, DisablingType.DontDraw)]
    public ControlAxis Axis = ControlAxis.None;
    [DrawIf(nameof(OverrideRotationOffset), true, ComparisonType.Equals, DisablingType.DontDraw)]
    public float Offset = 0;

    private Rigidbody rb;
    private Camera mainCam;
    private float turnVelocity;
    private Vector3 input;

    private bool IsInputOverthreshold { get => input.magnitude >= InputThreshold; }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (Helper == null)
        {
            if (!TryGetComponent<InputHelper>(out Helper))
                Logger.LogError("Could not get InputHelper, input will not function!");
        }
        mainCam = Camera.main;
    }

    private void FixedUpdate()
    {
        //Check if Unity Input System Package is present
#if ENABLE_INPUT_SYSTEM
        input = new Vector3(Helper.MoveDelta.x, 0f, Helper.MoveDelta.y);
#else
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 input = new Vector3(horizontal, 0, vertical);
#endif
        Vector3 moveDir = Vector3.zero;

        if (IsInputOverthreshold)
        {
            float targetAngle = Mathf.Atan2(input.x, input.z) * Mathf.Rad2Deg + mainCam.transform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, TurnTime);

            if (!OverrideRotationOffset)
            {
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
            }
            else
            {
                switch (Axis)
                {
                    case ControlAxis.X:
                        transform.rotation = Quaternion.Euler(Offset, angle, 0f);
                        break;
                    case ControlAxis.Y:
                        transform.rotation = Quaternion.Euler(0f, angle + Offset, 0f);
                        break;
                    case ControlAxis.Z:
                        transform.rotation = Quaternion.Euler(0f, angle, Offset);
                        break;
                    case ControlAxis.None:
                        transform.rotation = Quaternion.Euler(0f, angle, 0f);
                        break;
                        //default:
                }
            }

            moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
        }
        
        rb.velocity = moveDir.normalized * Time.fixedDeltaTime * Speed;
    }
}
