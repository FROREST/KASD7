using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {     
        string[] lines = File.ReadAllLines("/Users/liga/Desktop/Учебники/Задачи KASD/KASD7/KASD7/input.txt");
        List<string> validIPs = new List<string>();

        foreach (var line in lines)
        {
     
            string[] parts = line.Split(new char[] { ' ', ',', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in parts)
            {
                if (IsValidIP(part))
                {
                    validIPs.Add(part);
                }
            }
        }
        File.WriteAllLines("/Users/liga/Desktop/Учебники/Задачи KASD/KASD7/KASD7/output.txt", validIPs);
        Console.WriteLine("Программа отработала штатно");
    }

    
    static bool IsValidIP(string input)
    {
        string[] octets = input.Split('.');
        if (octets.Length != 4)
            return false;

        foreach (var octet in octets)
        {
            if (!IsValidOctet(octet))
                return false;
        }
        return true;
    }
    static bool IsValidOctet(string octet)
    {
        if (string.IsNullOrEmpty(octet))
            return false;
        if (octet.Length > 1 && octet[0] == '0')
            return false;
        if (int.TryParse(octet, out int number))
        {    
            return number >= 0 && number <= 255;
        }
        return false;
    }
}