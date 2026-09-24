using UnityEngine;
using UnityEngine.InputSystem; //we add this directive to add on the new input system

public class PrimitiveMove : MonoBehaviour //this incorporates the name we gave the file
{
    InputAction moveAction; //create a new InputAction object called moveAction
    int bobsAge; //basic variable example
    public Transform specialPos;
    public Transform[] specialPositions;
    public Transform teleportReceiver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("this is a message from start");
        bobsAge = 27 + 10;

        //"plug in" our local InputAction object into the default move input
        //we have to make sure this FindAction() is used inside of setup
        //because it will be very slow and inefficient if we run it constantly (unnecessarily)
        moveAction = InputSystem.actions.FindAction("move");
    }

    // Update is called once per frame, like the draw function in Processing
    void Update()
    {
        //We create a new Vector2 (variable to store 2 dimensional positions)
        //we then assign it to take the axis values from the "move" InputAction
        Vector2 rawMove = moveAction.ReadValue<Vector2>();

        //Debug.Log operates like println() in Processing
        //so we will send these values to our console so we can compare
        Debug.Log(rawMove);

        //We can use InputAction.WasPressedThisFrame() to check if this input was newly input
        //because we only want it to move based on a new press and not from holding it down
        if (moveAction.WasPressedThisFrame()){ //it returns true if newly pressed




            //We offset the position by using +=
            //and mapping the x input to x position
            //and the y input to z position 
            //(because we want it to move forward rather than up)

            //transform.position will access the position of the transform component of the GameObject
            //that this script is attached to
             transform.position += new Vector3(rawMove.x, 0f, rawMove.y);
             
            for (int i = 0; i < specialPositions.Length; i++){

            if (transform.position + new Vector3(0f, -1f, 0f) == specialPositions[i].position){

                transform.position = teleportReceiver.position + new Vector3(0f, 1f, 0f);
            }
            }


            if (transform.position + new Vector3(0f, -1f, 0f) == specialPos.position){
                Debug.Log("BOOM");
                //transform.position = new Vector3(0f, 1f, 0f);
                transform.position = teleportReceiver.position + new Vector3(0f, 1f, 0f);
            }
        }
    }
}
