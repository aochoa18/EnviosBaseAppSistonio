using System;

namespace Enviosbase.Business
{
    public class Login
    {


        public static Model.Login ValidarUsuarioLoginPorUsuarioContrasena(string usuario, string contrasena)
        {
            Model.Login usuarioLogueado = new Model.Login();
            Data.Login loginClass = new Data.Login();
            try
            {
                usuarioLogueado = loginClass.ValidarUsuarioLoginPorUsuarioContrasena(usuario, contrasena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return usuarioLogueado;
        }

        public static Model.Login ValidarUsuarioLoginPorCorreoContrasena(string usuario, string contrasena)
        {
            Model.Login usuarioLogueado = new Model.Login();
            Data.Login loginClass = new Data.Login();
            try
            {
                usuarioLogueado = loginClass.ValidarUsuarioLoginPorCorreoContrasena(usuario, contrasena);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return usuarioLogueado;
        }

        public static Model.Login ValidarUsuarioLoginPorCorreo(string correo)
        {
            Model.Login usuarioLogueado;
            Data.Login loginClass = new Data.Login();
            try
            {
                usuarioLogueado = loginClass.ValidarUsuarioLoginPorCorreo(correo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return usuarioLogueado;
        }

        //public static int CambiarContrasena(string contrasena, int idUsuario)
        //{
        //    int cambioContrasena = 0;
        //    Data.Login loginClass = new Data.Login();
        //    try
        //    {
        //        cambioContrasena = loginClass.CambiarContrasena(System.Configuration.ConfigurationManager.AppSettings["Dsource"].ToString(), contrasena, idUsuario);
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //    return cambioContrasena;

        //}

    }
}
