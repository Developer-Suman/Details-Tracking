namespace DetailsTracking.Model
{
    public interface IPersonalDetailsService
    {
        void Delete(PersonalDetail PePersonalDetails);
        List<PersonalDetail> GetAll();
        PersonalDetail GetById(int Id);
        List<PersonalDetail> GetByName(string PName);
        PersonalDetail Save(PersonalDetail PePersonalDetail);
        PersonalDetail Update(PersonalDetail PePersonalDetail);
    }
}