using UnityEngine;

public class player_component : MonoBehaviour
{
    public float movement_cooldown = 0.2f;
    public float hit_cooldown = 1.0f;
    float time_remaining = 0.0f;

    public direction facing { get; private set; } = direction.down;

    public void face(direction dir)
    {
        this.facing = dir;
    }

    public void hit(direction dir)
    {
        this.transform.position += direction_helper.offset(dir);
        this.time_remaining = this.hit_cooldown;
    }

    public void move(direction dir)
    {
        if (0.0f < time_remaining)
        {
            this.time_remaining = Mathf.Max(this.time_remaining - Time.deltaTime, 0.0f);
            return;
        }

        this.transform.position += direction_helper.offset(dir);
        this.time_remaining = this.movement_cooldown;
    }
}
