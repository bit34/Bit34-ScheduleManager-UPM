using System;
using UnityEngine;
using Com.Bit34Games.Time.Utilities;
using Com.Bit34Games.Time.Constants;


namespace Com.Bit34Games.Time.Unity
{
    public class TimeManager : MonoBehaviour,
                               ITimeManager
    {
        //  MEMBERS
        public IScheduleManager ScheduleManager { get{ return _scheduleManager; } }
        //      Private
        private ScheduleManager _scheduleManager;
        

        //  METHODS
#region Unity callbacks

        private void Awake()
        {
            _scheduleManager = new ScheduleManager(this);
        }

        private void Update()
        {
            _scheduleManager.Update();
        }

#endregion

#region ITimeManager implementation

        public DateTime GetNow(TimeTypes timeType)
        {
            if (timeType == TimeTypes.Utc)               {   return DateTime.UtcNow; }
            if (timeType == TimeTypes.Application)       {   return DateTime.MinValue.Add(TimeSpan.FromSeconds(UnityEngine.Time.unscaledTime)); }
            if (timeType == TimeTypes.ApplicationScaled) {   return DateTime.MinValue.Add(TimeSpan.FromSeconds(UnityEngine.Time.time)); }
            throw new Exception("Not implemented");
        }

        public TimeSpan GetDelta(TimeTypes timeType)
        {
            if (timeType == TimeTypes.Utc)               {   return TimeSpan.FromSeconds(UnityEngine.Time.unscaledDeltaTime); }
            if (timeType == TimeTypes.Application)       {   return TimeSpan.FromSeconds(UnityEngine.Time.unscaledDeltaTime); }
            if (timeType == TimeTypes.ApplicationScaled) {   return TimeSpan.FromSeconds(UnityEngine.Time.deltaTime); }
            throw new Exception("Not implemented");
        }

        public void SetScale(float timeScale)
        {
            UnityEngine.Time.timeScale = timeScale;
        }

#endregion

    }
}
