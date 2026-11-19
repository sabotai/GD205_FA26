using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class PointNClick : MonoBehaviour
{
    NavMeshAgent basicAgent; //create a basic agent object
    InputAction cursorAction;
    InputAction clickAction;
    Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        basicAgent = GetComponent<NavMeshAgent>(); //assign it to the same one attached to the same gameobject
        cursorAction = InputSystem.actions.FindAction("Point");
        clickAction = InputSystem.actions.FindAction("Attack");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //create a new ray that takes the 
        Ray beam = Camera.main.ScreenPointToRay(cursorAction.ReadValue<Vector2>());
        RaycastHit beamHit = new RaycastHit(); //stores all the information on whatever we hit



        if (clickAction.IsPressed()){

            //we can cast our ray using a boolean method
            //it will return true if our beam hits a collider
            if (Physics.Raycast(beam, out beamHit)){ //first argument is the ray to cast, second in where to store it
                basicAgent.SetDestination(beamHit.point);
            }
        }

        if (basicAgent.remainingDistance > 0.2f){
            anim.SetFloat("WalkParameter", 1f);
        } else {

            anim.SetFloat("WalkParameter", 0f);
        }
    }
}
