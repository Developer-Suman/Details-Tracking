using DetailsTracking.Data;

namespace DetailsTracking.Model
{
    public class PersonalDetailsService : IPersonalDetailsService
    {
        public AppDbContext _context { get; set; }
        public PersonalDetailsService(AppDbContext PAppDbContext)
        {
            _context = PAppDbContext;
        }

        public List<PersonalDetail> GetAll()
        {
            return _context.PersonalDetails.ToList();
        }

        public List<PersonalDetail> GetByName(string PName)
        {
            var linq = from personaldetails in _context.PersonalDetails select personaldetails;
            if (!string.IsNullOrWhiteSpace(PName))
            {
                linq = linq.Where(x => x.Name.ToUpper().Contains(PName.ToUpper()));
            }
            return linq.ToList();
        }

        public PersonalDetail Save(PersonalDetail PePersonalDetail)
        {
            _context.PersonalDetails.Add(PePersonalDetail);
            _context.SaveChanges();
            return PePersonalDetail;
        }

        public PersonalDetail Update(PersonalDetail PePersonalDetail)
        {
            PersonalDetail obj = _context.PersonalDetails.First(x => x.Id == PePersonalDetail.Id);
            _context.Entry(obj).CurrentValues.SetValues(PePersonalDetail);
            _context.SaveChanges();
            return PePersonalDetail;
        }

        public void Delete(PersonalDetail PePersonalDetails)
        {
            _context.Entry(PePersonalDetails).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
        }

        public PersonalDetail GetById(int Id)
        {
            var P = _context.PersonalDetails.Find(Id);
            return P;
        }
    }
}
