using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMove : MonoBehaviour
{

    InputAction moveAction;
    InputAction lookAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        lookAction = InputSystem.actions.FindAction("Look");
    }
    // Update is called once per standardized interval
    void FixedUpdate()
    {
        Vector2 rawMove = moveAction.ReadValue<Vector2>(); //take our raw input values
        //Debug.Log("Raw move input = " + rawMove); //show it in the console

        //store it in a v3 and use the y input for z output
        Vector3 directionMove = new Vector3(rawMove.x, 0f, rawMove.y); 
        //access the rigidbody component 
        GetComponent<Rigidbody>().AddRelativeForce(directionMove);
        if (rawMove == Vector2.zero){
            GetComponent<Rigidbody>().Sleep();
        }
    }


    void Update(){

        Vector2 rawLook = lookAction.ReadValue<Vector2>();
        Debug.Log("Raw look input = " + rawLook); //show it in the console

        //how do we convert it to 3d and then modify our look?
        Vector3 look = new Vector3(rawLook.y,rawLook.x, 0f);
        transform.Rotate(look);
    }
}
