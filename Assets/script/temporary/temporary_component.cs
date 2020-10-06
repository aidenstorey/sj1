using UnityEngine;

public class temporary_component : MonoBehaviour
{

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            game_controller.instance.initialize();
        }
    }
}
