namespace database.Models;

public record Measure(string Unit, float Quantity) {
    public int Id {get; private set;}
}