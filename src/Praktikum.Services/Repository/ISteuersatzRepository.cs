using Praktikum.Types;

namespace Praktikum.Services.Repository;

public interface ISteuersatzRepository
{
    IEnumerable<Steuersatzzeile> GetAll();
    Steuersatzzeile? GetById(int id);
    void Add(Steuersatzzeile zeile);
    bool Update(int id, Steuersatzzeile zeile);
    bool Delete(int id);
}
