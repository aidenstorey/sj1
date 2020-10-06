using System.Collections.Generic;
using UnityEngine;

public class input_queue : current_queue< direction > {
	Dictionary< KeyCode, direction > _input_map;

	public input_queue(KeyCode up, KeyCode down, KeyCode left, KeyCode right) {
		this.initialize(up, down, left, right);
	}

	public input_queue() {
		this.initialize(KeyCode.UpArrow, KeyCode.DownArrow, KeyCode.LeftArrow, KeyCode.RightArrow);
	}

	public void update() {
		if (null == this._input_map) return;

		foreach ( var key in this._input_map.Keys ) {
			if ( Input.GetKeyDown( key ) ) {
				this.add( this._input_map[ key ] );
			}
			else if ( Input.GetKeyUp( key ) ) {
				this.remove( this._input_map[ key ] );
			}
		}
	}

	private void initialize(KeyCode up, KeyCode down, KeyCode left, KeyCode right) {
		this._input_map = new Dictionary< KeyCode, direction > {
			{ up, direction.up },
			{ down, direction.down },
			{ left, direction.left },
			{ right, direction.right },
		};
	}
}
