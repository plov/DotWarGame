using UnityEngine.EventSystems;
using Code.Observing.Subscribers;

namespace Code.PlayerInput
{
  public interface IInput
  {
    EventSystem EventSystem { get; }
    bool Enabled { set; }
    InputControls.LevelActions Main { get; }
    ISubscriber<InputContext> OnAct { get; }
  }
}