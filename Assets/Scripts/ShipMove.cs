using UnityEngine;
using UnityEngine.InputSystem;

public class ShipMove : MonoBehaviour
{

    InputAction moveAction;
    InputAction lookAction;
    public float forceMultiplier = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        lookAction = InputSystem.actions.FindAction("Look");
    }

    // FixedUpdate is called once per standardized interval
    void FixedUpdate()
    {
        Vector2 rawMove = moveAction.ReadValue<Vector2>(); //take our raw input values
        //Debug.Log("Raw move input = " + rawMove); //show it in the console

        //store it in a v3 and use the y input for z output
        Vector3 directionMove = new Vector3(rawMove.x, 0f, rawMove.y); 
        //access the rigidbody component 
        GetComponent<Rigidbody>().AddRelativeForce(directionMove * forceMultiplier);
        if (rawMove == Vector2.zero){
            GetComponent<Rigidbody>().Sleep();
        }
    }

    void Update(){

        Vector2 rawLook = lookAction.ReadValue<Vector2>();
        Debug.Log("Raw look input = " + rawLook); //show it in the console

        //how do we convert it to 3d and then modify our look?
        //we can think about the axis rotations as spears through objects
        //and then rotating the spears
        Vector3 look = new Vector3(-rawLook.y,rawLook.x, 0f); //we are swapping the x and y to align with player expectations
        transform.Rotate(look); //we set transform to rotate 
    }

    //this function runs whenever this gameobject collides with another
    //it also created a new Collision object which has important info about the collision
    void OnCollisionEnter(Collision colReport){
        Debug.Log(colReport.gameObject.name);

        //destroy this gameObject
        Destroy(gameObject);

        //now destroy the gameobject you collided with
        Destroy(colReport.gameObject);
    }
}
