using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        static HttpClient client = new HttpClient();
        public static async Task<ML.Result> GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {



                using (DL.RGonzalezUsuarioEntities context = new DL.RGonzalezUsuarioEntities())
                {

                    var query = await Task.Run(() => context.GetAll());

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var item in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = item.IdUsuario;
                            usuario.Nombre = item.Nombre;
                            usuario.ApellidoPaterno = item.ApellidoPaterno;
                            usuario.ApellidoMaterno = item.ApellidoMaterno;
                            usuario.Sexo = item.Sexo;
                            usuario.Edad = (int)item.Edad;
                            usuario.Correo = item.Correo;

                            result.Objects.Add(usuario);


                        }
                        result.Correct = true;
                    }
                   


                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;



            }

                return result;

            }


            public static async Task<ML.Result> GetById(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {

                using (DL.RGonzalezUsuarioEntities context = new DL.RGonzalezUsuarioEntities())
                {
                    var query = await Task.Run(() => context.GetById(idUsuario).FirstOrDefault());

                    if (query != null)
                    {
                        ML.Usuario usuario = new ML.Usuario
                        {

                            Nombre = query.Nombre,
                            ApellidoPaterno = query.ApellidoPaterno,
                            ApellidoMaterno = query.ApellidoMaterno,
                            Sexo = query.Sexo,
                            Edad = (int)query.Edad,
                            Correo = query.Correo

                        };
                        result.Object = usuario;

                    }

                    result.Correct = true;


                }

            }

            catch (Exception ex)

            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }


            return result;
        }




        public static async Task<ML.Result> Agregar(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.RGonzalezUsuarioEntities context = new DL.RGonzalezUsuarioEntities())
                {

                    var item = await Task.Run(() => context.Agregar(usuario.Nombre, usuario.ApellidoPaterno,
                                                    usuario.ApellidoMaterno, usuario.Sexo, usuario.Edad, usuario.Correo));

                    if (item > 0)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.ErrorMessage = "No se agrego ningun usuario";
                    }

                }
            }
            catch (Exception ex)
            {

                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;


            }

            return result;

        }


        public static async Task<ML.Result> Actualizar(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {




                using (DL.RGonzalezUsuarioEntities context = new DL.RGonzalezUsuarioEntities())
                {
                    var query = await Task.Run(() => context.Actualizar(usuario.IdUsuario,
                                                    usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Sexo, usuario.Edad, usuario.Correo));


                    if (query > 0)
                    {

                        result.Correct = true;

                    }

                    else
                    {
                        result.ErrorMessage = "Error al actualizar el usuario";
                    }

                }


            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;

        }


        public static async Task<ML.Result> Eliminar(int idUsuario)
        {
            ML.Result result = new ML.Result();

            try
            {




                using (DL.RGonzalezUsuarioEntities context = new DL.RGonzalezUsuarioEntities())
                {
                    var query = await Task.Run(() => context.Eliminar(idUsuario));


                    if (query > 0)
                    {

                        result.Correct = true;

                    }

                    else
                    {
                        result.ErrorMessage = "Error al Eliminar el usuario";
                    }

                }


            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;

        }









        //public static async Task<ML.Result> Prueba()
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {

        //        List<ML.Usuario> usuarios = new List<ML.Usuario>();
        //        using (var client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri("http://localhost:10661/");
        //            HttpResponseMessage response = await client.GetAsync("api/Usuario/GetAll");
        //            if (client != null)
        //            {
        //               ML.Usuario usuario = new ML.Usuario();

        //            }
        //        }

        //    }

        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //        result.Ex = ex;
        //    }


        //    return result;



        //} 



    }
}
