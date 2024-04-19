using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PBMS_beta3A.Model
{
    public class ListaDeGeraway
    {
        public string               GerawayModelo       { get; set; }
        public string               GerawayFirmware     { get; set; }
        public string               GerawaySerialNumber { get; set; }
        public string               GerawayPartNumber   { get; set; }
        public string               GerawayTipo         { get; set; }

        public int               GerawayNumeroSensore_A { get; set; }
        public int               GerawayNSensore_V      { get; set; }
        public int               GerawayNsensores_Pa    { get; set; }
        public string            GerawayPCB_Version     { get; set; }
        public int               GerawaySimCard         { get; set; }
        public string            GerawayEstadoOnOff     { get; set; }
        public string            GerawaySITE            { get; set; }
        public int            GerawaySensorNivelGasoleo { get; set; }
    }
}