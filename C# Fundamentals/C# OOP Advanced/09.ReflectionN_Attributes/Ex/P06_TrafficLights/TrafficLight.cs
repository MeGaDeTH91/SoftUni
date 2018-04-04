using System;
using System.Collections.Generic;
using System.Linq;

public class TrafficLight
{
    private TrafficLightType trafficSignal;

    public TrafficLight(TrafficLightType trafficSignal)
    {
        this.trafficSignal = trafficSignal;
    }

    public void ChangeLight()
    {
        int indexOfNextTrafficSignal = (int)TrafficSignal + 1;

        this.TrafficSignal = (TrafficLightType)(indexOfNextTrafficSignal % Enum.GetNames(typeof(TrafficLightType)).Length);
    }

    public TrafficLightType TrafficSignal
    {
        get
        {
            return this.trafficSignal;
        }
        private set
        {
            this.trafficSignal = value;
        }
    }
}
