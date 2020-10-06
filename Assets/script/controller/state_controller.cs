using UnityEngine;

public enum state_type { player_1 }

public class state_controller : MonoBehaviour
{
    public static state_manager<state_type> instance { get; private set; }

    void Start()
    {
        if (null != state_controller.instance)
        {
            Destroy(this);
            return;
        }

        state_controller.instance = new state_manager<state_type>();
    }

    void Update()
    {
        // state_controller.instance.update();
    }
}
