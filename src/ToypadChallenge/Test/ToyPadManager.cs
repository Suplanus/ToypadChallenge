using System.Drawing;
using Toypad;

public class ToyPadManager
{
    private readonly HardwareToypad _toyPad;
    private bool _isLoaded = false;
    private readonly List<Pad> _padsOnAfterInit = new();

    public ToyPadManager(HardwareToypad toypad)
    { 
        _toyPad = toypad;
        _toyPad.TagAdded += ToypadOnTagAdded;
        _toyPad.TagRemoved += ToypadOnTagRemoved;
    }
    
    void ToypadOnTagAdded(object? sender, Tag e)
    {
        if (_isLoaded)
        {
            _toyPad.SetColor(e.Pad, Color.Purple);
        }
        else
        {
            _padsOnAfterInit.Add(e.Pad);
        }
        Console.WriteLine("Tag added: " + e.UidName);
    }

    void ToypadOnTagRemoved(object? sender, Tag e)
    {
        if (_isLoaded)
        {
            _toyPad.SetColor(e.Pad, Color.Black);
        }
        else
        {
            _padsOnAfterInit.Remove(e.Pad);
        }
        Console.WriteLine("Tag remvoed: " + e.UidName);
    }

    public void Init()
    {
        Console.WriteLine("Loading...");
        for (int i = 0; i < 3; i++)
        {
            _toyPad.SetColor(Pad.Left, Color.Green);
            Thread.Sleep(100);
            _toyPad.SetColor(Pad.Left, Color.Black);
            _toyPad.SetColor(Pad.Right, Color.Green);
            Thread.Sleep(100);
            _toyPad.SetColor(Pad.Right, Color.Black);
            _toyPad.SetColor(Pad.Center, Color.Green);
            Thread.Sleep(100);
            _toyPad.SetColor(Pad.Center, Color.Black);
        }

        foreach (var pad in _padsOnAfterInit)
        {
            _toyPad.SetColor(pad, Color.Purple);
        }
        _isLoaded = true;
        Console.WriteLine("Loaded");
    }
}