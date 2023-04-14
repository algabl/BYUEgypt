using System;
using BYUEgypt.Models.ViewModels;

namespace BYUEgypt.Models;

public interface IMummyRepository
{
    public IQueryable<Burialmain> Mummies { get; }
    public IQueryable<Mummy> GetBurials(Dictionary<string, string?>? burialParams = null);
}