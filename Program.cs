namespace facade_pattern
{
    //A demonstration of the Facade pattern in C#
    internal class Program
    {
        static void Main(string[] args)
        {
            Subsystem1 subsystem1 = new Subsystem1();
            Subsystem2 subsystem2 = new Subsystem2();
            Facade facade = new Facade(subsystem1, subsystem2);

            //Although there is much logic under this one call, the client doesn't need to concern itself with it.
            Client.ClientCode(facade);
        }
    }

    //Facade delegates the client requests to the appropriate objects within the subsystem.
    //Facade is also responsible for managing their lifecycle. All of this shields the client from the undesired complexity of the subsystem.
    public class Facade
    {
        protected Subsystem1 subsystem1;
        protected Subsystem2 subsystem2;

        public Facade(Subsystem1 subsystem1, Subsystem2 subsystem2)
        {
            this.subsystem1 = subsystem1;
            this.subsystem2 = subsystem2;
        }

        //The Facade's methods are shortcuts to the sophisticated functionality of the subsystems.
        //However, clients get only to a fraction of a subsystem's capabilities.
        public string Operation()
        {
            string result = "Facade initializes subsystems:\n";

            result += this.subsystem1.operation1();
            result += this.subsystem2.operation1();
            result += "Facade orders subsystems to perform the action:\n";
            result += this.subsystem1.operationN();
            result += this.subsystem2.operationZ();

            return result;
        }
    }

    //The Subsystem can accept requests either from the facade or client directly.
    //The Facade is yet another client, and it's not a part of the Subsystem.
    public class Subsystem1
    {
        public string operation1()
        {
            return "Subsystem1: Ready!\n";
        }

        public string operationN()
        {
            return "Subsystem1: Go!\n";
        }
    }

    //Some facades can work with multiple subsystems at the same time.
    public class Subsystem2
    {
        public string operation1()
        {
            return "Subsystem2: Get ready!\n";
        }

        public string operationZ()
        {
            return "Subsystem2: Fire!\n";
        }
    }

    class Client
    {
        //The client code works with complex subsystems through a simple interface provided by the Facade.
        //When a facade manages the lifecycle of the subsystem, the client might not even know about the existence of the subsystem
        public static void ClientCode(Facade facade)
        {
            Console.Write(facade.Operation());
        }
    }
}
