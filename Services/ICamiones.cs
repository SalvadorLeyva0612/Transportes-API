using DTO;
using Transportes_API.Models;

namespace Transportes_API.Services
{
    public interface ICamiones
    {
        //es una estructura que define un contrato o conjunto de métodos y
        //propiedades que una clase debe implementar.
        //Una interfaz establece un conjunto de requisitos que cualquier clase
        //que la implemente debe seguir. Estos requisitos son declarados en la
        //interfaz en forma de firmas de métodos y propiedades,
        //pero la interfaz en sí misma no proporciona ninguna implementación
        //de estos métodos o propiedades.Es responsabilidad de las clases que
        //implementan la interfaz proporcionar las implementaciones concretas de
        //estos miembros.

        //Las interfaces son útiles para lograr la abstracción y la reutilización
        //de código en C#.


        //Get
        List<Camiones> GetCamiones();

        Camiones_DTO GetCamionbyID(int id);

        //Insert
        string InsertCamion(Camiones_DTO camion);

        //Update
        string UpdateCamion(Camiones_DTO camion);

        //Delete 
        string DeleteCamion(int id);




    
    }
}
