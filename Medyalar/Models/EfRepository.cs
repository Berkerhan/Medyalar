using Medyalar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyalar.Models
{
    public class EfRepository : IRepository
    {
        private MedyalarContext _context;
        public EfRepository(MedyalarContext context)
        {
            _context = context;
        }

        public IQueryable<Medya> Medya => _context.Medya;

        public void CreateMedya(Medya newMedya)
        {
            throw new NotImplementedException();
        }

        public void DeleteMedya(int medyaid)
        {
            throw new NotImplementedException();
        }

        public Medya GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Medya> GetMedyas()
        {
            return _context.Medya.Where(m => m.isArchived == false).ToList();  //aktif kayıtlar
        }

        public IEnumerable<Medya> GetMedyasByArchived(bool isArchived)
        {
            return _context.Medya.Where(m => m.isArchived == true).ToList();  //arşivlenen kayıtlar
        }

        public void Arsivle(Medya updatedMedya)
        {
            var entity = _context.Medya.Find(updatedMedya.Id);
            if (entity!=null)
            {
                entity.isArchived = updatedMedya.isArchived = true;  //arşivleme
                _context.SaveChanges();
            }
        }
        public void UpdateMedya(Medya updatedMedya)
        {
            var entity = _context.Medya.Find(updatedMedya.Id);
            if (entity != null)
            {
                entity.Kategori = updatedMedya.Kategori;
                entity.Baslik = updatedMedya.Baslik;
                entity.Sure = updatedMedya.Sure;
                entity.Aciklama = updatedMedya.Aciklama;
                _context.SaveChanges();
            }
        }
    }
}
