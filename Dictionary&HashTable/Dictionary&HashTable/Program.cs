using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

public class IPAddress : DictionaryBase
{
    public void Add(string key, object value)
    {
        base.InnerHashtable.Add(key, value);
    }
    public void Remove(string key)
    {
        base.InnerHashtable.Remove(key);
    }
    public object Item(string key)
    {
        return base.InnerHashtable[key];
    }
}
public class MyDictionary
{
    private int size = 10;
    public string[] keys;
    public string[] values;
    public static int count = 0;
    public MyDictionary()
    {
        keys = new string[size];
        values = new string[size];
    }
    public void Add(string key, string value)
    {
        if (count < keys.Length)
        {
            keys[count] = key;
            values[count] = value;
            count++;
        }
    }
    public string Item(string key)
    {
        int index = -1;
        for (int i = 0; i < keys.Length; i++)
        {
            if (keys[i] == key)
            {
                index = i;
                break;
            }
        }
        if (index != -1)
            return values[index];
        else
            return null;
    }
    public void Remove(string key)
    {
        int index = -1;
        for (int i = 0; i < keys.Length; i++)
        {
            if (keys[i] == key)
            {
                index = i;
                break;
            }
        }
        if (index != -1)
        {
            MovePrev1Step(keys, index);
            MovePrev1Step(values, index);
            count--;
        }
    }
    public void MovePrev1Step(string[] t, int from)
    {
        for (int i = from; i < t.Length - 1; i++)
        {
            t[i] = t[i + 1];
        }
        t[t.Length - 1] = "";
    }
    public string Foreach(string key)
    {
        int i = 0;
        foreach (string  item in keys)
        {
            if (item == key)
            {
                return values[i];
            }
            i++;
        }
        return null;
    }
}
public class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        /*IPAddress ip = new IPAddress();
        ip.Add("Micheal", "192.168.0.1");
        ip.Add("John", "192.168.1.1");*/
        /* Console.WriteLine("Mike's IP: " 
                        + ip.Item("Micheal")); */
        /*IDictionaryEnumerator en = 
                        ip.GetEnumerator();
        while(en.MoveNext())
            Console.WriteLine(en.Key + " : " + en.Value);
        */
        /*
        Dictionary<string, string> ip2 = 
                        new Dictionary<string, string>();
        ip2.Add("Micheal", "192.168.0.1");
        ip2.Add("John", "192.168.0.2");
        foreach(KeyValuePair<string, string> kvp in ip2)
            Console.WriteLine(kvp.Key + " : " + kvp.Value);
        */
        /*MyDictionary ip3 = new MyDictionary();
        ip3.Add("Micheal", "192.168.0.1");
        ip3.Add("John", "192.168.0.2");
        Console.WriteLine("Micheal's IP: "
                        + ip3.Item("Micheal"));
        //ip3.Remove("Micheal");
        string v = ip3.Item("Micheal") != null ? ip3.Item("Micheal") : "Not exists";
        Console.WriteLine("Micheal's IP: "
                        + v);
        Console.WriteLine("---------");
        ip3.Foreach();*/
        MyDictionary ip4 = new MyDictionary();
        Console.WriteLine("Nhập tên File");
        string filePath = Console.ReadLine();
        
        if (!File.Exists(filePath))
        {
            Console.WriteLine("Lỗi: File không tồn tại!");
            return;
        }
        string doc = File.ReadAllText(filePath);
        List<string> tens = new List<string>(),
                     sdts = new List<string>();
        string ten = "",
               sdt = "";
        foreach (char a in doc)
        {
            if (!char.IsDigit(a))
            {
                if (sdt != "")
                {
                    sdts.Add(sdt);
                    sdt = "";
                }
                ten += a;
            }
            else
            {
                if (ten != "")
                {
                    tens.Add(ten);
                    ten = "";
                }
                sdt += a;
            }
        }
        if (sdt != "")
            sdts.Add(sdt);
        if (ten != "")
            tens.Add(ten);
        for (int i = 0; i < tens.Count;i++)
        {
            ip4.Add(tens[i], sdts[i]);
        }
        Console.WriteLine("Tìm kiếm:");
        string search = Console.ReadLine();
        Console.WriteLine(ip4.Foreach(search));
    }
}