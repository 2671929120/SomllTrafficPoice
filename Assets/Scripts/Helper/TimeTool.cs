﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class TimeTool:MonoSingleton<TimeTool>
    {
        private Dictionary<int, TeaTime> _timeDict;
        private int _timeIndex;

        public override void Awake()
        {
            base.Awake();
            _timeDict = new Dictionary<int, TeaTime>();
            _timeIndex = 0;
        }

        public int Delay(float time, Action call)
        {
            var t = this.Create();
            t.Add(time, delegate ()
            {
                call();
                t.Stop();
            });
            _timeIndex += 1;
            _timeDict.Add(_timeIndex, t);
            return _timeIndex;
        }

        public int Delay<T>(float time, Action<T> call, T obj)
        {
            var t = this.Create();
            t.Add(time, delegate ()
            {
                call(obj);
                t.Stop();
            });
            _timeDict.Add(++_timeIndex, t);
            return _timeIndex;
        }

        public int Delay<T, U>(float time, Action<T, U> call, T val1, U val2)
        {
            var t = this.Create();
            t.Add(time, delegate ()
            {
                call(val1, val2);
                t.Stop();
            });
            _timeDict.Add(++_timeIndex, t);
            return _timeIndex;
        }

        public int Delay<T, U, V>(float time, Action<T, U, V> call, T val1, U val2, V val3)
        {
            var t = this.Create();
            t.Add(time, delegate ()
            {
                call(val1, val2, val3);
                t.Stop();
            });
            _timeDict.Add(++_timeIndex, t);
            return _timeIndex;
        }

        public int Countdown(float duration, Action call)
        {
            var t = this.Create();
            t.Add(duration, delegate () { call?.Invoke(); }).Repeat();
            _timeDict.Add(++_timeIndex, t);
            return _timeIndex;
        }

        public int Loop(Action<TimeHandler> call)
        {
            var t = this.Create();
            t.Loop(call);
            _timeDict.Add(++_timeIndex, t);
            return _timeIndex;
        }

        public int Countdown(int tick, Action call1, Action done = null)
        {
            call1?.Invoke();
            var t = this.Create();
            t.Add(1, delegate ()
            {
                tick--;
                call1?.Invoke();
                if (tick > 0) return;
                done?.Invoke();
                t.Stop();
            }).Repeat();
            _timeDict.Add(++_timeIndex, t);
            return _timeIndex;
        }

        public void RemoveTimeEvent(int index)
        {
            _timeDict.TryGetValue(index, out var t);
            if (t == null) return;
            t.Stop();
            _timeDict.Remove(index);
        }

    
}
