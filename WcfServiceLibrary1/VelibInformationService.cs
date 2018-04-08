using System;
using System.Text;
using System.ServiceModel;
using System.Threading;

namespace MathsLibrary
{
    public class VelibInformationService : IVelibInformationService
    {
        static Action<string, string, int> m_EventBikes = delegate { };
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

        public void numberBikesChanged(string city, string station, int sleepTime)
        {
            IVelibInformationService subscriber = OperationContext.Current.GetCallbackChannel<IVelibInformationService>();
            m_EventBikes += subscriber.numberBikesChanged;

            Thread updater = new Thread(new ParameterizedThreadStart(updateNumberBikes));
            Tuple<string, Tuple<string, int>> datas = new Tuple<string, Tuple<string, int>>(city, new Tuple<string, int>(station, sleepTime));
            updater.Start(datas);
        }

        public void updateNumberBikes(Object o)
        {
            Tuple<string, Tuple<string, int>> datas = (Tuple<string, Tuple<string, int>>) o;
            VelibsAPIRequests v = new VelibsAPIRequests();
            String city = datas.Item1;
            String station = datas.Item2.Item1;
            int sleepTime = datas.Item2.Item2;

            while (true)
            {
                v.GetVelibCounts(city, station);
                Thread.Sleep(sleepTime);
            }
        }
    }
}
