using System.ComponentModel;

namespace EntityFrameworkCore.ValueObjects
{
    public enum TipoFrete
    {
        [Description("Pago pelo Remetente")]
        CIF,
        [Description("Pago pelo Destinatário")]
        FOB,
        [Description("Retirado pelo Cliente")]
        SemFrete
    }
}
