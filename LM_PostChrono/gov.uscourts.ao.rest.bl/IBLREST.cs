
namespace gov.uscourts.ao.rest.bl
{
    public interface IBLREST <T> where T : class
    {
        T LoadObject(); 
    }

    public interface IBLREST<T,U> //: IBLREST<T>
        where T : class
        where U : class
    {
        T LoadObject(U obj);
    }

}

