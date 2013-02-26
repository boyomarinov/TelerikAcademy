using System;

class Display
{
    private double size;
    private ulong colors;

    #region Contructors
    public Display()
    {
        this.size = 0.0;
        this.colors = 0;
    }

    public Display(Display display)
    {
        this.size = display.size;
        this.colors = display.colors;
    }

    public Display(double size, ulong colors)
    {
        this.size = size;
        this.colors = colors;
    }
    #endregion

    #region Properties
    public double Size
    {
        get { return this.size; }
        set { this.size = value; }
    }

    public ulong Colors
    {
        get { return this.colors; }
        set { this.colors = value; }
    }
    #endregion

    public override string ToString()
    {
        return (String.Format("{0}, {1} colors", this.size, this.colors));
    }
}
