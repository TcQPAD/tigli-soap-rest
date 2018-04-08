using System;
using System.Text;
using System.ServiceModel;

namespace MathsLibrary
{
    [ServiceContract(CallbackContract = typeof(IVelibInformationServiceEvents))]
    public interface IVelibInformationService
    {
        [OperationContract]
        void Calculate(int nOp, double dblNum1, double dblNum2);

        [OperationContract]
        void SubscribeCalculatedEvent();

        [OperationContract]
        void SubscribeCalculationFinishedEvent();

        [OperationContract]
        void numberBikesChanged(String city, String station, int sleepTime);
    }
}
