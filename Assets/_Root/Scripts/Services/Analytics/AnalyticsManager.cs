using Services.Analytics.UnityAnalytics;
using System.Collections.Generic;
using UnityEngine;

namespace Services.Analytics
{
    internal class AnalyticsManager : MonoBehaviour
    {
        private IAnalyticsService[] _services;

        private void Awake()
        {
            _services = new IAnalyticsService[]
            {
                new UnityAnalyticsService()
            };
        }

        public void SendGameStarted() =>
            SendEvent("GameStarted");

        private void SendEvent(string eventName)
        {
            foreach (IAnalyticsService service in _services)
                service.SendEvent(eventName);
        }

        private void SendEvent(string eventName, Dictionary<string, object> eventData)
        {
            foreach (IAnalyticsService service in _services)
                service.SendEvent(eventName, eventData);
        }
    }
}