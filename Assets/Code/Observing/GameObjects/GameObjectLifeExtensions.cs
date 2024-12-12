using UnityEngine;
using Code.Extensions;
using Code.Observing.Subscribers;

namespace Code.Observing.GameObjects
{
  public static class GameObjectLifeExtensions
  {
    public static ISubscriber OnDestroy(this GameObject gameObject) => 
      gameObject.GetOrAdd<GameObjectLifeSubject>().WhenDestroy();
  }
}