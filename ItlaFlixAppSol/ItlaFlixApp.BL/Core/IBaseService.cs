namespace ItlaFlixApp.BL.Core
{
    public interface IBaseService
    {
        ServiceResult GetAll();

        ServiceResult GetById(int id);
    }
}
