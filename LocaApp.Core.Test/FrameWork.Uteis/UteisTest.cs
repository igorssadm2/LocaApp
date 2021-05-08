
using LocaApp.FrameWork.Uteis;
using Xunit;

namespace LocaApp.Core.Test.FrameWork.Uteis
{
    public class UteisTest
    {

        [Theory(DisplayName = "Valida Cpf - ok")]
        [InlineData("373299630-11")]
        [InlineData("37fds3ds299as6d30-11")]
        [InlineData("37329963011")]

        public void FuncaoValidaCpf_ok(string cpf)
        {
            //Arrange 

            //Act 

            //Assert 
            Assert.True(ValidacaoCpf.ValidaCPF(cpf));

        }

        [Theory(DisplayName = "Valida Cpf passando caracteres alem de numeros - ok")]
        [InlineData("373299613-134")]
        [InlineData("373299613-14")]
        [InlineData("37fds3ds1ads299as6d30-11")]

        public void FuncaoValidaCpf_Erro(string cpf)
        {
            //Arrange 

            //Act 

            //Assert 
            Assert.False(ValidacaoCpf.ValidaCPF(cpf));

        }

    }

}
