using System;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Wintellect.PowerCollections;

class Entry
{
    public string Name { get; private set; }
    public SortedSet<string> Phones { get; private set; }


    public Entry(string name)
    {
        this.Name = name;
        this.Phones = new SortedSet<string>();
    }

    public void AddPhone(string phone)
    {
        this.Phones.Add(phone);
    }

    public override string ToString()
    {
        return string.Format("[{0}: {1}]", this.Name, string.Join(", ", this.Phones));
    }
}

static class Phone
{
    public static string Parse(string s)
    {
        string phone = s;

        phone = Regex.Replace(phone, @"[^0-9\+]", "");

        if (phone.StartsWith("00"))
        {
            phone = phone.Substring(2);
            phone = "+" + phone;
        }

        phone = Regex.Replace(phone, @"^0*", "");

        if (!phone.StartsWith("+"))
        {
            phone = "+359" + phone;
        }

        return phone;
    }
}

class Program
{
    private static Dictionary<string, Entry> byName =
        new Dictionary<string, Entry>(StringComparer.InvariantCultureIgnoreCase);

    private static MultiDictionary<string, Entry> byPhone =
        new MultiDictionary<string, Entry>(false);

    private static OrderedSet<Entry> sortedPhones = new OrderedSet<Entry>((a, b) => a.Name.CompareTo(b.Name));

    static readonly StringBuilder output = new StringBuilder();

    private static void CheckIntegrity()
    {
        Debug.Assert(byName.Count == byPhone.Values.Distinct().Count());
        Debug.Assert(byName.Count == sortedPhones.Count);
    }

    static string AddPhone(string name, IList<string> phones)
    {
        string result;

        if (byName.ContainsKey(name))
        {
            result = "Phone entry merged";
        }
        else
        {
            result = "Phone entry created";
            byName[name] = new Entry(name);
        }

        Entry entry = byName[name];
        sortedPhones.Add(entry);

        foreach (var phoneParsed in phones.Select(Phone.Parse))
        {
            entry.AddPhone(phoneParsed);
            byPhone[phoneParsed].Add(entry);
        }

        CheckIntegrity();
        return result;
    }

    static string ChangePhone(string oldPhone, string newPhone)
    {
        var oldPhoneParsed = Phone.Parse(oldPhone);
        var newPhoneParsed = Phone.Parse(newPhone);

        int result = 0;


        if (oldPhoneParsed == newPhoneParsed)
        {
            result = byPhone[oldPhoneParsed].Count;
        }
        else
        {
            var entries = byPhone[oldPhoneParsed].ToList();
            foreach (var entry in entries)
            {
                entry.Phones.Remove(oldPhoneParsed);
                entry.Phones.Add(newPhoneParsed);

                byPhone[newPhoneParsed].Add(entry);
                result++;
            }

            byPhone.Remove(oldPhoneParsed);
        }

        CheckIntegrity();

        return string.Format("{0} numbers changed", result);
    }

    static string List(int start, int count)
    {
        if (start + count > sortedPhones.Count)
        {
            return "Invalid range";
        }

        IList<Entry> listed = new Entry[count];

        for (int i = start; i < start + count; i++)
        {
            Entry current = sortedPhones[i];
            listed[i - start] = current;
        }

        return string.Join(Environment.NewLine, listed);
    }

    static void Main()
    {
#if DEBUG
        Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif

        var date = DateTime.Now;

        for (string line = null; (line = Console.ReadLine()) != "End"; )
        {
            var match = Regex.Match(line, @"^(\w+)\((.*)\)$").Groups;
            var name = match[1].Value;
            var parameters = Regex.Split(match[2].Value, @",\s?");

            string result = null;

            switch (name)
            {
                case "AddPhone":
                    result = AddPhone(parameters[0], parameters.Skip(1).ToArray());
                    break;

                case "ChangePhone":
                    result = ChangePhone(parameters[0], parameters[1]);
                    break;

                case "List":
                    result = List(int.Parse(parameters[0]), int.Parse(parameters[1]));
                    break;

                default:
                    throw new ArgumentException("Invalid command: " + name);
            }

            output.AppendLine(result);
        }

#if DEBUG
        //var _output = new System.IO.StreamWriter("../../output.txt");
        //Console.SetOut(_output);
#endif

#if !DEBUG || DEBUG
        Console.Write(output.ToString());
#endif

#if DEBUG
        Console.WriteLine(DateTime.Now - date);
        //_output.Dispose();
#endif
    }
}