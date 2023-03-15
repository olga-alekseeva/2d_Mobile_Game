using UnityEngine;
using UnityEngine.UI;
using Tool.PushNotifications;
using Tool.PushNotifications.Settings;
using Unity.Notifications;

namespace Tool.Notifications.Examples
{
    internal class NotificationWindow : MonoBehaviour
    {
        [Header("Settings")]
        [SerializeField] private NotificationSettingsExamples _notificationSettings;

        [Header("Scene Components")]
        [SerializeField] private Button _buttonNotification;

        private INotificationScheduler _scheduler;


        private void Awake()
        {
            var schedulerFactory = new NotificationSchedulerFactory(_notificationSettings);
            _scheduler = schedulerFactory.Create();
        }

        private void OnEnable() =>
            _buttonNotification.onClick.AddListener(CreateNotification);

        private void OnDisable() =>
            _buttonNotification.onClick.RemoveAllListeners();

        private void CreateNotification()
        {
            foreach (NotificationData notificationData in _notificationSettings.Notifications)
                _scheduler.ScheduleNotification(notificationData);
        }
    }
}