using demo;
using Test.RdCross.Base;
using Test.RdCross.Util;

namespace Test.RdCross.Cases.Client
{
  // ReSharper disable once UnusedType.Global
  // ReSharper disable once InconsistentNaming
  public class CrossTest_AllEntities_CsClient : CrossTest_CsClient_Base
  {
    protected override void Start()
    {
      Logging.TrackAction("Checking constant", CrossTest_AllEntities.CheckConstants);

      Queue(() =>
      {
        var model = Logging.TrackAction("Creating DemoModel", () => new DemoModel(ModelLifetime, Protocol));
        var extModel = Logging.TrackAction("Creating ExtModel", () => model.GetExtModel());

        Logging.TrackAction("Firing", () =>
          CrossTest_AllEntities.FireAll(model, extModel)
        );
      });
    }
  }
}