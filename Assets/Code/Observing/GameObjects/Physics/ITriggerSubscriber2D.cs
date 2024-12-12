using System;
using UnityEngine;
using Code.Observing.Subscribers;

namespace Code.Observing.GameObjects.Physics
{
  public interface ITriggerSubscriber2D : ISubscriber<Collider2D>
  {
    ITriggerSubscriber2D WithComponent<T>();
    ITriggerSubscriber2D WithComponent(Type component);
    ITriggerSubscriber2D WithLayer(LayerMask layerMask);
  }
}