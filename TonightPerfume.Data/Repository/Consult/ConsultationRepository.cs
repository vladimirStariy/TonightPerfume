using Microsoft.EntityFrameworkCore;
using TonightPerfume.Data.Repository.BaseRepository;
using TonightPerfume.Domain.Models;

namespace TonightPerfume.Data.Repository.Consult
{
    public class ConsultationRepository : IRepository<Consultation>
    {
        private readonly ApplicationDbContext _db;

        public ConsultationRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(Consultation model)
        {
            await _db.Consultations.AddAsync(model);
            await _db.SaveChangesAsync();
        }

        public Task Delete(Consultation model)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Consultation> Get()
        {
            return _db.Consultations;
        }

        public async Task<Consultation> GetById(uint id)
        {
            return await _db.Consultations.Where(x => x.Consultation_ID == id).FirstOrDefaultAsync();

        }

        public async Task<Consultation> Update(Consultation model)
        {
            _db.Consultations.Update(model);
            await _db.SaveChangesAsync();
            return model;
        }
    }
}
