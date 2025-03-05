using UnityEngine;

[RequireComponent(typeof(Movement))]
public class PlayerController : MonoBehaviour
{
    public Movement movement;

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetMouseButtonDown(1))
        //{
        //    if (Physics.Raycast ( Camera.main.ScreenPointToRay(Input.mousePosition),
        //                          out RaycastHit hit
        //                        )
        //       )
        //    {
        //        movement.MoveToDestination(hit.point);
        //    }
        //}
    }
}
