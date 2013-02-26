using System;

public enum BatteryType
{
    LiIon, NiMH, NiCd
}

class Battery
{
    private string model;
    private int hoursIdle;
    private int hoursTalk;
    private BatteryType batteryType;
    
    #region Constructors
    public Battery()
    {
        this.model = string.Empty;
        this.hoursIdle = 0;
        this.hoursTalk = 0;
        this.batteryType = 0;
    }
    public Battery(Battery battery)
    {
        this.model = battery.model;
        this.hoursTalk = battery.hoursIdle;
        this.hoursTalk = battery.hoursTalk;
        this.batteryType = battery.batteryType;
    }
    public Battery(string model, int hoursIdle, int hoursTalk, int batteryType)
    {
        this.model = model;
        this.hoursIdle = hoursIdle;
        this.hoursTalk = hoursTalk;
        this.batteryType = (BatteryType)batteryType;
    }
    #endregion

    #region Properties
    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public int HoursIdle
    {
        get { return this.hoursIdle; }
        set { this.hoursIdle = value; }
    }

    public int HoursTalk
    {
        get { return this.hoursTalk; }
        set { this.hoursTalk = value; }
    }
    #endregion

    public override string ToString()
    {
        return (String.Format("{0}, {1}, {2} hours idle, {3} hours talk", 
            this.model, this.batteryType, this.hoursIdle, this.hoursTalk));
    }
}
