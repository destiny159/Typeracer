using System;

namespace SignalR_GameServer_v1
{
  abstract class Strategy
  {
    public abstract int AlgorithmInterface();
  }

  class TankStrategy : Strategy
  {
    public override int AlgorithmInterface()
    {
      return 2;
    }
  }

  class CarStrategy : Strategy
  {
    public override int AlgorithmInterface()
    {
      return 3;
    }
  }

  class PersonStrategy : Strategy
  {
    public override int AlgorithmInterface()
    {
     return 4;
    }
  }

  class PlaneStrategy : Strategy
  {
    public override int AlgorithmInterface()
    {
      return 0;
    }
  }

  class Context
  {
    private Strategy _strategy;

    public Context(Strategy strategy)
    {
      this._strategy = strategy;
    }
    public int ContextInterface()
    {
      return _strategy.AlgorithmInterface();
    }
  }
}