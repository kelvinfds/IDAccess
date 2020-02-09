using System;

namespace IDAccess.Interfaces.AccessLogs
{
    public class LogAcesso
    {

        public long NSR;
        public long IdUsuario;
        public int Evento;
        public DateTime DataHora;
        public long IdDispositivo;
        public long IdIdentificador;

        public LogAcesso(long _NSR, long _IdUsuario, int _Evento, DateTime _DataHora, long _IdDispositivo, long _IdIdentificador)
        {
            NSR = _NSR;
            IdUsuario = _IdUsuario;
            Evento = _Evento;
            DataHora = _DataHora;
            IdDispositivo = _IdDispositivo;
            IdIdentificador = _IdIdentificador;
        }
        
    }
}
