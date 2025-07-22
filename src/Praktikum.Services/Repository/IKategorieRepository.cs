using Praktikum.Types;

namespace Praktikum.Services.Repository;

public interface IKategorieRepository
{
    IEnumerable<Kategoriezeile> GetAll();
    Kategoriezeile? GetById(int id);
    void Add(Kategoriezeile zeile);
    bool Update(int id, Kategoriezeile zeile);
    bool Delete(int id);
}
