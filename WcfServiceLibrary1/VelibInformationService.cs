using System;
using System.Text;
using System.ServiceModel;

namespace MathsLibrary
{
    class VelibInformationService : IVelibInformationService
    {
        static Action<int, double, double, double> m_Event1 = delegate { };
        static Action m_Event2 = delegate { };

        public void SubscribeCalculatedEvent()
        {
            IVelibInformationServiceEvents subscriber =
            OperationContext.Current.GetCallbackChannel<IVelibInformationServiceEvents>();
            m_Event1 += subscriber.Calculated;
        }

        public void SubscribeCalculationFinishedEvent()
        {
            IVelibInformationServiceEvents subscriber =
            OperationContext.Current.GetCallbackChannel<IVelibInformationServiceEvents>();
            m_Event2 += subscriber.CalculationFinished;
        }

        public void Calculate(int nOp, double dblX, double dblY)
        {
            double dblResult = 0;
            switch (nOp)
            {
                case 0: dblResult = dblX + dblY; break;
                case 1: dblResult = dblX - dblY; break;
                case 2: dblResult = dblX * dblY; break;
                case 3: dblResult = (dblY == 0) ? 0 : dblX / dblY; break;
            }

            m_Event1(nOp, dblX, dblY, dblResult);
            m_Event2();
        }
    }
}
