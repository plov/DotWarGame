using UnityEngine;
using Code.Observing.Handlers;
using Code.Observing.Subscribers;

namespace Code.Observing.GameObjects
{
  public class GameObjectLifeSubject : MonoBehaviour
  {
    private readonly Handler _onDestroy = new();

    private void OnDestroy()
    {
      _onDestroy.Raise();
      
      _onDestroy.Dispose();
    }

    public ISubscriber WhenDestroy() =>
      new Subscriber(_onDestroy);
  }
}