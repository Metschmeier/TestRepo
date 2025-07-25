using Praktikum.Types;
using Praktikum.Types.DTOs;

namespace Praktikum.Services.Repository;

public interface IKostenstelleRepository
{
    IEnumerable<Kostenstellezeile> GetAll();
    Kostenstellezeile? GetById(int id);
    KategorieDto? GetDtoById(int id);
    void Add(Kostenstellezeile zeile);
    bool Update(int id, Kostenstellezeile zeile);
    bool Delete(int id);
}
