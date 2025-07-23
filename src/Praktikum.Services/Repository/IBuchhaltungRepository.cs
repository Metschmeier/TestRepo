using Praktikum.Types;
using Praktikum.Services.DTOs;

namespace Praktikum.Services.Repository;

public interface IBuchhaltungRepository
{
    IEnumerable<Buchung> GetAll();
    Buchung? GetById(int id);
    BuchungDto? GetDtoById(int id);
    void Add(Buchung zeile);
    bool Update(int id, Buchung zeile);
    bool Delete(int id);
    bool SetLocked(int id, bool locked);
}