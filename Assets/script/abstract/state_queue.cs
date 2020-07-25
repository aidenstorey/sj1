using System.Collections.Generic;

public class state_manager
{
    state _current;
    Queue<state> _state_queue = new Queue<state>();

    void _validate_current()
    {
        if ((this._current != null && this._current.completed) || this._current == null)
        {
            if (this._state_queue.Count > 0)
            {
                this._current = this._state_queue.Dequeue();
            }
            else
            {
                this._current = null;
            }
        }
    }

    public void add_queue(params state[] s)
    {
        foreach (var i in s)
        {
            this._state_queue.Enqueue(i);
        }

        this._validate_current();
    }

    public void clear_queue()
    {
        this._state_queue.Clear();
    }

    public void update()
    {
        if (this._current != null)
        {
            this._current.update();

            this._validate_current();
        }
    }

    public bool processing {
        get {
            return this._current != null;
        }
    }
}
