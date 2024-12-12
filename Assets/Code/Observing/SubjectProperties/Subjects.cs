using System;

namespace Code.Observing.SubjectProperties
{
  public interface ISubjectBool : ISubjectProperty<bool> { }

  [Serializable]
  public class SubjectBool : SubjectProperty<bool>, ISubjectBool
  {
    public SubjectBool(bool value) : base(value) { }
    public SubjectBool() { }
  }
}