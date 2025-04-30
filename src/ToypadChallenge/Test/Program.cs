// See https://aka.ms/new-console-template for more information

using LegoDimensions;
using LegoDimensions.Portal;
using Toypad;
using Color = System.Drawing.Color;
using Pad = Toypad.Pad;

Console.WriteLine("START");
try
{
    var toypad = Toypad.Toypad.CreateToypad();
    var toyPadManager = new ToyPadManager((HardwareToypad)toypad);
    toyPadManager.Init();

    Console.WriteLine("Waiting for tag...");
    Console.ReadLine();
    Console.WriteLine("END");
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}