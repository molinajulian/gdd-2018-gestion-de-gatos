using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalcoNet.Modelo
{
   public static class Ordinales
    {
       public static Dictionary<string, int> camposGetTiposDoc = new Dictionary<string, int> 
                                               {
                                                   {"tipos_doc_id",0},
                                                   {"tipos_doc_descr",1}
                                               };
       public static Dictionary<string, int> campoSalidaAgregar = new Dictionary<string, int>
                                                {
                                                    {"salida",0}
                                                };
       public static Dictionary<string, int> camposUsuario = new Dictionary<string, int>
                                                {
                                                    {"id", 0},
                                                    {"username", 1},
                                                    {"estado", 2},
                                                    {"primer_logueo",3}
                                                };
       public static Dictionary<string, int> campoClienteExistente = new Dictionary<string, int>
                                                {
                                                    {"cantidad",0}
                                                };
       public static Dictionary<string, int> camposRol = new Dictionary<string, int>
                                                {
                                                    {"id", 0},
                                                    {"nombre", 1}
                                                };
       public static Dictionary<string, int> camposRolListado = new Dictionary<string, int>
                                                {
                                                    {"id", 0},
                                                    {"nombre", 1},
                                                    {"habilitado",2}
                                                };
       public static Dictionary<string, int> camposHistorialCliente = new Dictionary<string, int>
                                                {
                                                    {"total", 0},
                                                    {"fecha_compra", 1},
                                                    {"fecha_espectaculo",2},
                                                    {"descripcion_espectaculo",3},
                                                    {"tipo_espectaculo",4}
                                                };
       public static Dictionary<string, int> camposGetClientes = new Dictionary<string, int>
                                                {
                                                    {"tipo_doc_descr", 0},
                                                    {"cli_doc", 1},
                                                    {"cli_cuil", 2},
                                                    {"cli_nombre", 3},
                                                    {"cli_apellido", 4},
                                                    {"cli_mail", 5},
                                                    {"dom_calle", 6},
                                                    {"dom_nro_calle", 7},
                                                    {"dom_depto",8},
                                                    {"dom_piso",9},
                                                    {"dom_localidad", 10},
                                                    {"dom_cod_postal", 11},
                                                    {"habilitado",12}
                                                };
        public static Dictionary<string, int> camposGetCliente = new Dictionary<string, int>
                                                {
                                                    {"tipo_doc_id", 0},
                                                    {"cli_doc", 1},
                                                    {"cli_apellido", 2},
                                                    {"cli_nombre", 3},
                                                    {"cli_cuil", 4},
                                                    {"cli_fecha_nac", 5},
                                                    {"cli_fecha_creacion", 6},
                                                    {"cli_mail", 7},
                                                    {"cli_tel", 8},
                                                    {"cli_dom_id", 9},
                                                    {"cli_puntos", 10},
                                                    {"cli_usuario_id", 11},
                                                    {"cli_habilitado", 12}
                                                };
        public static Dictionary<string, int> camposFuncionalidad = new Dictionary<string, int>
                                                {
                                                    {"id", 0},
                                                    {"descripcion", 1}
                                                };
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
                                                    {"fechaCreacion",8},
                                                    

                                                };
       public static Dictionary<string, int> Domicilio = new Dictionary<string, int> 
                                                 {
                                                 {"id",0},
                                                 {"codPostal",1},
                                                 {"localidad",2},
                                                 {"piso",3},
                                                 {"departamento",4},
                                                 { "numero",5},
                                                 {"calle",6}
                                                 };
        public static Dictionary<string, int> Tarjeta = new Dictionary<string, int>
                                                    {
                                                        {"id",0},
                                                        {"numero",1},
                                                        {"vencimiento",2},
                                                        {"banco_desc",3},
                                                        {"cli_tipo_doc",4},
                                                        {"cli_doc",5}
                                                    };
       public static Dictionary<string, int> Empresa = new Dictionary<string, int> 
                                                    {
                                                    {"cuit",0},
                                                    {"razonSocial",1},
                                                    {"fechaCreacion",2},
                                                    {"email",3},
                                                    {"domicilioId",4},
                                                    {"usuarioId", 5},
                                                    {"telefono",6},
                                                    {"habilitada", 7}
                                                    };
       public static Dictionary<string, int> Rubro = new Dictionary<string, int> 
                                                    {
                                                    {"codigo",0},
                                                    {"descripcion",1}
                                                    
                                                    };

        public static Dictionary<string, int> Publicacion = new Dictionary<string, int> 
                                                    {
                                                    {"codigo",0},
                                                    {"descripcion",1},
                                                    {"fechaCreacion",2},
                                                    {"gradoCodigo",3},
                                                    {"especCodigo",4},
                                                    {"estadoId",5},
                                                    {"editor",6},
                                                    };
        public static Dictionary<string, int> PublicacionCompuesta = new Dictionary<string, int>
                                                    {
                                                        {"pub_codigo",0},
                                                        {"pub_desc",1},
                                                        {"pub_fechaCreacion",2},
                                                        {"pub_gradoCodigo",3},
                                                        {"pub_especCodigo",4},
                                                        {"pub_estadoId",5},
                                                        {"pub_editor",6},
                                                        {"esp_id",7},
                                                        {"esp_descripcion",8},
                                                        {"esp_fecha",9},
                                                        {"esp_vencimiento",10},
                                                        {"esp_idRubro",11},
                                                        {"esp_idEmpresa",12},
                                                        {"esp_idDomicilio",13},
                                                        {"esp_estado",14}
                                                    };
        public static Dictionary<string, int> Ubicacion = new Dictionary<string, int> 
                                                    {
                                                    {"id", 0 },
                                                    {"fila",1},
                                                    {"asiento",2},
                                                    {"sin_numerar",3},
                                                    {"precio",4},
                                                    {"espec_cod",5},
                                                    {"tipo_cod",6},
                                                    {"compra_id",7}
                                                    };
        public static Dictionary<string, int> TipoUbicacion = new Dictionary<string, int>
                                                    {
                                                    {"Ubic_Tipo_Cod",0},
                                                    {"Ubic_Tipo_Descr",1}
                                                    };
        public static Dictionary<string, int> Grado = new Dictionary<string, int> 
                                                    {
                                                    {"codigo",0},
                                                    {"comision",1},
                                                    {"descripcion",2},
                                                    {"habilitado",3}
                                                    };
        public static Dictionary<string, int> ItemFactura = new Dictionary<string, int>
                                                    {
                                                    {"itemFact_Id",0},
                                                    {"itemFact_FactId",1},
                                                    {"itemFact_Cantidad",2},
                                                    {"itemFact_Monto",3 }
                                                    };
        public static Dictionary<string, int> Factura = new Dictionary<string, int>
                                                    {
                                                    {"Fact_Id",0},
                                                    {"Fact_Metodo_Pago",1},
                                                    {"Fact_Total",2},
                                                    {"Fact_Fecha",3 },
                                                    {"Fact_Empresa_Cuit",4 }
                                                    };
        public static Dictionary<string, int> Compra = new Dictionary<string, int>
                                                    {
                                                    {"Compra_Id",0},
                                                    {"Compra_Publicacion_Id",1},
                                                    {"Compra_Cliente_Documento",2},
                                                    {"Compra_TipoDoc",3 },
                                                    {"Compra_Fecha",4 }
                                                    };
        public static Dictionary<string, int> EstadoPublicacion = new Dictionary<string, int> 
                                                    {
                                                    {"id",0},
                                                    {"descripcion",1 },
                                                    {"editable",2},
                                                    };
       public static Dictionary<string, int> Espectaculo = new Dictionary<string, int> 
                                                    {
                                                    {"id",0},
                                                    {"descripcion",1 },
                                                    {"fecha",2},
                                                    {"fechaVencimiento",3},
                                                    {"idRubro",4},
                                                    {"idEmpresa",5},
                                                    {"idDomicilio",6},
                                                    {"estado",7}
                                                    };
        public static Dictionary<string, int> Premio = new Dictionary<string, int>
                                                    {
                                                    {"Premio_Id",0},
                                                    {"Premio_Desc",1},
                                                    {"Premio_Puntos",2}
                                                    };
    }

}
