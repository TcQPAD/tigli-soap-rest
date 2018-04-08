using System;

namespace ClientService
{
    class Program
    {
        static void Main(string[] args)
        {
            VelibServiceCallbackSink objsink = new VelibServiceCallbackSink();

            InstanceContext iCntxt = new InstanceContext(objsink);

            // Create an object of the service proxy.
            CalcServiceReference.CalcServiceClient objClient = new CalcServiceReference.CalcServiceClient(iCntxt);

            // Select the events you prefer to receive.
            objClient.SubscribeCalculatedEvent();

            objClient.SubscribeCalculationFinishedEvent();

            // Call the service methods.
            double dblNum1 = 1000, dblNum2 = 2000;

            objClient.Calculate(0, dblNum1, dblNum2);

            dblNum1 = 2000; dblNum2 = 4000;

            objClient.Calculate(1, dblNum1, dblNum2);

            dblNum1 = 2000; dblNum2 = 4000;

            objClient.Calculate(2, dblNum1, dblNum2);

            dblNum1 = 2000; dblNum2 = 400;

            objClient.Calculate(3, dblNum1, dblNum2);
        }
    }
}
