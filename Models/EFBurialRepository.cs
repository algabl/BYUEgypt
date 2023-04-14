using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BYUEgypt.Models;

public class EFBurialRepository : IBurialRepository
{
    private fagelgamous_databaseContext Context { get; set; }
    public EFBurialRepository(fagelgamous_databaseContext temp)
    {
        Context = temp;
    }

    public IQueryable<Burialmain> Burials => Context.Burialmains;
    public void DeleteRecord(Burialmain burial)
    {
        Context.Remove(burial);
        Context.SaveChanges();
    }

    public IQueryable<Burialmain> GenerateQuery(Dictionary<string, string?> dict)
    {
        var queryable = Context.Burialmains.AsQueryable();
        
        string? sex = dict["Sex"];
        string? indsex = dict["indicatorSex"];
        string? ageatdeath = dict["Ageatdeath"];
        string? indageatdeath = dict["indicatorAgeatdeath"];
        string? haircolor = dict["Haircolor"];
        string? indhaircolor = dict["indicatorHaircolor"];
        string? wrapping = dict["Wrapping"];
        string? indwrapping = dict["indicatorWrapping"];
        string? squarenorthsouth = dict["Squarenorthsouth"];
        string? indsquarenorthsouth = dict["indicatorSquarenorthsouth"];
        string? northsouth = dict["Northsouth"];
        string? indnorthsouth = "==";
        string? squareeastwest = dict["Squareeastwest"];
        string? indsquareeastwest = dict["indicatorSquareeastwest"];
        string? eastwest = dict["Eastwest"];
        string? indeastwest = "==";
        Dictionary<string, string?> formValues = new Dictionary<string, string?> {
            {"Sex", sex}, {"Ageatdeath", ageatdeath}, {"Haircolor", haircolor}, {"Wrapping", wrapping}, {"Squarenorthsouth", squarenorthsouth}, {"Northsouth", northsouth}, {"Squareeastwest", squareeastwest}, {"Eastwest", eastwest} };
        Dictionary<string, string?> filtersValues = new Dictionary<string, string?> {
            {"indicatorSex", indsex}, {"indicatorAgeatdeath", indageatdeath}, {"indicatorHaircolor", indhaircolor}, {"indicatorWrapping", indwrapping}, {"indicatorSquarenorthsouth", indsquarenorthsouth}, {"indicatorNorthsouth", indnorthsouth} , {"indicatorSquareeastwest", indsquareeastwest}, {"indicatorEastwest", indeastwest} };

        var filtered = queryable.ToList();

        foreach (var kvp in formValues)
        {
            string? filterValue = filtersValues.GetValueOrDefault("indicator" + kvp.Key);
            if (filterValue == "==")
            {
                if (!string.IsNullOrEmpty(kvp.Value))
                {
                    filtered = filtered
                        .Where(bm => bm.GetType().GetProperty(kvp.Key).GetValue(bm)?.ToString() == kvp.Value)
                        .ToList();
                }
            }
            else if (filterValue == "!=")
            {
                if (!string.IsNullOrEmpty(kvp.Value))
                {
                    filtered = filtered
                        .Where(bm => bm.GetType().GetProperty(kvp.Key).GetValue(bm)?.ToString() != kvp.Value)
                        .ToList();
                }
            }
        }
        return filtered.AsQueryable();
    }

    public void EditRecord(Burialmain burial)
    {
        Context.Update(burial);
        Context.SaveChanges();
    }

    public void CreateRecord(Burialmain burial)
    {
        Context.Add(burial);
        Context.SaveChanges();
    }
}