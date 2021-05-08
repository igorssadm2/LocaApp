using LocaApp.FrameWork.DomainObjects;
using System.ComponentModel.DataAnnotations;

namespace LocaApp.FrameWork.Uteis
{
    /// <summary>
    /// Validação customizada para CPF
    /// </summary>
    public class CustomValidationCPFAttribute : ValidationAttribute
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public CustomValidationCPFAttribute() { }

        /// <summary>
        /// Validação server
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return true;

            bool valido = ValidacaoCpf.ValidaCPF(value.ToString());
            return valido;
        }

    }
}
