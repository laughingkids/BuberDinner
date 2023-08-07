using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities;

public class MenuSection : Entity<MenuSectionId>
{
    private readonly List<MenuItem>  _items = new ();
    public string Name { get; }
    public string Description { get; }
    
    public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();
    private MenuSection(
        string name, 
        string description,
        List<MenuItem> items, 
        MenuSectionId? id = null) 
        : base(id ?? MenuSectionId.Create(name))
    {
        Name = name;
        Description = description;
        _items = items;
    }
    
    public static MenuSection Create(
        string name, 
        string description, 
        List<MenuItem>? items = null)
    {
        return new MenuSection(name, description, items ?? new List<MenuItem>());
    }
}