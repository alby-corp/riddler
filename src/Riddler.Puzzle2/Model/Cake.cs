namespace Riddler.Puzzle2.Model;

using static Environment;

public class Cake
{
    public string Flavor { get; set; }
    public string Frosting { get; set; }
    public int Layers { get; set; }
    public string Shape { get; set; }

    public class Birthday : Cake
    {
        public override string ToString() => $"Our birthday cake: {NewLine} " +
                                             $"Flavor: {Flavor} {NewLine} " +
                                             $"Frosting: {Frosting} {NewLine} " +
                                             $"Layers: {Layers} {NewLine}" +
                                             $"Shape: {Shape}";
    }

    public class AllDays : Cake
    {
        public override string ToString() => $"Our all days cake: {NewLine} " +
                                             $"Flavor: {Flavor} {NewLine} " +
                                             $"Frosting: {Frosting} {NewLine} " +
                                             $"Layers: {Layers} {NewLine}" +
                                             $"Shape: {Shape}";
    }
}