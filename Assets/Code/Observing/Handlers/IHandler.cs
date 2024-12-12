﻿using System;
using Code.Observing.Subscribers;

namespace Code.Observing.Handlers
{
  public interface IHandler<T> : IDisposable
  {
    ISubscriber<T> Subscribe(Action<T> action);
    ISubscriber<T> Subscribe(Action action);
    ISubscriber<T> Subscribe(IActivatableSubscriber<T> subscriber);
    void Unsubscribe(Action<T> action);
    void Unsubscribe(IActivatableSubscriber<T> subscriber);
  }
  
  public interface IHandler : IHandler<EmptyEvent>
  {
  }
}