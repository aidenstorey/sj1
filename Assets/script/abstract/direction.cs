using UnityEngine;

public enum direction { none = 0, up, down, left, right };

public class direction_helper
{
    static Vector3[] _offsets = new Vector3[]
    {
        new Vector3(+0, +0),
        new Vector3(+0, +1),
        new Vector3(+0, -1),
        new Vector3(-1, +0),
        new Vector3(+1, +0),
    };


    public static Vector3 offset(direction direction)
    {
        return direction_helper._offsets[(int)direction];
    }
}
