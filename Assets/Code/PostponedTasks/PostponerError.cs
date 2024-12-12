using System;
using Code.SmartDebug;

namespace Code.PostponedTasks
{
  public static class PostponerError
  {
    private static readonly MessageBuilder Error = DLogger.Message(DSenders.Postponer).WithFormat(DebugFormat.Exception);

    public static void Log(Exception e) =>
      Error.WithText("Exception inside sequence: " + e).Log();
  }
}