using UnityEngine;
using UnityEngine.InputSystem;

public class PrimitiveMove : MonoBehaviour
{
    InputAction moveAction;
    int bobsAge;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("this is a message from start");
        bobsAge = 27 + 10;
        moveAction = InputSystem.actions.FindAction("move");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 rawMove = moveAction.ReadValue<Vector2>();
         Debug.Log(moveAction.ReadValue<Vector2>());

        if (moveAction.WasPressedThisFrame()){

             transform.position += new Vector3(rawMove.x, 0f, rawMove.y);
        }
    }
}
