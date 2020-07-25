using System.Collections.Generic;

public class state_manager<T> where T: System.Enum
{
    Dictionary<T, state_queue> _state_queues;

    state_manager() {
        this._state_queues = new Dictionary<T, state_queue>();
    }

    public void add_queue(T queue, params state[] s)
    {
        this._state_queues[queue].add_queue(s);
    }

    public void clear_queue(T queue)
    {
        this._state_queues[queue].clear_queue();
    }

    public void update()
    {
        foreach (var queue in this._state_queues.Values) {
            queue.update();
        }
    }
}
