using UnityEngine;
using UnityEngine.InputSystem;

public class Cyclops : MonoBehaviour
{
    InputAction cursorAction;
    InputAction clickAction;
    public float explosionForce = 5f;
    public float explosionRadius = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cursorAction = InputSystem.actions.FindAction("Point");
        clickAction = InputSystem.actions.FindAction("Attack");
    }
    // Update is called once per frame
    void Update()
    {
        Ray beam = Camera.main.ScreenPointToRay(cursorAction.ReadValue<Vector2>());
        RaycastHit beamHit = new RaycastHit();

        if (clickAction.IsPressed()){

            //we can cast our ray using a boolean method
            //it will return true if our beam hits a collider
            if (Physics.Raycast(beam, out beamHit)){ //first argument is the ray to cast, second in where to store it
                Debug.Log("cyclops hit " + beamHit.collider.name);
                beamHit.rigidbody.AddExplosionForce( explosionForce, beamHit.point, explosionRadius);
            }
        }
    }
}
