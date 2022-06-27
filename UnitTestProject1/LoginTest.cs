using System;
using ApplicationCore.Services;
using Infraestructure.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class LoginTest
    {
        [TestMethod]
        public void LoginTestCorrecto()
        {
            //Arrange
            String username = "admin4";
            String clave = "admin4";
            Usuario usuario1 = new Usuario();
            usuario1.Username = "admin4";
            String resultadoEsperado = usuario1.Username;
            //Act
            IServiceUsuario serviceUsuario = new ServiceUsuario();
            Usuario usuario = serviceUsuario.GetUsuario(username, clave);
            //Assert
            Assert.AreEqual(resultadoEsperado, usuario.Username);
        }
        [TestMethod]
        public void LoginTestIncorrecto()
        {
            //Arrange
            String username = "admin4";
            String clave = "admin";
            Usuario usuario1 = new Usuario();
            usuario1.Username = "admin4";
            Usuario resultadoEsperado = null;
            //Act
            IServiceUsuario serviceUsuario = new ServiceUsuario();
            Usuario usuario = serviceUsuario.GetUsuario(username, clave);
            //Assert
            Assert.AreEqual(resultadoEsperado, usuario);
        }
    }
}
