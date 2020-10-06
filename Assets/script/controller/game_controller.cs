using UnityEngine;

public class game_controller : MonoBehaviour
{
    public static game_controller instance { get; private set; }

    public GameObject player_prefab;
    public GameObject cell_prefab;
    public int width;
    public int height;

    private int _player_count = 0;
    private player_component[] _players;
    private cell_component[] _cells;

    void Start()
    {
        if (null != game_controller.instance)
        {
            Destroy(this);
            return;
        }

        game_controller.instance = this;
    }

    public int next_player_number {
        get {
            return this._player_count++;
        }
    }

    public void initialize()
    {
        // Initialize players
        this._players = new player_component[this._player_count];

        for (int i = 0; i < this._player_count; ++i) {
            var player = Instantiate(this.player_prefab, Vector3.zero, Quaternion.identity);
            this._players[i] = player.GetComponent<player_component>();
        }

        // Initialize cells
        this._cells = new cell_component[this.width * this.height];

        float x_offset = this.width / 2;
        float y_offset = this.height / 2;

        for (int y = 0; y < this.height; ++y) {
            for (int x = 0; x < this.width; ++x) {
                var cell = Instantiate(this.cell_prefab, new Vector3(x - x_offset, y - y_offset), Quaternion.identity);
                this._cells[y * this.width + x] = cell.GetComponent<cell_component>();
                this._cells[y * this.width + x].traversable = true;
                // this._cells[y * this.width + x].traversable = 0 != x && 0 != y && this.width - 1 != x && this.height - 1 != y;
            }
        }
    }

    public bool move_player(int player_number, direction dir)
    {
        if (direction.none == dir) return false;

        this._players[player_number].face(dir);

        var move_position = this._players[player_number].transform.position + direction_helper.offset(dir);
        if (false == this.check_traversable(move_position)) return false;

        this._players[player_number].move(dir);

        return true;
    }

    public bool player_punch(int player_number)
    {
        var hit_direction = this._players[player_number].facing;
        var target_position = this._players[player_number].transform.position + direction_helper.offset(hit_direction);
        var target_player = this.player_at_position(target_position);
        if (-1 == target_player) return false;

        var hit_position = target_position + direction_helper.offset(hit_direction);
        if (false == this.check_traversable(hit_position))
        {
            hit_direction = direction.none;
        };

        this._players[target_player].hit(hit_direction);

        return true;
    }

    private bool check_index(int index)
    {
        return 0 <= index && index < this._cells.Length;
    }

    private bool check_traversable(Vector3 position)
    {
        var cell_index = this.position_to_index(position);

        if (false == this.check_index(cell_index)) return false;
        if (false == this._cells[cell_index].traversable) return false;
        if (-1 != this.player_at_position(position)) return false;

        return true;
    }

    private int player_at_position(Vector3 position)
    {
        for (int i = 0; i < this._players.Length; ++i) {
            if (this._players[i].transform.position == position) return i;
        }
        return -1;
    }

    private int position_to_index(Vector3 position) {
        float x_offset = this.width / 2;
        float y_offset = this.height / 2;

        int x = (int)(position.x + x_offset);
        int y = (int)(position.y + y_offset);

        if (0 > x || x >= this.width || 0 > y || y >= this.height) return -1;

        return y * this.width + x;
    }
}
