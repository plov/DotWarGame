using UnityEngine.EventSystems;
using Code.Observing.Subscribers;

namespace Code.PlayerInput
{
  public interface IInput
  {
    EventSystem EventSystem { get; }
    bool Enabled { set; }
    Actions.PlayerActions Main { get; }
    ISubscriber<InputContext> OnAct { get; }
    ISubscriber<InputContext> OnLoadShop { get; }
    ISubscriber<InputContext> OnLoadArena { get; }
    ISubscriber<InputContext> OnAddSouls { get; }
  }
}