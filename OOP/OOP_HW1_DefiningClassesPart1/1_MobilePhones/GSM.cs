using System;
using System.Collections.Generic;
using System.Linq;

class GSM
{
    private string model;
    private string manufacturer;
    private double price;
    private string owner;
    private Battery battery;
    private Display display;
    private List<Call> callHistory;
    
    #region Constructors
    public GSM(string model, string manufacturer)
    {
        this.model = model;
        this.manufacturer = manufacturer;
        this.price = 0;
        this.owner = string.Empty;
        this.battery = new Battery();
        this.display = new Display();
        this.callHistory = new List<Call>();
    }

    public GSM(string model, string manufacturer, double price,
        string owner, Battery battery, Display display)
    {
        this.model = model;
        this.manufacturer = manufacturer;
        this.price = price;
        this.owner = owner;
        this.battery = new Battery(battery);
        this.display = new Display(display);
        this.callHistory = new List<Call>();
    }
    #endregion

    #region Properties
    public string Model
    {
        get { return this.model; }
        set { this.model = value; }
    }

    public string Manufacturer
    {
        get { return this.manufacturer; }
        set { this.manufacturer = value; }
    }

    public double Price
    {
        get { return this.price; }
        set { this.price = value; }
    }

    public string Owner
    {
        get { return this.owner; }
        set { this.owner = value; }
    }

    public Battery Battery
    {
        get { return this.battery; }
        set { this.battery = value; }
    }

    #endregion

    #region Methods
    public override string ToString()
    {
        return (String.Format("Model: {0}\nManufacturer: {1}\nPrice: {2}\nOwner: {3}\nBattery: {4}\nDisplay: {5}",
             this.model, this.manufacturer, this.price, this.owner, this.battery, this.display));
    }
    
    //Call History
    public void AddCallToHistory(Call toAdd)
    {
        this.callHistory.Add(toAdd);
    }
    public void DeleteCallFromHistory(Call toDelete)
    {
        this.callHistory.Remove(toDelete);
    }
    public void ClearCallHistory()
    {
        this.callHistory.Clear();
    }
    public void DisplayCallHistory()
    {
        if (this.callHistory.Count == 0)
        {
            Console.WriteLine("Call history is empty.");
        }
        else
        {
            for (int i = 0; i < callHistory.Count; i++)
            {
                Console.WriteLine(callHistory[i]);
                Console.WriteLine();
            }
        }
    }
    public void RemoveLongestCall()
    {
        this.callHistory.Remove(this.callHistory.OrderByDescending(x => x.Duration).First());
    }

    public double CalculateTotalPrice(double price)
    {
        long sum = 0;
        for (int i = 0; i < callHistory.Count; i++)
        {
            sum += callHistory[i].Duration;
        }
        return ((sum / 60.0) * price); 
    }

    #endregion
}
