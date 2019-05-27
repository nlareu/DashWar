using UnityEngine;

public class PointInTimeAvatar
{
    public Vector3 position;
    public AvatarStates state;
    public Sprite sprite;

    /// <summary>
    /// Stores a point in time for the avatar.
    /// </summary>
    /// <param name="_position">The position of the avatar.</param>
    /// <param name="_states">Current state of the avatar.</param>
    /// <param name="_sprite">Current sprite of the avatar.</param>
    public PointInTimeAvatar(Vector3 _position, AvatarStates _states, Sprite _sprite)
    {
        position = _position;
        state = _states;
        sprite = _sprite;
    }
}
