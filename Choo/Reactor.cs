using System;
using System.Collections.Generic;
using System.Text;

namespace Choo
{
    class AEIMessage
    {
        public enum Type { Sensor, JTag, KTag }
        public Type type;
        public DateTime time;
    }

    class SensorMessage : AEIMessage
    {
        public char sensorNumber;
    }

    class JTagMessage : AEIMessage
    {
        public String model;
        public String cheHao;
        public String status;
        public String kh;
        public String cheCi;
        public String shuangjie;
    }

    class KTagMessage : AEIMessage
    {
    }

    class Reactor
    {
        private readonly ChooDbContext dbContext;

        enum State { Watching, Passing }

        //watching state data
        int triggerCount = 0;

        //passing state data
        DateTime passTime;
        private TrainPassage trainPassage;

        private int carTriggerCount = 0;
        private int carTriggerAltCount = 0;

        private const int triggerSensorNumber = 1;
        private const int triggerThreshold = 4;
        private const int trainSensorNumber = 0xD;
        private const char carTriggerSensor = '4';
        private const char carTriggerSensorAlt = '8';
        private const int carTriggerThreshold = 4;

        private State state = State.Watching;
        public void OnSensorDataReceived(AEIMessage sensorData)
        {
            switch(state)
            {
                case State.Watching:
                    Watching(sensorData);
                    break;
                case State.Passing:
                    Passing(sensorData);
                    break;
            }
        }

        private void Watching(AEIMessage message)
        {
            switch (message.type)
            {
                case AEIMessage.Type.Sensor:
                    WatchingSensorMessage((SensorMessage)message);
                    break;
                case AEIMessage.Type.JTag:
                    WatchingJTagMessage((JTagMessage)message);
                    break;
            }
        }

        private void Passing(AEIMessage message)
        {
            switch(message.type)
            {
                case AEIMessage.Type.Sensor:
                    PassingSensorMessage((SensorMessage)message);
                    break;
                case AEIMessage.Type.KTag:
                    PassingKTagMessage((KTagMessage)message);
                    break;
            }
        }

        private void WatchingSensorMessage(SensorMessage message)
        {
            if (message.sensorNumber == triggerSensorNumber) triggerCount++;
            else
            {
                Console.WriteLine("received data from a sensor other than trigger sensor before receiving trigger sensor data");
            }
        }

        private void WatchingJTagMessage(JTagMessage message)
        {
            if (triggerCount >= triggerThreshold)
            {
                //passTime = message.time;
                trainPassage = new TrainPassage(passTime);
                state = State.Passing;
            }
            else Console.WriteLine("Received @D Sensor Data, but trigger count has not being enough");
        }

        private void PassingSensorMessage(SensorMessage message)
        {
            if (message.sensorNumber == carTriggerSensor) carTriggerCount++;
            else if (message.sensorNumber == carTriggerAltCount) carTriggerAltCount++;
            else
            {
                Console.WriteLine("Received a sensor message that is not from the expected sensors");
            }
        }

        private void PassingKTagMessage(KTagMessage message)
        {
            if(carTriggerCount >= carTriggerThreshold || carTriggerAltCount >= carTriggerThreshold)
            {
                //a car passed, save it to the db
                if(trainPassage != null)
                {
                    if (trainPassage.CarPassages == null) trainPassage.CarPassages = new List<CarPassage>();
                    trainPassage.CarPassages.Add(new CarPassage(message.time));
                }
            }
        }
    }
}
