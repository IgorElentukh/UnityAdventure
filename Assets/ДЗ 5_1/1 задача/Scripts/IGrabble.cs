using UnityEngine;

public interface IGrabble
{
    Transform Transform { get; }

    void OnGrab();
    void OnRelease();
}
