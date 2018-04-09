namespace P10_TirePressureMonitoringSysTest
{
    using Moq;
    using NUnit.Framework;
    using P10_TirePressureMonitoringSys;
    using System;
    using System.Reflection;

    public class TirePressureTest
    {
        private const int NegativePressure = -10;
        private const int LowerPressure = 15;
        private const int BottomBorderValidPressure = 17;
        private const int ValidPressure = 19;
        private const int TopBorderValidPressure = 21;
        private const int HigherPressure = 26;

        [Test]
        public void NegativePressureShouldThrowException()
        {
            Mock<ISensor> mockSensor = new Mock<ISensor>();

            mockSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(NegativePressure);

            Type alarmType = typeof(Alarm);

            Alarm classInstance = (Alarm)Activator.CreateInstance(alarmType);
            FieldInfo sensor = alarmType.GetField("_sensor", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo checkMethod = alarmType.GetMethod("Check", BindingFlags.Instance | BindingFlags.Public);

            sensor.SetValue(classInstance, mockSensor.Object);

            Assert.Throws<ArgumentOutOfRangeException>(() => classInstance.Check());
        }

        [Test]
        public void LowerPressureShouldActivateAlarm()
        {
            Mock<ISensor> mockSensor = new Mock<ISensor>();

            mockSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(LowerPressure);

            Type alarmType = typeof(Alarm);

            Alarm classInstance = (Alarm)Activator.CreateInstance(alarmType);
            FieldInfo sensor = alarmType.GetField("_sensor", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo checkMethod = alarmType.GetMethod("Check", BindingFlags.Instance | BindingFlags.Public);

            sensor.SetValue(classInstance, mockSensor.Object);

            Assert.That(classInstance.AlarmOn, Is.EqualTo(false));

            checkMethod.Invoke(classInstance, null);

            Assert.That(classInstance.AlarmOn, Is.EqualTo(true));
        }

        [Test]
        public void BottomBorderPressureShouldNotActivateAlarm()
        {
            Mock<ISensor> mockSensor = new Mock<ISensor>();

            mockSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(BottomBorderValidPressure);

            Type alarmType = typeof(Alarm);

            Alarm classInstance = (Alarm)Activator.CreateInstance(alarmType);
            FieldInfo sensor = alarmType.GetField("_sensor", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo checkMethod = alarmType.GetMethod("Check", BindingFlags.Instance | BindingFlags.Public);

            sensor.SetValue(classInstance, mockSensor.Object);

            Assert.That(classInstance.AlarmOn, Is.EqualTo(false));

            checkMethod.Invoke(classInstance, null);

            Assert.That(classInstance.AlarmOn, Is.EqualTo(false));
        }

        [Test]
        public void ValidPressureShouldNotActivateAlarm()
        {
            Mock<ISensor> mockSensor = new Mock<ISensor>();

            mockSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(ValidPressure);

            Type alarmType = typeof(Alarm);

            Alarm classInstance = (Alarm)Activator.CreateInstance(alarmType);
            FieldInfo sensor = alarmType.GetField("_sensor", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo checkMethod = alarmType.GetMethod("Check", BindingFlags.Instance | BindingFlags.Public);

            sensor.SetValue(classInstance, mockSensor.Object);

            Assert.That(classInstance.AlarmOn, Is.EqualTo(false));

            checkMethod.Invoke(classInstance, null);

            Assert.That(classInstance.AlarmOn, Is.EqualTo(false));
        }

        [Test]
        public void TopBorderPressureShouldNotActivateAlarm()
        {
            Mock<ISensor> mockSensor = new Mock<ISensor>();

            mockSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(TopBorderValidPressure);

            Type alarmType = typeof(Alarm);

            Alarm classInstance = (Alarm)Activator.CreateInstance(alarmType);
            FieldInfo sensor = alarmType.GetField("_sensor", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo checkMethod = alarmType.GetMethod("Check", BindingFlags.Instance | BindingFlags.Public);

            sensor.SetValue(classInstance, mockSensor.Object);

            Assert.That(classInstance.AlarmOn, Is.EqualTo(false));

            checkMethod.Invoke(classInstance, null);

            Assert.That(classInstance.AlarmOn, Is.EqualTo(false));
        }

        [Test]
        public void HigherPressureShouldActivateAlarm()
        {
            Mock<ISensor> mockSensor = new Mock<ISensor>();

            mockSensor.Setup(s => s.PopNextPressurePsiValue()).Returns(HigherPressure);

            Type alarmType = typeof(Alarm);

            Alarm classInstance = (Alarm)Activator.CreateInstance(alarmType);
            FieldInfo sensor = alarmType.GetField("_sensor", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo checkMethod = alarmType.GetMethod("Check", BindingFlags.Instance | BindingFlags.Public);

            sensor.SetValue(classInstance, mockSensor.Object);

            Assert.That(classInstance.AlarmOn, Is.EqualTo(false));

            checkMethod.Invoke(classInstance, null);

            Assert.That(classInstance.AlarmOn, Is.EqualTo(true));
        }
    }
}
