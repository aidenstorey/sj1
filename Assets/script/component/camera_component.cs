using UnityEngine;

public class camera_component : MonoBehaviour
{
	float _duration = 0.0f;
	float _current = 0.0f;
	float _intensity = 0.0f;

	Vector3 _origin;

	public void shake(float duration, float intensity)
	{
		this._duration = duration;
		this._intensity = intensity;
		this._current = 0.0f;
		this._origin = this.transform.position;
	}

	public void Update()
	{
		if (this._current < this._duration)
		{
			this._current = Mathf.Min(this._duration, this._current + Time.deltaTime);
			this.transform.position = this._origin + new Vector3(Random.Range(-this._intensity, this._intensity), Random.Range(-this._intensity, +this._intensity));

			if (this._current >= this._duration)
			{
				this.transform.position = this._origin;
			}
		}
	}
}
