using System;

class Call
{
    private DateTime date;
    private TimeSpan time;
    private string dialedNumber;
    private long duration;

    #region Constructors
    //public Call()
    //{
    //    this.date = DateTime.Today;
    //    this.time = DateTime.Now.TimeOfDay;
    //    this.dialedNumber = string.Empty;
    //    this.duration = 0;
    //}

    public Call(DateTime date, TimeSpan time, string dialedNumber, long duration)
    {
        this.date = date;
        this.time = time;
        this.dialedNumber = dialedNumber;
        this.duration = duration;
    }
    #endregion

    #region Properties
    public DateTime Date
    {
        get { return this.date; }
        set { this.date = value; }
    }

    public TimeSpan Time
    {
        get { return this.time; }
        set { this.time = value; }
    }

    public string DialedNumber
    {
        get { return this.dialedNumber; }
        set { this.dialedNumber = value; }
    }

    public long Duration
    {
        get { return this.duration; }
        set { this.duration = value; }
    }
    #endregion

    public override string ToString()
    {
        return (String.Format("{0}  {1:hh\\:mm\\:ss} h\nDialed Number: {2}\nDuration: {3} seconds", 
            this.date.ToShortDateString(), this.time, this.dialedNumber, this.duration));
    }
}
