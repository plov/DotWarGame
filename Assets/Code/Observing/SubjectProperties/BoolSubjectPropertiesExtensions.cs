﻿using Code.Observing.Subscribers;

namespace Code.Observing.SubjectProperties
{
  public static class BoolSubjectPropertiesExtensions
  {
    public static ISubscriber<ValueChanged<bool>> WhenTrue(this ISubscriber<ValueChanged<bool>> subscriber) =>
      subscriber.When(x => x.NewValue);

    public static ISubscriber<ValueChanged<bool>> WhenFalse(this ISubscriber<ValueChanged<bool>> subscriber) =>
      subscriber.When(x => !x.NewValue);
  }
}