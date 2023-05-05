﻿using System;
 using System.Collections.Generic;

 namespace lab8sharp
{
    enum Day
    {
        SUNDAY,
        MONDAY,
        TUESDAY,
        WEDNESDAY,
        THURSDAY,
        FRIDAY,
        SATURDAY
    }
    internal class Program
    {
        
        public  class MyTime
    {
        private int hourTime;
        private int minuteTime;
        private int secondTime;
        private Day curDay;
        private DateTime dateTime;

        public MyTime() {}
        public MyTime(int h, int m, int s, Day d, DateTime d_t) {
            if (s < 0 || s > 59 || m < 0 || m > 59 || h < 0 || h > 23) {
                throw new ArgumentException("Invalid data") ;
            }
            this.hourTime = h;
            this.minuteTime = m;
            this.secondTime = s;
            this.curDay = d;
            this.dateTime = d_t;
        }

        public int GetAllInSeconds(){
            return hourTime * 60 * 60 + minuteTime * 60 + secondTime;
        }
        public void Add5Seconds() {
            secondTime += 5;
            if (secondTime >= 60) {
                minuteTime += 1;
                secondTime -= 60;
                if (minuteTime >= 60) {
                    hourTime += 1;
                    minuteTime -= 60;
                    if (hourTime >=24)
                    {
                        hourTime = 0;

                    }
                }
            }
        }
        public void SetHours(int hours) {
            hourTime = hours;
        }
        public void SetMinutes(int minutes) {
            minuteTime = minutes;
        }
        public void SetSeconds(int Seconds) {
            secondTime = Seconds;
        }

        public int GetHours()  {
        return hourTime;
    }

        public int GetMinutes()  {
        return minuteTime;
    }
        public string GetDay()  {
        return curDay.ToString();
    }
        public DateTime GetDaTeTime()  {
        return dateTime;
    }
        
        public int GetSeconds()  {
        return secondTime;
    }
        
        public void PrintTime() {
            String h, m, s, d;
            if (hourTime < 10) {
                h = "0" + hourTime.ToString();
            }
            else {
                h = "" + hourTime.ToString();
            }
            if (minuteTime < 10) {
                m = "0" + minuteTime.ToString();
            }
            else {
                m = "" + minuteTime.ToString();
            }
            if (secondTime < 10) {
                s = "0" + secondTime.ToString();
            }
            else {
                s = "" + secondTime.ToString();
            }

            d = curDay.ToString();
            int dYear, dMonth, dDay;
            dYear = dateTime.Year;
            dMonth = dateTime.Month;
            dDay = dateTime.Day;
            System.Console.WriteLine(h + ":" + m + ":" + s + " " + d + " " + dYear
            + " " + dMonth + " " + dDay) ;
        }

    };
        public static void Main(string[] args)
        {
            MyTime T = new MyTime(23, 59, 50, Day.FRIDAY, new DateTime(2015, 7, 20));
            MyTime T1 = new MyTime(20, 12, 22, Day.MONDAY, new DateTime(2023, 11, 2));
            MyTime T2 = new MyTime(08, 05, 47, Day.THURSDAY, new DateTime(2017, 9, 14));
            MyTime T3 = new MyTime(11, 24, 34, Day.WEDNESDAY, new DateTime(2016, 1, 24));
            MyTime T4 = new MyTime(23, 59, 50, Day.SUNDAY, new DateTime(2004, 2, 23));
            var times = new List<MyTime> {T, T1, T2, T3, T4};
            
            System.Console.WriteLine("\n\nПоиск по перечисляемому типу");
            for(int i = 0; i < times.Count; i++)
            {
                MyTime it = times[i];
                if(it.GetDay() == "MONDAY") it.PrintTime();
            }
            times.Sort(new Comparison<MyTime>((x, y) => DateTime.Compare(x.GetDaTeTime(), y.GetDaTeTime())));
            System.Console.WriteLine("\n\nСортировка по полю DateTime");
            for(int i = 0; i < times.Count; i++)
            {
                MyTime it = times[i];
                it.PrintTime();
            }
        }
    }
}