using Praktikum.WebApi.Models;

namespace Praktikum.WebApi.Repositories;

public interface IBuchhaltungRepository
{
    IEnumerable<Buchhaltungszeile> GetAll();
    Buchhaltungszeile? GetById(int id);
    void Add(Buchhaltungszeile zeile);
    bool Update(int id, Buchhaltungszeile zeile);
    bool Delete(int id);
}
