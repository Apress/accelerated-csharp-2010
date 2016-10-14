using System;
using System.Collections.ObjectModel;

namespace CityOfShanoo.MyZoo
{

public struct Point
{
    public double x;
    public double y;
}

public interface IFly
{
    void FlyTo( Point destination );
}

public abstract class ZooDweller
{
    public void EatSomeFood() {
        DoEatTheFood();
    }

    protected abstract void DoEatTheFood();
}

public class Bird : ZooDweller, IFly
{
    public void FlyTo( Point destination ) {
        Console.WriteLine( "Flying to ({0}. {1}).",
                           destination );
    }

    protected override void DoEatTheFood() {
        Console.WriteLine( "Eating some food." );
    }
}

public sealed class ZooKeeper
{
    public void SendFlyCommand( Point to ) {
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
