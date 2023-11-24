using Microsoft.EntityFrameworkCore;

namespace database.Models;

public class Ingredient
{
    public int Id { get; private set; }
    public required string Name { get; set; }
}