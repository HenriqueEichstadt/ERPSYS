namespace ERPSYS.MVC.DAO.Interfaces
{
    public interface IEntityModel<T>
    {
        T CreateInstance<T>() where T : new();
    }
}