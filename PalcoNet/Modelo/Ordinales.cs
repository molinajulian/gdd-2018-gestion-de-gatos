using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Modelo
{
   public static class Ordinales
    {   
       public static Dictionary<string, int> Cliente = new Dictionary<string, int>
                                                {   
                                                    {"nombre",0},
                                                    {"apellido",1},
                                                    {"tipoDocumento",2},
                                                    {"numeroDocumento",3},
                                                    {"cuil",4},
                                                    {"email",5},
                                                    {"telefono",6},
                                                    {"fechaNacimiento",7},
                                                    {"fechaCreacion",8}

                                                };
       public static Dictionary<string, int> Direccion = new Dictionary<string, int> 
                                                 {
                                                 {"calle",0}, 
                                                 {"numero",1},
                                                 {"departamento",2},
                                                 {"localidad",3},  
                                                 {"codPostal",4}
                                                                                               
                                                 };

       public static Dictionary<string, int> Tarjeta = new Dictionary<string, int> 
                                                    {
                                                    {"numero",0},
                                                    {"nombre",1},
                                                    {"fechaVencimiento",2},
                                                    {"ccv",3}
                                                    };
    }
}
