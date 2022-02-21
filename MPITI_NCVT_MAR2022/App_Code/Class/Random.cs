namespace RandomNum
{
    using System;
    /// <summary>
    /// Summary description for Random.
    /// </summary>
    public class RandomNumgen
    {
        public RandomNumgen()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public double RandomNumber()
        {
            int year = Convert.ToInt32(DateTime.Now.Year);
            int month = Convert.ToInt32(DateTime.Now.Month);
            int day = Convert.ToInt32(DateTime.Now.Day);
            int hour = Convert.ToInt32(DateTime.Now.Hour);
            int minute = Convert.ToInt32(DateTime.Now.Minute);
            int sec = Convert.ToInt32(DateTime.Now.Second);
            int millisec = Convert.ToInt32(DateTime.Now.Millisecond);

            //return (year + month + day) + (hour + minute + sec + millisec);
                     
           double  result = double.Parse(year.ToString() + month.ToString() + day.ToString() + hour.ToString() + minute.ToString()+ sec.ToString() );
           return result ;
        }
    }
}