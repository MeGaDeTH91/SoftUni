namespace P06_TrafficLights
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<TrafficLight> trafficLights = new List<TrafficLight>();

            string[] lightsInput = Console.ReadLine().Split(new[] { ' '},StringSplitOptions.RemoveEmptyEntries).ToArray();
            foreach (var light in lightsInput)
            {
                TrafficLightType currentLight;
                bool isValidLight = Enum.TryParse(light, out currentLight);

                if (isValidLight)
                {
                    TrafficLight lightToAdd = new TrafficLight(currentLight);
                    trafficLights.Add(lightToAdd);
                }                
            }

            int timesToChangeLight = int.Parse(Console.ReadLine());
            
            for (int numberOfChange = 0; numberOfChange < timesToChangeLight; numberOfChange++)
            {
                trafficLights.ForEach(x => x.ChangeLight());
                Console.WriteLine(string.Join(" ", trafficLights.Select(x => x.TrafficSignal)));
            }
        }
    }
}
