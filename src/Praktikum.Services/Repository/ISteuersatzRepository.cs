using Praktikum.Types;
using Praktikum.Types.DTOs;

namespace Praktikum.Services.Repository;

public interface ISteuersatzRepository
{
    IEnumerable<Steuersatzzeile> GetAll();
    Steuersatzzeile? GetById(int id);
    SteuersatzDto? GetDtoById(int id);
    void Add(Steuersatzzeile zeile);
    bool Update(int id, Steuersatzzeile zeile);
    bool Delete(int id);
}
