using UnityEngine;
using UnityEngine.EventSystems;

public interface ITagCollider: IEventSystemHandler
{
    void OnCollision(CircleCollider2D cc);
}
