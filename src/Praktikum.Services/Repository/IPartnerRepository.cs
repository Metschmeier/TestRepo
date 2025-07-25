using Praktikum.Types.DTOs;
using Praktikum.Types;

namespace Praktikum.Services.Repository;

public interface IPartnerRepository
{
    IEnumerable<Partnerzeile> GetAll();
    Partnerzeile? GetById(int id);
    PartnerDto? GetDtoById(int id);
    void Add(Partnerzeile zeile);
    bool Update(int id, Partnerzeile zeile);
    bool Delete(int id);
}
