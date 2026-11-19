using UnityEngine;
using UnityEngine.SceneManagement; //add scene management stuffs

public class DoASceneChange : MonoBehaviour
{
    //create a new public function that takes 1 argument
    //when you call the function, you need to give it an int in the parentheses
    public void ChangeScene(int sceneNumber){

        //pass the sceneNumber into the LoadScene function
        SceneManager.LoadScene(sceneNumber);
    }
}
