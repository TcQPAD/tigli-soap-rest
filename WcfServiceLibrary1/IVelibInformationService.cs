using System;
using System.Text;
using System.ServiceModel;

namespace MathsLibrary
{
    [ServiceContract(CallbackContract = typeof(IVelibInformationServiceEvents))]
    interface IVelibInformationService
    {
        [OperationContract]
        void Calculate(int nOp, double dblNum1, double dblNum2);

        [OperationContract]
        void SubscribeCalculatedEvent();

        [OperationContract]
        void SubscribeCalculationFinishedEvent();
    }
}
