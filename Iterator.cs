using System;
using myDevices;
using System.Collections.Generic;

namespace myIter
{   // iterator para o tipo DeviceList
    interface IAbsIterator
    {
        Device First();
        Device Next();
        bool IsOver { get; }
        Device CurrentDevice { get; }
    }

    class myIterator : IAbsIterator
    {
        private DeviceList _myDevices;
        private int _current = 0;
        private int _step = 1;

        public myIterator(DeviceList myDevices)
        {
            _myDevices = myDevices;
        }
        public Device First()
        {
            _current = 0;
            return _myDevices[_current] as Device;
        }
        public Device Next()
        {
            _current += _step;
            if(!IsOver)
                return _myDevices[_current] as Device;
            else
                return null;
        }
        public int Step
        {
            get { return _step; }
            set { _step = value; }
        }
        public bool IsOver
        {
            get { return _current >= _myDevices.Count; }
        }
        public Device CurrentDevice
        {
            get { return _myDevices[_current] as Device; }
        }
    }
}