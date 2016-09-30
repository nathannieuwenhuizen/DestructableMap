using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// this is the interface for ITagCollider. 
/// It has one function with the  circlecollider2d parameter.
/// It is needed for the destructiblesprite.cs
/// </summary>
public interface ITagCollider: IEventSystemHandler
{
    void OnCollision(CircleCollider2D cc);
}
