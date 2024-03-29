﻿using Irodahaz240112;
using System.Text;

List<Iroda> irodak = new();
using StreamReader sr = new(
    path: @"..\..\..\src\irodahaz.txt",
    encoding: System.Text.Encoding.UTF8);
while (!sr.EndOfStream) irodak.Add(new(sr.ReadLine()));
foreach (var i in irodak)
{
    Console.WriteLine(i.ToString());
}
int max = 0;
int f8 = 0;
for (int i = 0; i < irodak.Count; i++)
{
    if (irodak[i]._letszamok.Sum() > max)
    {
        max = irodak[i]._letszamok.Sum();
        f8 = i + 1;
    }
}
Console.WriteLine($"\nA legtöbb dolgozó a {f8}. emeleten van");

bool f9 = false;
string kod = string.Empty;
string sorszam = string.Empty;
foreach (var iroda in irodak)
{
    int length = iroda._letszamok.Count();
    for (int i = 0; i < 12; i++)
    {
        if (iroda._letszamok[i] == 9)
        {
            f9 = true;
            kod = iroda._kod;
            sorszam = (i + 1).ToString();
        }
    }
}
if (f9) Console.WriteLine($"\nA {kod} kóddal ellátot cég {sorszam}.-ik irodájában dolgoznak 9-en");
else Console.WriteLine("\nNincs olyan iroda, ahol 9 ember dolgozik");

using StreamWriter sw = new(
                path: @"..\..\..\src\UresIrodak.txt",
                append: false,
                encoding: UTF8Encoding.UTF8);
string text = string.Empty;

foreach (var iroda in irodak)
{
    text = string.Empty;
    text += iroda._kod + ": ";
    for (int i = 0; i < 12; i++)
    {
        if (iroda._letszamok[i] == 0)
        {
            text += (i + 1).ToString() + ", ";
        }
    }
    sw.WriteLine(text);
}

double f12 = 0;
foreach (var iroda in irodak)
{
    if (iroda._kod == "LOGMEIN")
    {
        f12 = iroda._letszamok.Sum() / iroda._letszamok.Count();
    }
}
Console.WriteLine($"\nÁtlagosan {Math.Round(f12)} fő dolgozik");

int f14 = 0;
irodak.ForEach(i => f14 += i._letszamok.Sum());
Console.WriteLine($"\n{f14}");