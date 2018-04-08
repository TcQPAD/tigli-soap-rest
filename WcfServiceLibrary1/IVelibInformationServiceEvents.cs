using System;
using System.Text;
using System.ServiceModel;

namespace MathsLibrary
{
    public interface IVelibInformationServiceEvents
    {
        [OperationContract(IsOneWay = true)]
        void Calculated(int nOp, double dblNum1, double dblNum2, double dblResult);

        [OperationContract(IsOneWay = true)]
        void CalculationFinished();

        [OperationContract(IsOneWay = true)]
        void numberBikesChanged(String city, String station, int sleepTime);
    }
}
