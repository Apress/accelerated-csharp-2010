using System;
using System.Collections.ObjectModel;

namespace CityOfShanoo.MyZoo
{

public struct Point
{
    public double X;
    public double Y;
}

public abstract class ZooDweller
{
    public void EatSomeFood() {
        DoEatTheFood();
    }

    protected abstract void DoEatTheFood();
}

public sealed class ZooKeeper
{
    public void SendFlyCommand( Point to ) {
        // Implementation removed for clarity.
    }
}

public sealed class Zoo
{
    private static Zoo theInstance = new Zoo();
    public static Zoo GetInstance() {
        return theInstance;
    }

    private Zoo() {
        creatures = new Collection<ZooDweller>();
        zooKeeper = new ZooKeeper();
    }

    public ZooKeeper ZooKeeper {
        get {
            return zooKeeper;
        }
    }

    private ZooKeeper zooKeeper;
    private Collection<ZooDweller> creatures;
}
    
}
