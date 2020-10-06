using System.Collections.Generic;

public class current_queue< T > {
	List< T > _queue;

	public current_queue() {
		this._queue = new List< T >();
	}

	public void add( T _t ) {
		this._queue.Add( _t );
	}

	public void remove( T _t ) {
		this._queue.Remove( _t );
	}

	public T current {
		get {
			return this._queue.Count > 0 ?
				this._queue[ 0 ] :
				default( T );
		}
	}
}
