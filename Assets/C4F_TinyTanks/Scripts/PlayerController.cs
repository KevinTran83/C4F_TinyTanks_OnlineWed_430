using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Shoot))]
public class PlayerController : MonoBehaviour
{
    private Movement movement;
    private Shoot shoot;

    public Turret turret;

    private void Start()
    {
        movement = GetComponent<Movement>();
        shoot = GetComponent<Shoot>();
    }

    // Update is called once per frame
    void Update()
    {
        // Right click to move.
        if (Mouse.current.rightButton.isPressed)
        {
            if (Physics.Raycast ( Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()),
                                  out RaycastHit hit
                                )
               )
            {
                movement.MoveToDestination(hit.point);
            }
        }

        // Left click to shoot.
        if (Mouse.current.leftButton.wasPressedThisFrame) shoot.Fire();

        // Move mouse to turn turret.
        if (Physics.Raycast ( Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue()),
                              out RaycastHit moveHit
                            )) turret.Turn(moveHit.point);
    }
}
