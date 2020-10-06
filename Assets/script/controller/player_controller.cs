using UnityEngine;

public class player_controller : MonoBehaviour
{
    public KeyCode up_key = KeyCode.UpArrow;
    public KeyCode down_key = KeyCode.DownArrow;
    public KeyCode left_key = KeyCode.LeftArrow;
    public KeyCode right_key = KeyCode.RightArrow;

    public KeyCode punch_key = KeyCode.RightAlt;

    private input_queue _input_queue;
    public int _player_number;

    void Start()
    {
        this._input_queue = new input_queue(this.up_key, this.down_key, this.left_key, this.right_key);
        this._player_number = game_controller.instance.next_player_number;
    }

    void Update()
    {
        this._input_queue.update();
        game_controller.instance.move_player(this._player_number, this._input_queue.current);

        if (Input.GetKeyDown(this.punch_key)) {
            game_controller.instance.player_punch(this._player_number);
        }
    }
}
