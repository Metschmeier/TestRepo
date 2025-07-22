using Praktikum.Types;

namespace Praktikum.Services.Repository;

public interface IBuchhaltungRepository
{
    IEnumerable<Buchhaltungszeile> GetAll();
    Buchhaltungszeile? GetById(int id);
    void Add(Buchhaltungszeile zeile);
    bool Update(int id, Buchhaltungszeile zeile);
    bool Delete(int id);
    bool SetLocked(int id, bool locked);
}