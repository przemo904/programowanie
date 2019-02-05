using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
   struct Time : IEquatable<Time>,IComparable<Time>
    {
        private readonly byte _hours, _minutes, _seconds;
        private readonly long _miliseconds;

        public byte Hours => _hours;
        public byte Minutes => _minutes;
        public byte Seconds => _seconds;
        public long Miliseconds => _miliseconds;

     
        public Time(byte hours, byte minutes, byte seconds, long miliseconds) : this() {

            _hours = hours;
            _minutes = minutes;
            _seconds = seconds;
            _miliseconds = miliseconds;
            Validate();
        }

        public Time(byte hours, byte minutes, byte seconds) : this()
        {

            _hours = hours;
            _minutes = minutes;
            _seconds = seconds;
            _miliseconds = 0;
            Validate();
        }

        public Time(byte hours, byte minutes) : this()
        {

            _hours = hours;
            _minutes = minutes;
            _seconds = 0;
            _miliseconds = 0;
            Validate();
        }

        public Time(string time) : this()
        {
            var timeArray = time.Split(':');

            if (timeArray.Count() != 4) {
                throw new ArgumentException("Bad format. HH:MM:SS:MMM");
            }

            _hours = byte.Parse(timeArray[0]);
            _minutes = byte.Parse(timeArray[1]);
            _seconds = byte.Parse(timeArray[2]);
            _miliseconds = long.Parse(timeArray[3]);
            Validate();
        }

        private void Validate()
        {
            if (_hours > 23) throw new ArgumentOutOfRangeException();
            if (_minutes > 59) throw new ArgumentOutOfRangeException();
            if (_seconds > 59) throw new ArgumentOutOfRangeException();
            if (_miliseconds > 999) throw new ArgumentOutOfRangeException();
        }

        public bool Equals(Time other)
        {
           

            long temp1 = this.CaltulateMiliseconds();
            long temp2 = other.CaltulateMiliseconds();

            return temp1 == temp2;

        }

        public int CompareTo(Time other)
        {

            var timeThis = this.CaltulateMiliseconds();
            var timeOther = other.CaltulateMiliseconds();
            return timeThis.CompareTo(timeOther);
        }

        public override string ToString()
        {
            return Hours + ":" + Minutes + ":" + Seconds + ":" + Miliseconds;
        }

        public long CaltulateMiliseconds() {

            long _actualMiliseconds;

            _actualMiliseconds = (((_hours * 60) + _minutes) * 60 + _seconds) * 1000 + _miliseconds;
            return _actualMiliseconds;
        }

        public static Time CalculateTime(long millis) {
            var milliseconds = millis % 1000;
            var tempSeconds = millis / 1000;
            var seconds = tempSeconds % 60;
            var tempMinutes = tempSeconds / 60;
            var minutes = tempMinutes % 60;
            var tempHours = tempMinutes / 60;
            var hours = tempHours % 24;

            return new Time((byte)hours, (byte)minutes, (byte)seconds, milliseconds);
        }

        public Time Plus(Time time) {

            return Plus(time.Hours, time.Minutes, time.Seconds, time.Miliseconds);
        }

        public Time Plus(byte hours, byte minute, byte second, long milliseconds) {

            Time a = new Time(hours, minute, second, milliseconds);
            var b = a.CaltulateMiliseconds();
            var c = this.CaltulateMiliseconds();
            var result = b + c;
            return CalculateTime(result);

        }

        public Time Minus(Time time)
        {

            return Minus(time.Hours, time.Minutes, time.Seconds, time.Miliseconds);
        }

        public Time Minus(byte hours, byte minute, byte second, long milliseconds)
        {

            Time a = new Time(hours, minute, second, milliseconds);
            var b = a.CaltulateMiliseconds();
            var c = this.CaltulateMiliseconds();

            if (c > b) throw new ArgumentException("Can't substract from smaller time.");

            var result = b - c;
            return CalculateTime(result);

        }

        public static Time operator +(Time argument1, Time argument2) {

            return argument1.Plus(argument2);

        }
        public static Time operator -(Time argument1, Time argument2)
        {
            return argument1.Minus(argument2);

        }
        public static bool operator !=(Time argument1, Time argument2)
        {
            return !(argument1.Equals(argument2));

        }
        public static bool operator ==(Time argument1, Time argument2)
        {
            return argument1.Equals(argument2);

        }

        public static bool operator <=(Time argument1, Time argument2)
        {

            if (argument1.CompareTo(argument2) == -1 || argument1.CompareTo(argument2) == 0) return true;
            else return false;

        }
        public static bool operator >=(Time argument1, Time argument2)
        {
            if (argument1.CompareTo(argument2) == 1 || argument1.CompareTo(argument2) == 0) return true;
            else return false;

        }
        public static bool operator <(Time argument1, Time argument2)
        {
            if (argument1.CompareTo(argument2) == -1) return true;
            else return false;

        }
        public static bool operator >(Time argument1, Time argument2)
        {
            if (argument1.CompareTo(argument2) == 1) return true;
            else return false;

        }
    }
}
