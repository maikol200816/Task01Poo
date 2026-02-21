namespace Backend;

public class Time
{
   //Fields
    
    private int _hour;
    private int _millisecond;
    private int _minute;
    private int _second;


    //Constructors

    public Time()
    {
        _hour = 0;
        _millisecond = 0;
        _minute = 0;
        _second = 0;

    }
    
    
    public Time(int hour)
    {
       Hour= hour; 
    }
    
    public Time(int hour, int minute)
    {
       Hour= hour;
        Minute= minute;
    }
    
    public Time(int hour, int minute, int second)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
    }
    
    public Time(int hour, int minute, int second, int millisecond)
    {
        Hour = hour;
        Minute = minute;
        Second = second;
       Millisecond =millisecond;
    }


    //Properties


    public int Hour 
    { 
        get => _hour; 
        set => _hour = ValidHour(value);
    }

    public int Millisecond
    {
        get => _millisecond;
        set => _millisecond = ValidMillisecond(value);
    }


    public int Minute 
    { 
        get => _minute ;
        set => _minute= ValidMinute(value);
    }

    public int Second 
    { 
        get => _second ;
        set => _second = ValidSecond(value);
    }
    

    //Methods

    public int ToMilliseconds()
    {
        if (Hour < 0 || Hour > 23 ||
        Minute < 0 || Minute > 59 ||
        Second < 0 || Second > 59 ||
        Millisecond < 0 || Millisecond > 999)
        {
            return 0;
        }
        return (Hour * 3600000)
               + (Minute * 60000)
               + (Second * 1000)
               + Millisecond;


    }
    public int ToSeconds()
    {

        if (Hour < 0 || Hour > 23 ||
        Minute < 0 || Minute > 59 ||
        Second < 0 || Second > 59 ||
        Millisecond < 0 || Millisecond > 999)
        {
            return 0;
        }


        return (Hour * 3600)
               + (Minute * 60)
               + Second
               + (Millisecond / 1000);
    }
    public int ToMinutes()
    {

        if (Hour < 0 || Hour > 23 ||
        Minute < 0 || Minute > 59 ||
        Second < 0 || Second > 59 ||
        Millisecond < 0 || Millisecond > 999)
        {
            return 0;
        }


        return (Hour * 60)
               + Minute
               + (Second / 60)
               + (Millisecond / 60000);
    }

    public override string ToString()
    {
        if (Hour < 0 || Hour > 23 ||
            Minute < 0 || Minute > 59 ||
            Second < 0 || Second > 59 ||
            Millisecond < 0 || Millisecond > 999)
        {
            throw new ArgumentOutOfRangeException("Invalid time");
        }

        int displayHour = Hour;
        string period;

        if (displayHour >= 12)
            period = "PM";
        else
            period = "AM";

        if (displayHour == 0)
            displayHour = 12;
        else if (displayHour > 12)
            displayHour -= 12;

        return $"{displayHour:00}:{Minute:00}:{Second:00}.{Millisecond:000} {period}";
    }

    public bool IsOtherDay(Time other)
    {
        
        int totalMs = this.ToMilliseconds() + other.ToMilliseconds();

       
        if (totalMs >= 86400000)
        {
            return true;
        }

        return false;
    }

    public Time Add(Time other)
    {
        int totalMs = this.ToMilliseconds() + other.ToMilliseconds();
        totalMs %= 86400000;

        
        int hr = (totalMs / 3600000);
        int mi = ((totalMs / 60000) % 60);
        int se = ((totalMs / 1000) % 60);
        int ms = (totalMs % 1000);

        return new Time(hr, mi, se, ms);
        }
    private int ValidHour(int hour)
    { 
        if(hour<0 || hour>23)
        {
            throw new ArgumentOutOfRangeException(nameof(hour), $"The hour: {hour}, is not valid.");
        }
        return hour;
    }


    private int ValidMinute(int minute)
    {
        if (minute < 0 || minute > 59)
        {
            throw new ArgumentOutOfRangeException(nameof(minute), $"The minute: {minute}, is not valid.");
        }
        return minute;
    }
    private int ValidSecond(int second)
    {
        if (second < 0 || second > 59)
        {
            throw new ArgumentOutOfRangeException(nameof(second), $"The second: {second}, is not valid.");
        }
        return second;
    }
    private int ValidMillisecond(int millisecond)
    {
        if (millisecond < 0 || millisecond > 999)
        {
            throw new ArgumentOutOfRangeException(nameof(millisecond), $"The millisecond: {millisecond}, is not valid.");
        }
        return millisecond;
    }
}
