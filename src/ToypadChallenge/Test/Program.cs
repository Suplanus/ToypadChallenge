using LegoDimensions;
using LibUsbDotNet.LibUsb;
using Toypad;

namespace Test;

public static class Program
{
    static ToyPadManager? _toyPadManager;
    public static async Task Main(string[] args)
    {
        Console.WriteLine("START");
        try
        {
            await Init();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            _toyPadManager?.Dispose();
            
            try
            {
                await Init();
            }
            catch (Exception ei)
            {
                Console.WriteLine(ei);
                _toyPadManager?.Dispose();
                await Init();
            }
        }
        Console.WriteLine("END");
    }

    private static async Task Init()
    {
        Console.Write("Connecting portal...");
        IUsbDevice? portal = null;
        while (portal == null)
        {
            portal = LegoPortal.GetPortals().FirstOrDefault();
            if (portal == null)
            {
                Console.Write(".");
                Thread.Sleep(1000);   
            }
        }
        Console.WriteLine();

        Console.WriteLine("Portal connected.");
        
        var toyPad = new HardwareToypad(new LegoPortal(portal));
            
        _toyPadManager = new ToyPadManager(toyPad);
        await _toyPadManager.Init();
        
        Console.WriteLine("Waiting for tag...");
        Console.ReadLine();
    }
}