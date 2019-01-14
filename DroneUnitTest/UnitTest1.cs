using System;
using Drone;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DroneUnitTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void Passos_nao_podem_aparecer_apos_operacao_de_cancelamento()
        {
            var resultadoInvalido = Tuple.Create(999,999);
            var resultado = DroneClass.Evaluate("NNX2");
            Assert.IsTrue(resultadoInvalido.Equals(resultado)); 
        }

        [TestMethod]
        public void Somente_pontos_cardeais_operacao_de_cancelamento_e_passos_sao_caracteres_validos()
        {
            var resultadoInvalido = Tuple.Create(999, 999);
            var resultado = DroneClass.Evaluate("NNX2hjhjk");
            Assert.IsTrue(resultadoInvalido.Equals(resultado)); 
        }


        [TestMethod]
        public void Comando_NNX2_resulta_em_999_999()
        {
            var resultadoInvalido = Tuple.Create(999, 999);
            var resultado = DroneClass.Evaluate("NNX2");
            Assert.IsTrue(resultadoInvalido.Equals(resultado));
        }

        [TestMethod]
        public void Comando_NNNLLL_resulta_em_3_3()
        {
            var resultadoInvalido = Tuple.Create(3,3);
            var resultado = DroneClass.Evaluate("NNNLLL");
            Assert.IsTrue(resultadoInvalido.Equals(resultado));
        }


        [TestMethod]
        public void Comando_NNNXLLLXX_resulta_em_1_2()
        {
            var resultadoInvalido = Tuple.Create(1, 2);
            var resultado = DroneClass.Evaluate("NNNXLLLXX");
            Assert.IsTrue(resultadoInvalido.Equals(resultado));
        }


        [TestMethod]
        public void Comando_N123LSX_resulta_em_1_123()
        {
            var resultadoInvalido = Tuple.Create(1, 123);
            var resultado = DroneClass.Evaluate("N123LSX");
            Assert.IsTrue(resultadoInvalido.Equals(resultado));
        }

        [TestMethod]
        public void Comando_NLS3X_resulta_em_1_1()
        {
            var resultadoInvalido = Tuple.Create(1, 1);
            var resultado = DroneClass.Evaluate("NLS3X");
            Assert.IsTrue(resultadoInvalido.Equals(resultado));
        }
    }
}
