using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyalar.Models
{
    public interface IRepository
    {
        // CRUD METOTLAR

        IQueryable<Medya> Medya { get; }

        Medya GetById(int id);
        IEnumerable<Medya> GetMedyas();
        IEnumerable<Medya> GetMedyasByArchived(bool isArchived);
        void CreateMedya(Medya newMedya);
        void UpdateMedya(Medya updatedMedya);
        void DeleteMedya(int medyaid);
        void Arsivle(Medya updatedMedya);
    }
}
