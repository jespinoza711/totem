﻿namespace Datos.IntefazDAO.Modulo1
{
    public interface IDaoLogin : IDao<Dominio.Entidad, bool, Dominio.Entidad>
    {
        Dominio.Entidad ValidarUsuarioLogin(Dominio.Entidad usuario);
        Dominio.Entidad ObtenerPreguntaSeguridad(Dominio.Entidad usuario);
        bool ValidarRespuestaSeguridad(Dominio.Entidad usuario);
        bool ValidarCorreoExistente(string correo);
    }
}
